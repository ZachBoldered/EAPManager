using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class FrmBuyOrderSearch1 : Form
    {
        public FrmBuyOrderSearch1()
        {
            InitializeComponent();
        }

        #region 查询
        private void searchButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("SELECT OrderID,OrderDate,SupplierName,BuyName,Freight,TotalPrice FROM " + BaseConfigs.GetTablePrefix + "BuyOrders WHERE OrderType=1");
            sb.Append(" AND OrderDate BETWEEN #" + Common.FormatDate(startDate.Text.Trim()) + "# AND #" + Common.FormatDate(endDate.Text.Trim()) + "#");
            if (supplierName.Text.Trim() != "")
            {
                sb.Append(" AND SupplierName LIKE '%" + supplierName.Text.Trim() + "%'");
            }

            if (buyName.Text.Trim() != "")
            {
                sb.Append(" AND BuyName LIKE '%" + buyName.Text.Trim() + "%'");
            }
            sb.Append(" ORDER BY OrderDate DESC");

            Common.sqlstring = sb.ToString();
        }
        #endregion

        #region 关闭
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 加载数据
        private void SearchBuyOrderForm1_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Suppliers ORDER BY SupplierID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                supplierName.Items.Add(dr["Name"].ToString());
            }

            DataTable dt1 = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Users ORDER BY UserID ASC").Tables[0];
            foreach (DataRow dr in dt1.Rows)
            {
                buyName.Items.Add(dr["Name"].ToString());
            }
        }
        #endregion
    }
}
