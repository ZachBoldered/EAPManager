using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class FrmProductColorEdit : Form
    {
        string _colorID = string.Empty;
        public FrmProductColorEdit(string ColorID)
        {
            InitializeComponent();
            _colorID = ColorID;
        }

        #region 保存
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写颜色名称！", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT ColorID FROM " + BaseConfigs.GetTablePrefix + "Colors WHERE Name='" + name.Text.Trim() + "'").Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    MessageBox.Show("颜色名称重复!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            string sqlstring = string.Format("UPDATE " + BaseConfigs.GetTablePrefix + "Colors SET Name='{0}' WHERE ColorID={1}", name.Text.Trim(), _colorID);

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring);

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
        private void EditProductColorForm_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT Name FROM " + BaseConfigs.GetTablePrefix + "Colors WHERE ColorID=" + _colorID).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                name.Text = dr["Name"].ToString();
            }
        }
        #endregion
    }
}
