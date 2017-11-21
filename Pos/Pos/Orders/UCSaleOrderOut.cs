﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Pos.Orders
{
    public partial class UCSaleOrderOut : UserControl
    {
        public UCSaleOrderOut()
        {
            InitializeComponent();
            this.listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);
            this.listView2.MouseClick += new MouseEventHandler(listView2_MouseClick);
        }

        #region 保存
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                if (customerName.Text.Trim() == "")
                {
                    MessageBox.Show("请填写客户!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (saleName.Text.Trim() == "")
                {
                    MessageBox.Show("请填写经手人!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (totalPrice.Text.Trim() == "")
                {
                    MessageBox.Show("请填写应收合计!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (freight.Text.Trim() == "")
                {
                    MessageBox.Show("请填写运费!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OleDbConnection conn = new OleDbConnection(DbHelper.ConnectionString);
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlstring = "SELECT MAX(OrderID) FROM " + BaseConfigs.GetTablePrefix + "SaleOrders";
                        int orderId = Utils.StrToInt(DbHelper.ExecuteScalar(trans, CommandType.Text, sqlstring), 0) + 1;

                        sqlstring = "INSERT INTO " + BaseConfigs.GetTablePrefix + "SaleOrders(OrderID,OrderDate,CustomerName,SaleName,TotalPrice,Freight,OrderType,Descn) VALUES(@OrderID,@OrderDate,@CustomerName,@SaleName,@TotalPrice,@Freight,@OrderType,@Descn)";
                        OleDbParameter[] parms = {
                                                   DbHelper.MakeInParam("@OrderID",OleDbType.Integer,4,orderId),
                                                   DbHelper.MakeInParam("@OrderDate",OleDbType.Date,8,Convert.ToDateTime(Common.FormatDate(dateTimePicker1.Text.Trim()))),
                                                   DbHelper.MakeInParam("@CustomerName",OleDbType.VarWChar,64,customerName.Text.Trim()),
                                                   DbHelper.MakeInParam("@SaleName",OleDbType.VarWChar,64,saleName.Text.Trim()),
                                                   DbHelper.MakeInParam("@TotalPrice",OleDbType.Decimal,9,Convert.ToDecimal(totalPrice.Text.Trim())),
                                                   DbHelper.MakeInParam("@Freight",OleDbType.Decimal,9,Convert.ToDecimal(freight.Text.Trim())),
                                                   DbHelper.MakeInParam("@OrderType",OleDbType.Integer,4,1),
                                                   DbHelper.MakeInParam("@Descn",OleDbType.VarWChar,255,descn.Text.Trim())};

                        DbHelper.ExecuteNonQuery(trans, CommandType.Text, sqlstring, parms);

                        for (int i = 0; i < listView2.Items.Count; i++)
                        {
                            sqlstring = "INSERT INTO " + BaseConfigs.GetTablePrefix + "SaleProducts(OrderID,ProductNo,SellPrice,ColorName,UnitName,Name,Num) VALUES(@OrderID,@ProductNo,@SellPrice,@ColorName,@UnitName,@Name,@Num)";
                            OleDbParameter[] parms1 = {
                                                        DbHelper.MakeInParam("@OrderID",OleDbType.Integer,4,orderId),
                                                        DbHelper.MakeInParam("@ProductNo",OleDbType.VarWChar,32,listView2.Items[i].SubItems[0].Text.Trim()),
                                                        DbHelper.MakeInParam("@SellPrice",OleDbType.Decimal,9,Convert.ToDecimal(listView2.Items[i].SubItems[3].Text.Trim())),
                                                        DbHelper.MakeInParam("@ColorName",OleDbType.VarWChar,32,listView2.Items[i].SubItems[4].Text.Trim()),
                                                        DbHelper.MakeInParam("@UnitName",OleDbType.VarWChar,32,listView2.Items[i].SubItems[5].Text.Trim()),
                                                        DbHelper.MakeInParam("@Name",OleDbType.VarWChar,64,listView2.Items[i].SubItems[1].Text.Trim()),                                                        
                                                        DbHelper.MakeInParam("@Num",OleDbType.Integer,4,Convert.ToInt32(listView2.Items[i].SubItems[2].Text.Trim()))
                                                      };

                            DbHelper.ExecuteNonQuery(trans, CommandType.Text, sqlstring, parms1);

                            sqlstring = "UPDATE " + BaseConfigs.GetTablePrefix + "Products SET Num=Num+" + listView2.Items[i].SubItems[2].Text.Trim() + " WHERE ProductNo='" + listView2.Items[i].SubItems[0].Text.Trim() + "'";

                            DbHelper.ExecuteNonQuery(trans, CommandType.Text, sqlstring);
                        }

                        trans.Commit();

                        MessageBox.Show("添加成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new ApplicationException(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先增加产品!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        #endregion


        #region 查询产品
        private void searchButton_Click(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            //清空数据
            listView1.Items.Clear();

            try
            {
                //查询数据库
                string sqlstring = "SELECT ProductNo,Name,ColorName,UnitName,Num,CostPrice,SellPrice FROM " + BaseConfigs.GetTablePrefix + "Products WHERE 1=1";
                if (keywords.Text.Trim() != "")
                {
                    sqlstring += " AND Name LIKE '%" + keywords.Text.Trim() + "%'";
                }

                sqlstring += " ORDER BY ProductID ASC";

                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];

                //绑定数据
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["ProductNo"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add(dr["ColorName"].ToString());
                        l.SubItems.Add(dr["UnitName"].ToString());
                        l.SubItems.Add(dr["Num"].ToString());
                        l.SubItems.Add(dr["CostPrice"].ToString());
                        l.SubItems.Add(dr["SellPrice"].ToString());
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

        #region 产品列表鼠标双击事件
        private void listView1_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string sqlstring = "SELECT * FROM " + BaseConfigs.GetTablePrefix + "Products WHERE ProductNo='" + listView1.SelectedItems[0].SubItems[0].Text.Trim() + "'";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (Convert.ToInt32(dr["Num"]) > 0)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["ProductNo"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add("1");
                        l.SubItems.Add(dr["SellPrice"].ToString());
                        l.SubItems.Add(dr["ColorName"].ToString());
                        l.SubItems.Add(dr["UnitName"].ToString());
                        listView2.Items.Add(l);
                    }
                    else
                    {
                        MessageBox.Show("已经没有库存了!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                TotalPrice();
            }
            else
            {
                MessageBox.Show("请选择项!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region 产品销售鼠标右击事件
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Control.MousePosition.X, Control.MousePosition.Y);
            }
        }
        #endregion

        #region 产品销售鼠标右击修改数量
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string retVal = InputBox.Show("修改数量", "请输入要修改的数量。按Enter确定，Esc退出。", listView2.SelectedItems[0].SubItems[2].Text.Trim());
            if (retVal != "")
            {
                listView2.SelectedItems[0].SubItems[2].Text = retVal;
            }
            TotalPrice();
        }
        #endregion

        #region 产品销售鼠标右击修改售价
        private void ToolStripMenuItem0_Click(object sender, EventArgs e)
        {
            string retVal = InputBox.Show("修改售价", "请输入要修改的价格。按Enter确定，Esc退出。", listView2.SelectedItems[0].SubItems[3].Text.Trim());
            if (retVal != "")
            {
                listView2.SelectedItems[0].SubItems[3].Text = retVal;
            }
            TotalPrice();
        }
        #endregion

        #region 产品销售鼠标右击删除
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listView2.SelectedItems[0].Remove();
            TotalPrice();
        }
        #endregion

        #region 产品销售鼠标右击清空
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            TotalPrice();
        }
        #endregion

        #region 插入产品到销售单
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string sqlstring = "SELECT * FROM " + BaseConfigs.GetTablePrefix + "Products WHERE ProductNo='" + listView1.SelectedItems[0].SubItems[0].Text.Trim() + "'";
                DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (Convert.ToInt32(dr["Num"]) > 0)
                    {
                        ListViewItem l = new ListViewItem();
                        l.SubItems.Clear();
                        l.SubItems[0].Text = dr["ProductNo"].ToString();
                        l.SubItems.Add(dr["Name"].ToString());
                        l.SubItems.Add("1");
                        l.SubItems.Add(dr["SellPrice"].ToString());
                        l.SubItems.Add(dr["ColorName"].ToString());
                        l.SubItems.Add(dr["UnitName"].ToString());
                        listView2.Items.Add(l);
                    }
                    else
                    {
                        MessageBox.Show("已经没有库存了!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                TotalPrice();
            }
            else
            {
                MessageBox.Show("请选择要插入的项!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region 新增产品
        private void addButton_Click(object sender, EventArgs e)
        {
            FrmProductAdd form1 = new FrmProductAdd();
            form1.ShowInTaskbar = false;
            form1.ShowDialog();
        }
        #endregion

        #region 应付合计
        private void TotalPrice()
        {
            decimal total = 0;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                total += Convert.ToDecimal(listView2.Items[i].SubItems[3].Text.Trim()) * Convert.ToInt32(listView2.Items[i].SubItems[2].Text.Trim());
            }
            totalPrice.Text = total.ToString();
        }
        #endregion

        private void UCSaleOrderOut_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Users ORDER BY UserID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                saleName.Items.Add(dr["Name"].ToString());
            }

            dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Customers ORDER BY CustID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                customerName.Items.Add(dr["Name"].ToString());
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            this.listView1.Clear();
            this.listView2.Clear();
            this.saleName.SelectedIndex = -1;
            this.customerName.SelectedIndex = -1;
            this.descn.Text = "";
            this.totalPrice.Text = "0";
            this.freight.Text = "0";
            this.keywords.Text = "";
        }
    }
}
