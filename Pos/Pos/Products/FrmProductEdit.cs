using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class FrmProductEdit : Form
    {
        private string _productID = string.Empty;

        public FrmProductEdit(string ProductID)
        {
            InitializeComponent();
            this._productID = ProductID;
        }

        #region 保存
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写产品名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (colorName.Text.Trim() == "")
            {
                MessageBox.Show("请填写颜色!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (unitName.Text.Trim() == "")
            {
                MessageBox.Show("请填写单位!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ProductNo = string.Empty;
            if (productNo.Text.Trim() == "")
            {
                DateTime nowTime = DateTime.Now;
                ProductNo = nowTime.ToString("yyyyMMdd") + nowTime.Hour.ToString() + nowTime.Minute.ToString() + nowTime.Second.ToString();
            }
            else
            {
                ProductNo = productNo.Text.Trim();
            }

            decimal CostPrice = costPrice.Text.Trim() == "" ? 0 : Convert.ToDecimal(costPrice.Text.Trim());
            decimal SellPrice = sellPrice.Text.Trim() == "" ? 0 : Convert.ToDecimal(sellPrice.Text.Trim());
            string sqlstring = "UPDATE " + BaseConfigs.GetTablePrefix + "Products SET ProductNo=@ProductNo,Name=@Name,ColorName=@ColorName,UnitName=@UnitName,Spec=@Spec,CostPrice=@CostPrice,SellPrice=@SellPrice,Descn=@Descn WHERE ProductID=@ProductID";
            OleDbParameter[] parms = {
                                       DbHelper.MakeInParam("@ProductNo",OleDbType.VarWChar,32,ProductNo),
                                       DbHelper.MakeInParam("@Name",OleDbType.VarWChar,64,name.Text.Trim()),
                                       DbHelper.MakeInParam("@ColorName",OleDbType.VarWChar,32,colorName.Text.Trim()),
                                       DbHelper.MakeInParam("@UnitName",OleDbType.VarWChar,32,unitName.Text.Trim()),
                                       DbHelper.MakeInParam("@Spec",OleDbType.VarWChar,64,spec.Text.Trim()),
                                       DbHelper.MakeInParam("@CostPrice",OleDbType.Decimal,9,CostPrice),
                                       DbHelper.MakeInParam("@SellPrice",OleDbType.Decimal,9,SellPrice),
                                       DbHelper.MakeInParam("@Descn",OleDbType.VarWChar,255,descn.Text.Trim()),                                       
                                       DbHelper.MakeInParam("@ProductID",OleDbType.Integer,4,Convert.ToInt32( _productID))};

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring, parms);

            MessageBox.Show("修改成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 关闭
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 加载
        private void EditProductForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //加载颜色
            dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Colors ORDER BY ColorID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                colorName.Items.Add(dr["Name"].ToString());
            }

            //加载单位
            dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Units ORDER BY UnitID ASC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                unitName.Items.Add(dr["Name"].ToString());
            }

            //加载产品资料
            DataTable dt2 = DbHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM " + BaseConfigs.GetTablePrefix + "Products WHERE ProductID=" + _productID).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                DataRow rdr = dt2.Rows[0];
                name.Text = rdr["Name"].ToString();
                productNo.Text = rdr["ProductNo"].ToString();
                colorName.Text = rdr["ColorName"].ToString();
                unitName.Text = rdr["UnitName"].ToString();
                descn.Text = rdr["Descn"].ToString();
                costPrice.Text = rdr["CostPrice"].ToString();
                sellPrice.Text = rdr["SellPrice"].ToString();
                spec.Text = rdr["Spec"].ToString();
            }
        }
        #endregion
    }
}
