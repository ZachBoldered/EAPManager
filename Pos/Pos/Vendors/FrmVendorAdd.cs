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
    public partial class FrmVendorAdd : Form
    {
        public FrmVendorAdd()
        {
            InitializeComponent();
        }

        #region 保存供应商资料
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写供应商名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT SupplierID FROM " + BaseConfigs.GetTablePrefix + "Suppliers WHERE Name='" + name.Text.Trim() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("供应商名称重复!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlstring = "INSERT INTO " + BaseConfigs.GetTablePrefix + "Suppliers(Name,LinkMan,Address,Tel,Fax,Mob,Email,Url,BankNo,BankName,Descn) VALUES(@Name,@LinkMan,@Address,@Tel,@Fax,@Mob,@Email,@Url,@BankNo,@BankName,@Descn)";
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

        #region 关闭窗口
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
