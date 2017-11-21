using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Pos
{
    public class BaseConfigs
    {
        /// <summary>
        /// 返回数据库连接串
        /// </summary>
        public static string GetConnectionString
        {
            get
            {
                return "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + ConfigurationManager.AppSettings["DBPath"].ToString() + ";Persist Security Info=True;";
            }
        }

        /// <summary>
        /// 返回表前缀
        /// </summary>
        public static string GetTablePrefix
        {
            get
            {
                return ConfigurationManager.AppSettings["TablePrefix"].ToString();
            }
        }
    }
}
