using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = -1;
            this.textBox1.Text = string.Empty;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT TOP 5 UserName FROM " + BaseConfigs.GetTablePrefix + "Users WHERE UserName<>'' ORDER BY UserID DESC").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                this.comboBox1.Items.Add(dr["UserName"].ToString());
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("帐号不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlstring = "SELECT UserID FROM " + BaseConfigs.GetTablePrefix + "Users WHERE UserName='" + this.comboBox1.Text.Trim() + "' AND UserPwd='" + Hash.MD5(this.textBox1.Text.Trim()) + "'";
            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Form1 FrmMain = new Form1();
                FrmMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
