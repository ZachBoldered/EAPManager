using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class FrmSaleOrderSearch : Form
    {
        public FrmSaleOrderSearch()
        {
            InitializeComponent();
        }

        #region 关闭
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查询
        private void searchButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("SELECT OrderID,OrderDate,CustomerName,SaleName,Freight,TotalPrice FROM " + BaseConfigs.GetTablePrefix + "SaleOrders WHERE OrderType=0");
            sb.Append(" AND OrderDate BETWEEN #" + Common.FormatDate(startDate.Text.Trim()) + "# AND #" + Common.FormatDate(endDate.Text.Trim()) + "#");
            if (customerName.Text.Trim() != "")
            {
                sb.Append(" AND CustomerName LIKE '%" + customerName.Text.Trim() + "%'");
            }

            if (saleName.Text.Trim() != "")
            {
                sb.Append(" AND SaleName LIKE '%" + saleName.Text.Trim() + "%'");
            }
            sb.Append(" ORDER BY OrderDate DESC");

            Common.sqlstring = sb.ToString();
        }
        #endregion

        #region 加载数据
        private void SearchSaleOrderForm_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Customers ORDER BY CustID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                customerName.Items.Add(dr["Name"].ToString());
            }

            dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Users ORDER BY UserID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                saleName.Items.Add(dr["Name"].ToString());
            }
        }
        #endregion
    }
}
