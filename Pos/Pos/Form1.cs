using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Pos
{
    public partial class Form1 : Form
    {    
        private string tableName = string.Empty; //表名

        public Form1()
        {
            InitializeComponent();
            //通过反射动态加载BSE.Windows.Forms.dll 中的信息
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("BSE.Windows.Forms.dll");
            Type[] types = assembly.GetTypes();  //获取该程序集中定义的类型
            Type typeOfClass = null;
            typeOfClass = typeof(System.Windows.Forms.ToolStripProfessionalRenderer);   
    
        }

        #region 客户资料

        private void 客户资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindCustomers();
        }

         /// <summary>
        /// 绑定客户资料
        /// </summary>
        private void BindCustomers()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("客户名称", 200);
            listView1.Columns.Add("联系人", 100);
            listView1.Columns.Add("联系电话", 100);
            listView1.Columns.Add("传真", 100);
            listView1.Columns.Add("手机", 100);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "Customers";

                //查询数据库
                string sqlstring = "SELECT CustID,Name,LinkMan,Tel,Fax,Mob FROM " + BaseConfigs.GetTablePrefix + "Customers ORDER BY CustID";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["CustID"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add(dr["LinkMan"].ToString());
                        l.SubItems.Add(dr["Tel"].ToString());
                        l.SubItems.Add(dr["Fax"].ToString());
                        l.SubItems.Add(dr["Mob"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }   

        private void 添加客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerAdd frmCusAdd = new FrmCustomerAdd();
            frmCusAdd.ShowInTaskbar = false;
            if (frmCusAdd.ShowDialog() == DialogResult.OK)
            {
                this.tabControl1.SelectedTab = this.tabPage1;
                BindCustomers();
            }
        }

        #endregion
        
        #region 供应商资料
        private void 供应商资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindVendors();
        }

        /// <summary>
        /// 绑定供应商资料
        /// </summary>
        private void BindVendors()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("供应商名称", 200);
            listView1.Columns.Add("联系人", 100);
            listView1.Columns.Add("联系电话", 100);
            listView1.Columns.Add("传真", 100);
            listView1.Columns.Add("手机", 100);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "Vendors";

                //查询数据库
                string sqlstring = "SELECT SupplierID,Name,LinkMan,Tel,Fax,Mob FROM " + BaseConfigs.GetTablePrefix + "Suppliers ORDER BY SupplierID";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["SupplierID"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add(dr["LinkMan"].ToString());
                        l.SubItems.Add(dr["Tel"].ToString());
                        l.SubItems.Add(dr["Fax"].ToString());
                        l.SubItems.Add(dr["Mob"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private void 添加供应商ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendorAdd frmVenAdd = new FrmVendorAdd();
            frmVenAdd.ShowInTaskbar = false;
            //frmVenAdd.ShowDialog();
            if (frmVenAdd.ShowDialog() == DialogResult.OK)
            {
                this.tabControl1.SelectedTab = this.tabPage1;
                BindVendors();
            }
        }
        #endregion
        
        #region 商品资料
        private void 商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductSearch frmPSearch = new FrmProductSearch();
            frmPSearch.ShowInTaskbar = false;
            if (frmPSearch.ShowDialog() == DialogResult.OK)
            {
                BindProducts();
            }
        }


        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductAdd frmPAdd = new FrmProductAdd();
            frmPAdd.ShowInTaskbar = false;
            if (frmPAdd.ShowDialog() == DialogResult.OK)
            {
                BindProducts();
            }
        }

        /// <summary>
        /// 绑定产品资料
        /// </summary>
        private void BindProducts()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("产品编号", 100);
            listView1.Columns.Add("产品名称", 200);
            listView1.Columns.Add("颜色", 80);
            listView1.Columns.Add("单位", 80);
            listView1.Columns.Add("库存数量", 80);
            listView1.Columns.Add("进价", 80);
            listView1.Columns.Add("零售价", 80);
            listView1.Columns.Add("批发价", 80);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "Products";

                //查询数据库
                string sqlstring = string.Empty;
                if (Common.sqlstring == "")
                {
                    sqlstring = "SELECT ProductID,ProductNo,Name,ColorName,UnitName,Num,CostPrice,SellPrice,JobPrice FROM " + BaseConfigs.GetTablePrefix + "Products ORDER BY ProductID ASC";
                }
                else
                {
                    sqlstring = Common.sqlstring;
                }
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["ProductID"].ToString();
                        l.SubItems.Add(dr["ProductNo"].ToString());
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add(dr["ColorName"].ToString());
                        l.SubItems.Add(dr["UnitName"].ToString());
                        l.SubItems.Add(dr["Num"].ToString());
                        l.SubItems.Add(dr["CostPrice"].ToString());
                        l.SubItems.Add(dr["SellPrice"].ToString());
                        l.SubItems.Add(dr["JobPrice"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion
        
        #region 计量单位
        private void 计量单位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindUnits();
        }

        private void 添加计量单位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductUnitAdd frmPUnitAdd = new FrmProductUnitAdd();
            frmPUnitAdd.ShowInTaskbar = false;
            frmPUnitAdd.ShowDialog();
        }

        /// <summary>
        /// 绑定计量单位
        /// </summary>
        private void BindUnits()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("计量单位名称", 100);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "Units";

                //查询数据库
                string sqlstring = "SELECT UnitID,Name FROM " + BaseConfigs.GetTablePrefix + "Units ORDER BY UnitID";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["UnitID"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion
        
        #region 商品类别
        private void 商品类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindColors();
        }

        private void 添加商品类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmProductColorAdd frmPColorAdd = new FrmProductColorAdd();
            frmPColorAdd.ShowInTaskbar = false;
            if (frmPColorAdd.ShowDialog() == DialogResult.OK)
            {
                BindColors();
            }
        }

        /// <summary>
        /// 绑定颜色
        /// </summary>
        private void BindColors()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("颜色名称", 100);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "Colors";

                //查询数据库
                string sqlstring = "SELECT ColorID,Name FROM " + BaseConfigs.GetTablePrefix + "Colors ORDER BY ColorID";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["ColorID"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion
        
        #region 人员资料
        private void 员工查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindUsers();
        }


        private void 添加人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsersAdd frmUAdd = new FrmUsersAdd();
            frmUAdd.ShowInTaskbar = false;
            if (frmUAdd.ShowDialog() == DialogResult.OK)
            {
                BindUsers();
            }
        }

        /// <summary>
        /// 绑定员工资料
        /// </summary>
        private void BindUsers()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("员工姓名", 80);
            listView1.Columns.Add("联系地址", 200);
            listView1.Columns.Add("联系电话", 100);
            listView1.Columns.Add("手机", 100);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "Users";

                //查询数据库
                string sqlstring = "SELECT UserID,Name,Address,Tel,Mob FROM " + BaseConfigs.GetTablePrefix + "Users ORDER BY UserID";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["UserID"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add(dr["Address"].ToString());
                        l.SubItems.Add(dr["Tel"].ToString());
                        l.SubItems.Add(dr["Mob"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion
        
        #region 采购入库
        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuyOrderSearch frmBOsearch = new FrmBuyOrderSearch();
            frmBOsearch.ShowInTaskbar = false;
            if (frmBOsearch.ShowDialog() == DialogResult.OK)
            {
                BindBuyOrders();
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            this.panel4.Text = "采购入库单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCBuyOrderAdd());
        }

        /// <summary>
        /// 绑定进货单
        /// </summary>
        private void BindBuyOrders()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("采购日期", 100);
            listView1.Columns.Add("供应商名称", 200);
            listView1.Columns.Add("进货人", 100);
            listView1.Columns.Add("运费", 80);
            listView1.Columns.Add("合计", 80);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "BuyOrders";

                //查询数据库               
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, Common.sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["OrderID"].ToString();
                        l.SubItems.Add(String.Format("{0:yyyy-MM-dd}", dr["OrderDate"]));
                        l.SubItems.Add(dr["SupplierName"].ToString());
                        l.SubItems.Add(dr["BuyName"].ToString());
                        l.SubItems.Add(dr["Freight"].ToString());
                        l.SubItems.Add(dr["TotalPrice"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion

        #region 采购出库
        private void 查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBuyOrderSearch1 form1 = new FrmBuyOrderSearch1();
            form1.ShowInTaskbar = false;
            if (form1.ShowDialog() == DialogResult.OK)
            {
                BindBuyOrders1();
            }
        }

        private void 添加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FrmBuyOrderAdd1 form1 = new FrmBuyOrderAdd1();
            //form1.ShowInTaskbar = false;
            //form1.ShowDialog();
            this.panel4.Text = "采购出库单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCBuyOrderOut());
        }

        /// <summary>
        /// 绑定采购退货单
        /// </summary>
        private void BindBuyOrders1()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("采购日期", 100);
            listView1.Columns.Add("供应商名称", 200);
            listView1.Columns.Add("经手人", 100);
            listView1.Columns.Add("运费", 80);
            listView1.Columns.Add("合计", 80);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "BuyOrders";

                //查询数据库               
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, Common.sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["OrderID"].ToString();
                        l.SubItems.Add(String.Format("{0:yyyy-MM-dd}", dr["OrderDate"]));
                        l.SubItems.Add(dr["SupplierName"].ToString());
                        l.SubItems.Add(dr["BuyName"].ToString());
                        l.SubItems.Add(dr["Freight"].ToString());
                        l.SubItems.Add(dr["TotalPrice"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion

        #region 销售单
        private void 查询ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmSaleOrderSearch form1 = new FrmSaleOrderSearch();
            form1.ShowInTaskbar = false;
            if (form1.ShowDialog() == DialogResult.OK)
            {
                BindSaleOrders();
            }
        }

        private void 添加ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //FrmSaleOrderAdd form1 = new FrmSaleOrderAdd();
            //form1.ShowInTaskbar = false;
            //form1.ShowDialog();
            this.panel4.Text = "销售单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCSaleOrderAdd());
        }
        /// <summary>
        /// 绑定销售单
        /// </summary>
        private void BindSaleOrders()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("销售日期", 100);
            listView1.Columns.Add("客户名称", 120);
            listView1.Columns.Add("经手人", 100);
            listView1.Columns.Add("运费", 80);
            listView1.Columns.Add("合计", 80);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "SaleOrders";

                //查询数据库               
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, Common.sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["OrderID"].ToString();
                        l.SubItems.Add(String.Format("{0:yyyy-MM-dd}", dr["OrderDate"]));
                        l.SubItems.Add(dr["CustomerName"].ToString());
                        l.SubItems.Add(dr["SaleName"].ToString());
                        l.SubItems.Add(dr["Freight"].ToString());
                        l.SubItems.Add(dr["TotalPrice"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion

        #region 退货单
        private void 查询ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmSaleOrderSearch1 form1 = new FrmSaleOrderSearch1();
            form1.ShowInTaskbar = false;
            if (form1.ShowDialog() == DialogResult.OK)
            {
                BindSaleOrders1();
            }
        }

        private void 添加ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //FrmSaleOrderAdd1 form1 = new FrmSaleOrderAdd1();
            //form1.ShowInTaskbar = false;
            //form1.ShowDialog();
            this.panel4.Text = "退货单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCSaleOrderOut());
        }
        /// <summary>
        /// 绑定销售退货单
        /// </summary>
        private void BindSaleOrders1()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView1.Columns.Clear();
            listView1.Columns.Add("系统编号", 80);
            listView1.Columns.Add("销售日期", 100);
            listView1.Columns.Add("客户名称", 120);
            listView1.Columns.Add("经手人", 100);
            listView1.Columns.Add("运费", 80);
            listView1.Columns.Add("合计", 80);

            //清空数据
            listView1.Items.Clear();

            try
            {
                tableName = "SaleOrders";

                //查询数据库               
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, Common.sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["OrderID"].ToString();
                        l.SubItems.Add(String.Format("{0:yyyy-MM-dd}", dr["OrderDate"]));
                        l.SubItems.Add(dr["CustomerName"].ToString());
                        l.SubItems.Add(dr["SaleName"].ToString());
                        l.SubItems.Add(dr["Freight"].ToString());
                        l.SubItems.Add(dr["TotalPrice"].ToString());
                        listView1.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        #endregion


        #region 工具栏操作

        //删除
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = DialogResult.Cancel;
                if (tableName.Contains("Order"))
                {
                    MessageBox.Show("不能删除业务操作中已生成的记录！");
                }
                else
                {
                    result = MyMessageBox.MessageBoxByOKCancel("确定删除该项？");
                }
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                    try
                    {
                        switch (tableName)
                        {
                            case "Customers":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Customers WHERE CustID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindCustomers();
                                return;
                            case "Vendors":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Suppliers WHERE SupplierID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindVendors();
                                return;
                            case "Units":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Units WHERE UnitID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindUnits();
                                return;
                            case "Colors":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Colors WHERE ColorID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindColors();
                                return;
                            case "Users":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Users WHERE UserID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindUsers();
                                return;
                            case "Products":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Products WHERE ProductID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindProducts();
                                return;
                            case "StockProducts":
                                DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + BaseConfigs.GetTablePrefix + "Products WHERE ProductID=" + listView1.SelectedItems[0].SubItems[0].Text.Trim());
                                BindStockProducts();
                                return;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
            }
            else
            {
                MessageBox.Show("请选择要删除的项!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

            //退出系统
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //搜索商品

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmProductSearch form1 = new FrmProductSearch();
            form1.ShowInTaskbar = false;
            if (form1.ShowDialog() == DialogResult.OK)
            {
                BindProducts();
            }
        }

        //新增商品
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmProductAdd form1 = new FrmProductAdd();
            form1.ShowInTaskbar = false;
            form1.ShowDialog();
        }


        //库存警告
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            BindStockProducts();
        }

        /// <summary>
        /// 绑定产品库存
        /// </summary>
        private void BindStockProducts()
        {
            this.tabControl1.SelectedTab = this.tabPage1;
            //添加头部信息
            listView2.Columns.Clear();
            listView2.Columns.Add("系统编号", 80);
            listView2.Columns.Add("产品编号", 100);
            listView2.Columns.Add("产品名称", 200);
            listView2.Columns.Add("颜色", 80);
            listView2.Columns.Add("单位", 80);
            listView2.Columns.Add("库存数量", 80);
            listView2.Columns.Add("进价", 80);
            listView2.Columns.Add("零售价", 80);
            listView2.Columns.Add("批发价", 80);

            //清空数据
            listView2.Items.Clear();

            try
            {
                tableName = "StockProducts";

                string sqlstring = "SELECT ProductID,ProductNo,Name,ColorName,UnitName,Num,CostPrice,SellPrice,JobPrice FROM " + BaseConfigs.GetTablePrefix + "Products WHERE Num<=1";
                //查询数据库
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["ProductID"].ToString();
                        l.SubItems.Add(dr["ProductNo"].ToString());
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add(dr["ColorName"].ToString());
                        l.SubItems.Add(dr["UnitName"].ToString());
                        l.SubItems.Add(dr["Num"].ToString());
                        l.SubItems.Add(dr["CostPrice"].ToString());
                        l.SubItems.Add(dr["SellPrice"].ToString());
                        l.SubItems.Add(dr["JobPrice"].ToString());
                        listView2.Items.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        //采购进货
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //FrmBuyOrderAdd FrmBOAdd = new FrmBuyOrderAdd();
            //FrmBOAdd.ShowInTaskbar = false;
            //FrmBOAdd.ShowDialog();
            this.panel4.Text = "采购入库单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCBuyOrderAdd());
        }

        //销售开单
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //FrmSaleOrderAdd form1 = new FrmSaleOrderAdd();
            //form1.ShowInTaskbar = false;
            //form1.ShowDialog();
            this.panel4.Text = "销售单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCSaleOrderAdd());
        }
        
        //采购出库
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.panel4.Text = "采购出库单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCBuyOrderOut());
        }
        #endregion


        #region 树形按钮

        private void treeView1_Click(object sender, EventArgs e)
        {
            TreeNode clickNode = treeView1.GetNodeAt(this.treeView1.PointToClient(Cursor.Position));
            this.tabControl1.SelectedTab = this.tabPage1;

            if (clickNode != null)
            {
                Rectangle r = clickNode.Bounds;
                if (r.Contains(this.treeView1.PointToClient(Cursor.Position)))
                {
                    switch (clickNode.Tag.ToString())
                    {
                        case "Vendors":
                            BindVendors();
                            return;
                        case "Customers":
                            BindCustomers();
                            return;
                        case "Products":
                            FrmProductSearch form1 = new FrmProductSearch();
                            form1.ShowInTaskbar = false;
                            if (form1.ShowDialog() == DialogResult.OK)
                            {
                                BindProducts();
                            }
                            return;
                        case "Units":
                            BindUnits();
                            return;
                        case "Colors":
                            BindColors();
                            return;
                        case "Users":
                            BindUsers();
                            return;
                    }
                }
            }
        }

        #endregion


        #region 动态绑定panel的可视化
        private void SetViewMenuItems()
        {
            this.视图RToolStripMenuItem.DropDownItems.Clear();
            ArrayList basePanels = BSE.Windows.Forms.PanelSettingsManager.FindPanels(true, this.Controls);
            foreach (BSE.Windows.Forms.BasePanel basePanel in basePanels)
            {
                BSE.Windows.Forms.Panel panel = basePanel as BSE.Windows.Forms.Panel;
                if ((panel != null) && ((panel.Dock != DockStyle.Fill) || (panel.Dock != DockStyle.None)) && (panel.ShowCloseIcon == true))
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = panel.Text;
                    menuItem.Image = panel.Image;
                    menuItem.Tag = panel;
                    //添加点击事件
                    menuItem.Click += new EventHandler(ViewMenuItemsClick);
                    if (panel.Visible == true)
                    {
                        menuItem.Checked = true;
                    }
                    this.视图RToolStripMenuItem.DropDownItems.Add(menuItem);
                }
            }
        }
        //点击事件定义
        private void ViewMenuItemsClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                BSE.Windows.Forms.Panel panel = menuItem.Tag as BSE.Windows.Forms.Panel;
                if (panel != null)
                {
                    panel.Visible = !panel.Visible;
                }
            }
        }
        //panel关闭公共事件
        private void panelCloseClick(object sender, EventArgs e)
        {
            BSE.Windows.Forms.Panel panel = sender as BSE.Windows.Forms.Panel;
            if (panel != null)
            {
                panel.Visible = false;
                SetViewMenuItems();
            }
        }
        //panel可视性改变公共事件
        private void panelVisibleChanged(object sender, EventArgs e)
        {
            BSE.Windows.Forms.Panel panel = sender as BSE.Windows.Forms.Panel;
            if (panel != null)
            {
                SetViewMenuItems();
            }
        }
        #endregion

        //加载
        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            //添加头部信息
            listView2.Columns.Clear();
            listView2.Columns.Add("系统编号", 80);
            listView2.Columns.Add("产品编号", 100);
            listView2.Columns.Add("产品名称", 200);
            listView2.Columns.Add("颜色", 80);
            listView2.Columns.Add("单位", 80);
            listView2.Columns.Add("库存数量", 80);
            listView2.Columns.Add("进价", 80);
            listView2.Columns.Add("零售价", 80);
            listView2.Columns.Add("批发价", 80);

            //清空数据
            listView2.Items.Clear();
            SetViewMenuItems();

            try
            {
                tableName = "Products";

                UpdateForm form1 = new UpdateForm();
                form1.ShowInTaskbar = false;
                form1.ShowDialog();

                //查询数据库
                DataTable dt = form1.dt;

                    //绑定数据
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ListViewItem l = new ListViewItem();
                            l.SubItems.Clear();
                            l.SubItems[0].Text = dr["ProductID"].ToString();
                            l.SubItems.Add(dr["ProductNo"].ToString());
                            l.SubItems.Add(dr["Name"].ToString());
                            l.SubItems.Add(dr["ColorName"].ToString());
                            l.SubItems.Add(dr["UnitName"].ToString());
                            l.SubItems.Add(dr["Num"].ToString());
                            l.SubItems.Add(dr["CostPrice"].ToString());
                            l.SubItems.Add(dr["SellPrice"].ToString());
                            l.SubItems.Add(dr["JobPrice"].ToString());
                            listView2.Items.Add(l);
                        }
                    }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.panel4.Text = "退货单录入";
            this.tabControl1.SelectedTab = this.tabPage2;
            panel5.Controls.Clear();
            panel5.Controls.Add(new Pos.Orders.UCSaleOrderOut());
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("我操");
            switch (tableName)
            {
                case "Products":
                    FrmProductEdit frmPEdit = new FrmProductEdit(listView1.SelectedItems[0].Text.ToString());
                    frmPEdit.ShowInTaskbar = false;
                    if (frmPEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindProducts();
                    }
                    break;
                case "Vendors":
                    FrmVendorEdit frmVEdit = new FrmVendorEdit(listView1.SelectedItems[0].Text.ToString());
                    frmVEdit.ShowInTaskbar = false;
                    if (frmVEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindVendors();
                    }
                    break;
                case "Customers":
                    FrmCustomerEdit frmCEdit = new FrmCustomerEdit(listView1.SelectedItems[0].Text.ToString());
                    frmCEdit.ShowInTaskbar = false;
                    if (frmCEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindCustomers();
                    }
                    break;
                case "Units":
                    FrmProductUnitEdit frmPUEdit = new FrmProductUnitEdit(listView1.SelectedItems[0].Text.ToString());
                    frmPUEdit.ShowInTaskbar = false;
                    if (frmPUEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindUnits();
                    }
                    break;
                case "Colors":
                    FrmProductColorEdit frmPCEdit = new FrmProductColorEdit(listView1.SelectedItems[0].Text.ToString());
                    frmPCEdit.ShowInTaskbar = false;
                    if (frmPCEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindColors();
                    }
                    break;
                case "Users":
                    FrmUserEdit frmUEdit = new FrmUserEdit(listView1.SelectedItems[0].Text.ToString());
                    frmUEdit.ShowInTaskbar = false;
                    if (frmUEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindUsers();
                    }
                    break;
                default:
                    return;
            }
        }

        #region 报表
        private void 商品价格明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel6.Text = "商品价格明细";
            this.tabControl1.SelectedTab = this.tabPage3;
            panel7.Controls.Clear();
            panel7.Controls.Add(new Pos.Report.UCProductsPrice());
        }

        private void 商品进货明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel6.Text = "商品进货明细";
            this.tabControl1.SelectedTab = this.tabPage3;
            panel7.Controls.Clear();
            panel7.Controls.Add(new Pos.Orders.BuyOrderSearch());
        }
        #endregion

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("您当前有权限进行操作，进一步的帮助信息请查看软件目录下的帮助文件。");
        }

        private void 商品交易明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel6.Text = "商品交易明细";
            this.tabControl1.SelectedTab = this.tabPage3;
            panel7.Controls.Clear();
            panel7.Controls.Add(new Pos.Orders.SaleOrderSearch());
        }

        private void 当前库存明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel6.Text = "当前库存明细";
            this.tabControl1.SelectedTab = this.tabPage3;
            panel7.Controls.Clear();
            panel7.Controls.Add(new Pos.Products.Storage());
        }
    }
 }

