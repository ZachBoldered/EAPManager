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
    public partial class FrmCustomerEdit : Form
    {
        string _customerID = string.Empty;
        public FrmCustomerEdit(string CustomerID)
        {
            InitializeComponent();
            this._customerID = CustomerID;
        }

        #region 关闭
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 保存
        private void saveButton_Click(object sender, EventArgs e)
        {
            //保存资料
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("请填写客户名称!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlstring = "UPDATE " + BaseConfigs.GetTablePrefix + "Customers SET Name=@Name,LinkMan=@LinkMan,Address=@Address,Tel=@Tel,Fax=@Fax,Mob=@Mob,Email=@Email,Url=@Url,BankNo=@BankNo,BankName=@BankName,Descn=@Descn WHERE CustID=@CustID";
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
                                       DbHelper.MakeInParam("@Descn",OleDbType.VarWChar,255,descn.Text.Trim()),                                       
                                       DbHelper.MakeInParam("@CustID",OleDbType.Integer,4,Convert.ToInt32(_customerID))};

            DbHelper.ExecuteNonQuery(CommandType.Text, sqlstring, parms);

            MessageBox.Show("修改成功!", "提示信息...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 加载数据
        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            string sqlstring = "SELECT * FROM " + BaseConfigs.GetTablePrefix + "Customers WHERE CustID=" + _customerID;

            DataTable dt = DbHelper.ExecuteDataset(CommandType.Text, sqlstring).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                name.Text = dr["Name"].ToString();
                tel.Text = dr["Tel"].ToString();
                linkman.Text = dr["LinkMan"].ToString();
                mob.Text = dr["Mob"].ToString();
                fax.Text = dr["Fax"].ToString();
                address.Text = dr["Address"].ToString();
                url.Text = dr["Url"].ToString();
                email.Text = dr["Email"].ToString();
                bankName.Text = dr["BankName"].ToString();
                bankno.Text = dr["BankNo"].ToString();
                descn.Text = dr["Descn"].ToString();
            }
        }
        #endregion
    }
}
