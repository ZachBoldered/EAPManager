using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class FrmProductUnitEdit : Form
    {
        string _unitID = string.Empty;
        public FrmProductUnitEdit(string UnitID)
        {
            InitializeComponent();
            _unitID = UnitID;
        }

        #region 保存
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT UnitID FROM " + BaseConfigs.GetTablePrefix + "Units WHERE Name='" + name.Text.Trim() + "'").Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    MessageBox.Show("名称重复!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            string sqlstring = string.Format("UPDATE " + BaseConfigs.GetTablePrefix + "Units SET Name='{0}' WHERE UnitID={1}", name.Text.Trim(), Convert.ToInt32(_unitID));

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring);

            MessageBox.Show("修改成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        #endregion        

        #region 关闭
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 加载
        private void EditProductUnitForm_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Units WHERE UnitID=" + _unitID).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                name.Text = dr["Name"].ToString();
            }
        }
        #endregion
    }
}
