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
    public partial class FrmProductColorAdd : Form
    {
        public FrmProductColorAdd()
        {
            InitializeComponent();
        }

        #region 保存颜色资料
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写颜色名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT ColorID FROM " + BaseConfigs.GetTablePrefix + "Colors WHERE Name='" + name.Text.Trim() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("颜色名称重复!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlstring = string.Format("INSERT INTO {0}Colors(Name) VALUES('{1}')", BaseConfigs.GetTablePrefix, name.Text.Trim());

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring);

            MessageBox.Show("添加成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }
        #endregion        

        #region 关闭窗口
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
