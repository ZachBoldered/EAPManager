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
    public partial class FrmProductAdd : Form
    {
        public FrmProductAdd()
        {
            InitializeComponent();
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

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT ProductID FROM " + BaseConfigs.GetTablePrefix + "Products WHERE Name='" + name.Text.Trim() + "' OR ProductNo='" + ProductNo + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("产品名称或产品编号重复!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal CostPrice = costPrice.Text.Trim() == "" ? 0 : Convert.ToDecimal(costPrice.Text.Trim());
            decimal SellPrice = sellPrice.Text.Trim() == "" ? 0 : Convert.ToDecimal(sellPrice.Text.Trim());
            string sqlstring = "INSERT INTO " + BaseConfigs.GetTablePrefix + "Products(ProductNo,Name,ColorName,UnitName,Spec,CostPrice,SellPrice,Descn) VALUES(@ProductNo,@Name,@ColorName,@UnitName,@Spec,@CostPrice,@SellPrice,@Descn)";
            OleDbParameter[] parms = {
                                       DbHelper.MakeInParam("@ProductNo",OleDbType.VarWChar,32,ProductNo),
                                       DbHelper.MakeInParam("@Name",OleDbType.VarWChar,64,name.Text.Trim()),
                                       DbHelper.MakeInParam("@ColorName",OleDbType.VarWChar,32,colorName.Text.Trim()),
                                       DbHelper.MakeInParam("@UnitName",OleDbType.VarWChar,32,unitName.Text.Trim()),
                                       DbHelper.MakeInParam("@Spec",OleDbType.VarWChar,64,spec.Text.Trim()),
                                       DbHelper.MakeInParam("@CostPrice",OleDbType.Decimal,9,CostPrice),
                                       DbHelper.MakeInParam("@SellPrice",OleDbType.Decimal,9,SellPrice),
                                       DbHelper.MakeInParam("@Descn",OleDbType.VarWChar,255,descn.Text.Trim())};

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring, parms);

            MessageBox.Show("添加成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void AddProductForm_Load(object sender, EventArgs e)
        {
            //加载产品名称,最上面3笔
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT TOP 3 Name FROM " + BaseConfigs.GetTablePrefix + "Products ORDER BY ProductID DESC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                name.Items.Add(dr["Name"].ToString());
            }

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
        }
        #endregion
    }
}
