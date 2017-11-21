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
    public partial class FrmUsersAdd : Form
    {
        public FrmUsersAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            #region 保存资料
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("姓名必须填写！", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT UserID FROM " + BaseConfigs.GetTablePrefix + "Users WHERE Name='" + name.Text.Trim() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("姓名重复！", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userPwd = string.Empty;

            if (userName.Text.Trim() != "")
            {
                DataTable dt1 = DbHelper.ExecuteDataset(CommandType.Text, "SELECT UserID FROM " + BaseConfigs.GetTablePrefix + "Users WHERE UserName='" + userName.Text.Trim() + "'").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    MessageBox.Show("用户名重复！", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Text.Trim() == "")
                {
                    MessageBox.Show("请输入密码！", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (password.Text.Trim() != password2.Text.Trim())
                    {
                        MessageBox.Show("两次密码输入不同，请检查！", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                userPwd = Hash.MD5(password.Text.Trim());
            }


            string sqlstring = "INSERT INTO " + BaseConfigs.GetTablePrefix + "Users(UserName,UserPwd,Name,Address,Tel,Mob,Descn) VALUES(@UserName,@UserPwd,@Name,@Address,@Tel,@Mob,@Descn)";
            OleDbParameter[] parms = {
                                         DbHelper.MakeInParam("@UserName",OleDbType.VarWChar,64,userName.Text.Trim()),
                                         DbHelper.MakeInParam("@UserPwd",OleDbType.VarWChar,64,userPwd),
                                         DbHelper.MakeInParam("@Name", OleDbType.VarWChar, 32, name.Text.Trim()),
                                         DbHelper.MakeInParam("@Address",OleDbType.VarWChar,255,address.Text.Trim()),
                                         DbHelper.MakeInParam("@Tel",OleDbType.VarWChar,32,tel.Text.Trim()),
                                         DbHelper.MakeInParam("@Mob",OleDbType.VarWChar,32,mob.Text.Trim()),
                                         DbHelper.MakeInParam("@Descn",OleDbType.VarWChar,255,memo.Text.Trim())};

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring, parms);

            MessageBox.Show(sqlstring, "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            #endregion
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
