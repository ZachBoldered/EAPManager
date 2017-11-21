﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pos.Orders
{
    public partial class SaleOrderSearch : UserControl
    {
        public SaleOrderSearch()
        {
            InitializeComponent();
        }

        private void SaleOrderSearch_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Products").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                this.comboBox1.Items.Add(dr["Name"].ToString());
            }
            DataTable dt1 = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Users").Tables[0];
            foreach (DataRow dr in dt1.Rows)
            {
                this.comboBox2.Items.Add(dr["Name"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                DataTable dts = DbHelper.ExecuteDataset(CommandType.Text, "SELECT OrderID,ProductNo,Name,ColorName,UnitName,Num,SellPrice FROM " + BaseConfigs.GetTablePrefix + "SaleProducts ORDER BY OrderID ASC").Tables[0];
                this.dataGridView1.DataSource = dts;
            }
            else
            {
                DataTable dts = DbHelper.ExecuteDataset(CommandType.Text, "SELECT OrderID,ProductNo,Name,ColorName,UnitName,Num,SellPrice FROM " + BaseConfigs.GetTablePrefix + "SaleProducts WHERE Name='" + this.comboBox1.Text.ToString().Trim() + "'").Tables[0];
                this.dataGridView1.DataSource = dts;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.Text == "")
            {
                DataTable dts1 = DbHelper.ExecuteDataset(CommandType.Text, "SELECT OrderID,OrderDate,CustomerName,SaleName,TotalPrice FROM " + BaseConfigs.GetTablePrefix + "SaleOrders").Tables[0];
                this.dataGridView2.DataSource = dts1;
            }
            else
            {
                DataTable dts1 = DbHelper.ExecuteDataset(CommandType.Text, "SELECT OrderID,OrderDate,CustomerName,SaleName,TotalPrice FROM " + BaseConfigs.GetTablePrefix + "SaleOrders WHERE SaleName='" + this.comboBox2.Text.ToString().Trim() + "' AND OrderDate>=#" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "#").Tables[0];
                this.dataGridView2.DataSource = dts1;
            }
        }
    }
}
