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
    public partial class FrmProductUnitAdd : Form
    {
        public FrmProductUnitAdd()
        {
            InitializeComponent();
        }

        #region 保存
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT UnitID FROM " + BaseConfigs.GetTablePrefix + "Units WHERE Name='" + name.Text.Trim() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("名称重复!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlstring = string.Format("INSERT INTO {0}Units(Name) VALUES('{1}')", BaseConfigs.GetTablePrefix, name.Text.Trim());

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring);

            MessageBox.Show("添加成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        #endregion

        #region 关闭
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
