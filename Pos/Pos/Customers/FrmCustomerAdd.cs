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
    public partial class FrmCustomerAdd : Form
    {
        public FrmCustomerAdd()
        {
            InitializeComponent();
        }

        #region 关闭窗口
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 保存客户资料
        private void saveButton_Click(object sender, EventArgs e)
        {            
            //保存资料
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写客户名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DbHelper.ExecuteDataset(CommandType.Text, "SELECT CustID FROM " + BaseConfigs.GetTablePrefix + "Customers WHERE Name='" + name.Text.Trim() + "'").Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("客户名称重复!!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlstring = "INSERT INTO " + BaseConfigs.GetTablePrefix + "Customers(Name,LinkMan,Address,Tel,Fax,Mob,Email,BankNo,BankName,Url,Descn) VALUES(@Name,@LinkMan,@Address,@Tel,@Fax,@Mob,@Email,@BankNo,@BankName,@Url,@Descn)";
            OleDbParameter[] parms = {
                                       DbHelper.MakeInParam("@Name",OleDbType.VarWChar,127,name.Text.Trim()),
                                       DbHelper.MakeInParam("@LinkMan",OleDbType.VarWChar,32,linkman.Text.Trim()),
                                       DbHelper.MakeInParam("@Address",OleDbType.VarWChar,255,address.Text.Trim()),
                                       DbHelper.MakeInParam("@Tel",OleDbType.VarWChar,32,tel.Text.Trim()),
                                       DbHelper.MakeInParam("@Fax",OleDbType.VarWChar,32,fax.Text.Trim()),
                                       DbHelper.MakeInParam("@Mob",OleDbType.VarWChar,32,mob.Text.Trim()),
                                       DbHelper.MakeInParam("@Email",OleDbType.VarWChar,32,email.Text.Trim()),
                                       DbHelper.MakeInParam("@Url",OleDbType.VarWChar,127,url.Text.Trim()),
                                       DbHelper.MakeInParam("@BankNo",OleDbType.VarWChar,32,bankno.Text.Trim()),
                                       DbHelper.MakeInParam("@BankName",OleDbType.VarWChar,64,bankName.Text.Trim()),
                                       DbHelper.MakeInParam("@Descn",OleDbType.VarWChar,255,descn.Text.Trim())};

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring, parms);

            MessageBox.Show("添加成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
