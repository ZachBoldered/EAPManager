using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Pos.Report
{
    public partial class UCProductsPrice : UserControl
    {
        public UCProductsPrice()
        {
            InitializeComponent();
        }


        private DataTable getData()
        {
            try
            {
                StringBuilder sqlsb = new StringBuilder();
                sqlsb.Append("SELECT a.ProductID,a.ProductNo,a.Name,a.ColorName,a.UnitName,a.Num,a.CostPrice,a.SellPrice,a.JobPrice,min(b.SellPrice) as LowSellPrice,max(b.SellPrice) as HighSellPrice,min(c.CostPrice) as LowCostPrice,max(c.CostPrice) as HighCostPrice FROM ((" + BaseConfigs.GetTablePrefix + "Products as a ");
                sqlsb.Append(" left join " + BaseConfigs.GetTablePrefix + "SaleProducts as b on a.ProductNo = b.ProductNo )  left join " + BaseConfigs.GetTablePrefix + "BuyProducts as c on a.ProductNo = c.ProductNo )  ");
                if (this.txtProductFilter.Text != "")
                {
                    sqlsb.Append(" where a.ProductNo like '%" + txtProductFilter.Text.Trim() + "%' or a.Name like '%" + txtProductFilter.Text.Trim() + "%'");
                }
                sqlsb.Append(" group by a.ProductID,a.ProductNo,a.Name,a.ColorName,a.UnitName,a.Num,a.CostPrice,a.SellPrice,a.JobPrice ");
                return DbHelper.ExecuteDataset(CommandType.Text, sqlsb.ToString()).Tables[0];
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.gridControl1.DataSource = getData();
        }

       
    }
}
