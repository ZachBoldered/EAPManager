// ===============================================================================
// 来源于 Microsoft Data Access Application Block for .NET 2.0
// ===============================================================================

using System;
using System.Data;
using System.Xml;
using System.Data.OleDb;
using System.Collections;
using System.Configuration;


namespace Pos
{
    /// <summary>
    /// 数据访问助手类
    /// </summary>
    public sealed class DbHelper
    {        
        #region private utility methods & constructors
        // Since this class provides only static methods, make the default constructor private to prevent 
        // instances from being created with "new DbHelper()"
        private DbHelper() { }

        private static string connectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + ConfigurationManager.AppSettings["DBPath"].ToString() + ";Persist Security Info=True;";

        /// <summary>
        /// 取回连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        /// <summary>
        /// This method is used to attach array of OleDbParameters to a OleDbCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of OleDbParameters to be added to command</param>
        private static void AttachParameters(OleDbCommand command, OleDbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (OleDbParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// This method assigns dataRow column values to an array of OleDbParameters
        /// </summary>
        /// <param name="commandParameters">Array of OleDbParameters to be assigned values</param>
        /// <param name="dataRow">The dataRow used to hold the stored procedure's parameter values</param>
        private static void AssignParameterValues(OleDbParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                // Do nothing if we get no data
                return;
            }

            int i = 0;
            // Set the parameters values
            foreach (OleDbParameter commandParameter in commandParameters)
            {
                // Check the parameter name
                if (commandParameter.ParameterName == null ||
                    commandParameter.ParameterName.Length <= 1)
                    throw new Exception(
                        string.Format(
                            "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
                            i, commandParameter.ParameterName));
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        /// <summary>
        /// This method assigns an array of values to an array of OleDbParameters
        /// </summary>
        /// <param name="commandParameters">Array of OleDbParameters to be assigned values</param>
        /// <param name="parameterValues">Array of objects holding the values to be assigned</param>
        private static void AssignParameterValues(OleDbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the OleDbParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The OleDbCommand to be prepared</param>
        /// <param name="connection">A valid OleDbConnection, on which to execute this command</param>
        /// <param name="transaction">A valid OleDbTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">An array of OleDbParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private static void PrepareCommand(OleDbCommand command, OleDbConnection connection, OleDbTransaction transaction, CommandType commandType, string commandText, OleDbParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or OleDb statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Resolve at run time the appropriate set of OleDbParameters for a stored procedure
        /// </summary>
        /// <param name="connection">A valid OleDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
        /// <returns>The parameter array discovered.</returns>
        private static OleDbParameter[] DiscoverSpParameterSet(OleDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            OleDbCommand cmd = new OleDbCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            OleDbCommandBuilder.DeriveParameters(cmd);
            connection.Close();

            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            OleDbParameter[] discoveredParameters = new OleDbParameter[cmd.Parameters.Count];

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            // Init the parameters with a DBNull value
            foreach (OleDbParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        /// <summary>
        /// Deep copy of cached OleDbParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        private static OleDbParameter[] CloneParameters(OleDbParameter[] originalParameters)
        {
            OleDbParameter[] clonedParameters = new OleDbParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (OleDbParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private utility methods & constructors

        #region ExecuteNonQuery

        /// <summary>
        /// 执行指定的查询字符串,类型的OleDbCommand
        /// </summary>
        /// <remarks>
        /// 示例.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回命令影响的行数</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of OleDbParameters
            return ExecuteNonQuery(commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定连接字符串,类型的OleDbCommand.如果没有提供参数,不返回结果.
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">OleDbParameter参数数组</param>
        /// <returns>返回命令影响的行数</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");

            // Create & open a OleDbConnection, and dispose of it after we are done
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(OleDbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">OleDbParamter参数数组</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // 创建Command命令,并进行预处理
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // 清除参数,以便再次使用.
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,将对象数组的值赋给存储过程参数.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(OleDbConnection connection, string spName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 给存储过程分配参数值
                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行带事务的OleDbCommand.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="transaction">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(OleDbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(transaction, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行带事务的OleDbCommand(指定参数).
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">OleDbParamter参数数组</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // 预处理
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // 执行
            int retval = cmd.ExecuteNonQuery();

            // 清除参数集,以便再次使用.
            cmd.Parameters.Clear();
            return retval;
        }

        /// <summary>
        /// 执行带事务的OleDbCommand(指定参数值).
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值
        /// 
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, trans, "PublishOrders", 24, 36);
        /// </remarks>
        /// <param name="transaction">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(OleDbTransaction transaction, string spName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 给存储过程参数赋值
                AssignParameterValues(commandParameters, parameterValues);

                // 调用重载方法
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // 没有参数值
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion ExecuteNonQuery

        #region ExecuteDataset

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            return ExecuteDataset(commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">OleDbParamters参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");

            // 创建并打开数据库连接对象,操作完成释放对象.
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法.
                return ExecuteDataset(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet. 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <param name="commandParameters">OleDbParamter参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // 预处理
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    connection.Close();

                // Return the dataset
                return ds;
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定参数值,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输入参数和返回值.
        /// 
        /// 示例.:  
        ///  DataSet ds = ExecuteDataset(conn, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, string spName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 比缓存中加载存储过程参数
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 给存储过程参数分配值
                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定事务的命令,返回DataSet. 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(OleDbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteDataset(transaction, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定事务的命令,指定参数,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <param name="commandParameters">OleDbParamter参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // 预处理
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                da.Fill(ds);

                cmd.Parameters.Clear();

                return ds;
            }
        }

        /// <summary>
        /// 执行指定事务的命令,指定参数值,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输入参数和返回值.
        /// 
        /// 示例.:  
        ///  DataSet ds = ExecuteDataset(trans, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="transaction">事务</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDataset(OleDbTransaction transaction, string spName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 给存储过程参数分配值
                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion ExecuteDataset

        #region ExecuteReader

        /// <summary>
        /// 枚举,标识数据库连接是由DbHelper提供还是由调用者提供
        /// </summary>
        private enum OleDbConnectionOwnership
        {
            /// <summary>由DbHelper提供连接</summary>
            Internal,
            /// <summary>由调用者提供连接</summary>
            External
        }

        /// <summary>
        /// 执行指定数据库连接对象的数据阅读器.
        /// </summary>
        /// <remarks>
        /// 如果是DbHelper打开连接,当连接关闭DataReader也将关闭.
        /// 如果是调用都打开连接,DataReader由调用都管理.
        /// 
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="transaction">一个有效的事务,或者为 'null'</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <param name="commandParameters">OleDbParameters参数数组,如果没有参数则为'null'</param>
        /// <param name="connectionOwnership">标识数据库连接对象是由调用者提供还是由DbHelper提供</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        private static OleDbDataReader ExecuteReader(OleDbConnection connection, OleDbTransaction transaction, CommandType commandType, string commandText, OleDbParameter[] commandParameters, OleDbConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // 创建命令
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // 创建数据阅读器
                OleDbDataReader dataReader;

                if (connectionOwnership == OleDbConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                // 清除参数,以便再次使用..
                // HACK: There is a problem here, the output parameter values are fletched 
                // when the reader is closed, so if the parameters are detached from the command
                // then the OleDbReader can磘 set its values. 
                // When this happen, the parameters can磘 be used again in other command.
                bool canClear = true;
                foreach (OleDbParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行指定数据库连接字符串的数据阅读器.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return ExecuteReader(commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的数据阅读器,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或OleDb语句</param>
        /// <param name="commandParameters">OleDbParamter参数数组(new DbParameter("@prodid", 24))</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        public static OleDbDataReader ExecuteReader(CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            OleDbConnection connection = null;
            try
            {
                connection = new OleDbConnection(ConnectionString);
                connection.Open();

                // Call the private overload that takes an internally owned connection in place of the connection string
                return ExecuteReader(connection, null, commandType, commandText, commandParameters, OleDbConnectionOwnership.Internal);
            }
            catch
            {
                // If we fail to return the OleDbDatReader, we need to close the connection ourselves
                if (connection != null) connection.Close();
                throw;
            }

        }

        /// <summary>
        ///执行指定数据库连接字符串的数据阅读器,指定参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数
        /// 
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(connString, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        //public static OleDbDataReader ExecuteReader(string spName, params object[] parameterValues)
        //{
        //    if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
        //    if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

        //    // If we receive parameter values, we need to figure out where they go
        //    if ((parameterValues != null) && (parameterValues.Length > 0))
        //   {
        //        OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(spName);

        //       AssignParameterValues(commandParameters, parameterValues);

        //        return ExecuteReader(ConnectionString, CommandType.StoredProcedure, spName, commandParameters);
        //   }
        //  else
        //   {
        // Otherwise we can just call the SP without params
        //     return ExecuteReader(ConnectionString, CommandType.StoredProcedure, spName);
        //}
        //}

        /// <summary>
        /// 执行指定数据库连接对象的数据阅读器. 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">The stored procedure name or T-OleDb command</param>
        /// <returns>存储过程名或OleDb语句</returns>
        public static OleDbDataReader ExecuteReader(OleDbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteReader(connection, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库连接对象的数据阅读器,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandParameters">OleDbParamter参数数组</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            return ExecuteReader(connection, (OleDbTransaction)null, commandType, commandText, commandParameters, OleDbConnectionOwnership.External);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库连接对象的数据阅读器,指定参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(OleDbConnection connection, string spName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // If we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                return ExecuteReader(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// [调用者方式]执行指定数据库事务的数据阅读器,指定参数值.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>分配给命令的OleDbParamter参数数组</returns>
        public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteReader(transaction, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库事务的数据阅读器,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///   OleDbDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, OleDbConnectionOwnership.External);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库事务的数据阅读器,指定参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  OleDbDataReader dr = ExecuteReader(trans, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, string spName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // 没有参数值
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion ExecuteReader

        #region ExecuteScalar

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(CommandType commandType, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            // 创建并打开数据库连接对象,操作完成释放对象.
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法
                return ExecuteScalar(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,指定参数值,返回结果集中的第一行第一列
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数
        /// 
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        //public static object ExecuteScalar(string spName, params object[] parameterValues)
        //{
        //    if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
        //    if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

        //    // If we receive parameter values, we need to figure out where they go
        //    if ((parameterValues != null) && (parameterValues.Length > 0))
        //    {
        //        // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
        //        OleDbParameter[] commandParameters = DbHelperParameterCache.GetSpParameterSet(ConnectionString, spName);

        //        // Assign the provided values to these parameters based on parameter order
        //        AssignParameterValues(commandParameters, parameterValues);

        //        // Call the overload that takes an array of OleDbParameters
        //        return ExecuteScalar(ConnectionString, CommandType.StoredProcedure, spName, commandParameters);
        //    }
        //    else
        //    {
        //        // Otherwise we can just call the SP without params
        //        return ExecuteScalar(ConnectionString, CommandType.StoredProcedure, spName);
        //    }
        //}

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回结果集中的第一行第一列. 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(OleDbConnection connection, CommandType commandType, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(connection, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // 创建Command命令,并进行预处理
            OleDbCommand cmd = new OleDbCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // 执行Command命令,并返回结果
            object retval = cmd.ExecuteScalar();

            // 清除参数,以便再次使用
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定参数值,返回结果集中的第一行第一列
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(conn, "GetOrderCount", 24, 36);
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(OleDbConnection connection, string spName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 给存储过程参数赋值
                AssignParameterValues(commandParameters, parameterValues);

                // 调用重载方法
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // 没有参数值
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定数据库事务的命令,返回结果集中的第一行第一列
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(OleDbTransaction transaction, CommandType commandType, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(transaction, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,指定参数,返回结果集中的第一行第一列
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // 创建OleDbCommand命令,并进行预处理
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // 执行OleDbCommand命令,并返回结果
            object retval = cmd.ExecuteScalar();

            // 清除参数,以便再次使用
            cmd.Parameters.Clear();
            return retval;
        }

        /// <summary>
        /// 执行指定数据库事务的命令,指定参数值,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount", 24, 36);
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(OleDbTransaction transaction, string spName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // PPull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 给存储过程参数赋值
                AssignParameterValues(commandParameters, parameterValues);

                // 调用重载方法
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // 没有参数值
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion ExecuteScalar
        

        #region FillDataset
        /// <summary>
        /// 执行指定数据库连接字符串的命令,映射数据表并填充数据集.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)</param>
        public static void FillDataset(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            // 创建并打开数据库连接对象,操作完成释放对象.
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法.
                FillDataset(connection, commandType, commandText, dataSet, tableNames);
            }
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,映射数据表并填充数据集.指定命令参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        public static void FillDataset(CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OleDbParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // 创建并打开数据库连接对象,操作完成释放对象.
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法.
                FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
            }
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,映射数据表并填充数据集,指定存储过程参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, 24);
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>    
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        public static void FillDataset(string spName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // 创建并打开数据库连接对象,操作完成释放对象
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法
                FillDataset(connection, spName, dataSet, tableNames, parameterValues);
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,映射数据表并填充数据集 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>    
        public static void FillDataset(OleDbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,映射数据表并填充数据集,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        public static void FillDataset(OleDbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OleDbParameter[] commandParameters)
        {
            FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,映射数据表并填充数据集,指定存储过程参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  FillDataset(conn, "GetOrders", ds, new string[] {"orders"}, 24, 36);
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        public static void FillDataset(OleDbConnection connection, string spName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 给存储过程参数赋值
                AssignParameterValues(commandParameters, parameterValues);

                // 调用重载方法
                FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
            }
            else
            {
                // 没有参数值
                FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
            }
        }

        /// <summary>
        /// 执行指定数据库事务的命令,映射数据表并填充数据集. 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        public static void FillDataset(OleDbTransaction transaction, CommandType commandType,
            string commandText,
            DataSet dataSet, string[] tableNames)
        {
            FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,映射数据表并填充数据集,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        public static void FillDataset(OleDbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OleDbParameter[] commandParameters)
        {
            FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,映射数据表并填充数据集,指定存储过程参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 
        /// 示例:  
        ///  FillDataset(trans, "GetOrders", ds, new string[]{"orders"}, 24, 36);
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        public static void FillDataset(OleDbTransaction transaction, string spName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 给存储过程参数赋值
                AssignParameterValues(commandParameters, parameterValues);

                // 调用重载方法
                FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
            }
            else
            {
                // 没有参数值
                FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
            }
        }

        /// <summary>
        /// [私有方法][内部调用]执行指定数据库连接对象/事务的命令,映射数据表并填充数据集,DataSet/TableNames/OleDbParameters.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(conn, trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或OleDb语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="commandParameters">分配给命令的OleDbParamter参数数组</param>
        private static void FillDataset(OleDbConnection connection, OleDbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OleDbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            // 创建OleDbCommand命令,并进行预处理
            OleDbCommand command = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // 执行命令
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
            {

                // 追加表映射
                if (tableNames != null && tableNames.Length > 0)
                {
                    string tableName = "Table";
                    for (int index = 0; index < tableNames.Length; index++)
                    {
                        if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                        tableName += (index + 1).ToString();
                    }
                }

                // 填充数据集使用默认表名称
                dataAdapter.Fill(dataSet);

                // 清除参数,以便再次使用
                command.Parameters.Clear();
            }

            if (mustCloseConnection)
                connection.Close();
        }
        #endregion

        #region UpdateDataset
        /// <summary>
        /// 执行数据集更新到数据库,指定inserted, updated, or deleted命令.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  UpdateDataset(conn, insertCommand, deleteCommand, updateCommand, dataSet, "Order");
        /// </remarks>
        /// <param name="insertCommand">[追加记录]一个有效的OleDb语句或存储过程</param>
        /// <param name="deleteCommand">[删除记录]一个有效的OleDb语句或存储过程</param>
        /// <param name="updateCommand">[更新记录]一个有效的OleDb语句或存储过程</param>
        /// <param name="dataSet">要更新到数据库的DataSet</param>
        /// <param name="tableName">要更新到数据库的DataTable</param>
        public static void UpdateDataset(OleDbCommand insertCommand, OleDbCommand deleteCommand, OleDbCommand updateCommand, DataSet dataSet, string tableName)
        {
            if (insertCommand == null) throw new ArgumentNullException("insertCommand");
            if (deleteCommand == null) throw new ArgumentNullException("deleteCommand");
            if (updateCommand == null) throw new ArgumentNullException("updateCommand");
            if (tableName == null || tableName.Length == 0) throw new ArgumentNullException("tableName");

            // 创建DbDataAdapter,当操作完成后释放.
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // 设置数据适配器命令
                dataAdapter.UpdateCommand = updateCommand;
                dataAdapter.InsertCommand = insertCommand;
                dataAdapter.DeleteCommand = deleteCommand;

                // 更新数据集改变到数据库
                dataAdapter.Update(dataSet, tableName);

                // 提交所有改变到数据集
                dataSet.AcceptChanges();
            }
        }
        #endregion

        #region CreateCommand
        /// <summary>
        /// 创建OleDbCommand命令,指定数据库连接对象,存储过程名和参数
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  OleDbCommand command = CreateCommand(conn, "AddCustomer", "CustomerID", "CustomerName");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="sourceColumns">源表的列名称数组</param>
        /// <returns>返回OleDbCommand命令</returns>
        public static OleDbCommand CreateCommand(OleDbConnection connection, string spName, params string[] sourceColumns)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 创建命令
            OleDbCommand cmd = new OleDbCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            // 如果有参数值
            if ((sourceColumns != null) && (sourceColumns.Length > 0))
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 将源表的列到映射到DataSet命令中.
                for (int index = 0; index < sourceColumns.Length; index++)
                    commandParameters[index].SourceColumn = sourceColumns[index];

                // Attach the discovered parameters to the OleDbCommand object
                AttachParameters(cmd, commandParameters);
            }

            return cmd;
        }
        #endregion

        #region ExecuteNonQueryTypedParams
        /// <summary>
        /// 执行指定连接数据库连接字符串的存储过程,使用DataRow做为参数值,返回受影响的行数.
        /// </summary>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQueryTypedParams(String spName, DataRow dataRow)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库连接对象的存储过程,使用DataRow做为参数值,返回受影响的行数.
        /// </summary>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQueryTypedParams(OleDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化.
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库事物的存储过程,使用DataRow做为参数值,返回受影响的行数.
        /// </summary>
        /// <param name="transaction">一个有效的连接事务 object</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQueryTypedParams(OleDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // Sf the row has values, the store procedure parameters must be initialized
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
            }
        }
        #endregion

        #region ExecuteDatasetTypedParams
        /// <summary>
        /// 执行指定连接数据库连接字符串的存储过程,使用DataRow做为参数值,返回DataSet
        /// </summary>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDatasetTypedParams(String spName, DataRow dataRow)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            //如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(spName);

                // Set the parameters values
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteDataset(CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteDataset(CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库连接对象的存储过程,使用DataRow做为参数值,返回DataSet
        /// </summary>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDatasetTypedParams(OleDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库事务的存储过程,使用DataRow做为参数值,返回DataSet.
        /// </summary>
        /// <param name="transaction">一个有效的连接事务 object</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public static DataSet ExecuteDatasetTypedParams(OleDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion

        #region ExecuteReaderTypedParams
        /// <summary>
        /// 执行指定连接数据库连接字符串的存储过程,使用DataRow做为参数值,返回DataReader.
        /// </summary>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        public static OleDbDataReader ExecuteReaderTypedParams(String spName, DataRow dataRow)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteReader(CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteReader(CommandType.StoredProcedure, spName);
            }
        }


        /// <summary>
        /// 执行指定连接数据库连接对象的存储过程,使用DataRow做为参数值,返回DataReader.
        /// </summary>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReaderTypedParams(OleDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库事物的存储过程,使用DataRow做为参数值,返回DataReader
        /// </summary>
        /// <param name="transaction">一个有效的连接事务 object</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回包含结果集的OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReaderTypedParams(OleDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
            }
        }
        #endregion

        #region ExecuteScalarTypedParams
        /// <summary>
        /// 执行指定连接数据库连接字符串的存储过程,使用DataRow做为参数值,返回结果集中的第一行第一列
        /// </summary>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalarTypedParams(String spName, DataRow dataRow)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteScalar(CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteScalar(CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库连接对象的存储过程,使用DataRow做为参数值,返回结果集中的第一行第一列
        /// </summary>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalarTypedParams(OleDbConnection connection, String spName, DataRow dataRow)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
            }
        }

        /// <summary>
        /// 执行指定连接数据库事务的存储过程,使用DataRow做为参数值,返回结果集中的第一行第一列.
        /// </summary>
        /// <param name="transaction">一个有效的连接事务 object</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dataRow">使用DataRow作为参数值</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalarTypedParams(OleDbTransaction transaction, String spName, DataRow dataRow)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            // 如果row有值,存储过程必须初始化
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中
                OleDbParameter[] commandParameters = DbHelper.GetSpParameterSet(transaction.Connection, spName);

                // 分配参数值
                AssignParameterValues(commandParameters, dataRow);

                return DbHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return DbHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
            }
        }
        #endregion
       

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="ConnectionString">A valid connection string for a OleDbConnection</param>
        /// <param name="commandText">The stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">An array of OleDbParamters to be cached</param>
        public static void CacheParameterSet(string commandText, params OleDbParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = ConnectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="ConnectionString">A valid connection string for a OleDbConnection</param>
        /// <param name="commandText">The stored procedure name or T-OleDb command</param>
        /// <returns>An array of OleDbParamters</returns>
        public static OleDbParameter[] GetCachedParameterSet(string commandText)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = ConnectionString + ":" + commandText;

            OleDbParameter[] cachedParameters = paramCache[hashKey] as OleDbParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region Parameter Discovery Functions

        /// <summary>
        /// Retrieves the set of OleDbParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="ConnectionString">A valid connection string for a OleDbConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of OleDbParameters</returns>
        public static OleDbParameter[] GetSpParameterSet(string spName)
        {
            return GetSpParameterSet(spName, false);
        }

        /// <summary>
        /// Retrieves the set of OleDbParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="ConnectionString">A valid connection string for a OleDbConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of OleDbParameters</returns>
        public static OleDbParameter[] GetSpParameterSet(string spName, bool includeReturnValueParameter)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("ConnectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of OleDbParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid OleDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of OleDbParameters</returns>
        internal static OleDbParameter[] GetSpParameterSet(OleDbConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// Retrieves the set of OleDbParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid OleDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of OleDbParameters</returns>
        internal static OleDbParameter[] GetSpParameterSet(OleDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            using (OleDbConnection clonedConnection = (OleDbConnection)((ICloneable)connection).Clone())
            {
                return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of OleDbParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="connection">A valid OleDbConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of OleDbParameters</returns>
        private static OleDbParameter[] GetSpParameterSetInternal(OleDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

            OleDbParameter[] cachedParameters;

            cachedParameters = paramCache[hashKey] as OleDbParameter[];
            if (cachedParameters == null)
            {
                OleDbParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }

            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions

        #region Make OleDbParameters
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>返回一个新的参数</returns>
        public static OleDbParameter MakeInParam(string ParamName, OleDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>返回一个新的参数</returns>
        public static OleDbParameter MakeOutParam(string ParamName, OleDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 创建存储过程参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数描述</param>
        /// <param name="Value">参数值</param>
        /// <returns>返回一个新的参数</returns>
        public static OleDbParameter MakeParam(string ParamName, OleDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OleDbParameter param;

            if (Size > 0)
                param = new OleDbParameter(ParamName, DbType, Size);
            else
                param = new OleDbParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }
        #endregion
    }
}
