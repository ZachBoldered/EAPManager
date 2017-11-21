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
    public partial class FrmProductSearch : Form
    {
        public FrmProductSearch()
        {
            InitializeComponent();
        }

        #region 查询
        private void searchButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("SELECT ProductID,ProductNo,Name,ColorName,UnitName,Num,CostPrice,SellPrice,JobPrice FROM " + BaseConfigs.GetTablePrefix + "Products WHERE 1=1");
            if (productName.Text.Trim() != "")
            {
                sb.Append(" AND Name LIKE '%" + productName.Text.Trim() + "%'");
            }

            if (productNo.Text.Trim() != "")
            {
                sb.Append(" AND ProductNo LIKE '%" + productNo.Text.Trim() + "%'");
            }

            if (color.Text.Trim() != "")
            {
                sb.Append(" AND ColorName LIKE '%" + color.Text.Trim() + "%'");
            }

            sb.Append(" ORDER BY ProductID ASC");

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
        private void SearchProductForm_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Colors ORDER BY ColorID").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                color.Items.Add(dr["Name"].ToString());
            }
        }
        #endregion
    }
}
