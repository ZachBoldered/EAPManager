using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        public DataTable dt = new DataTable();
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            dt = DbHelper.ExecuteDataset(CommandType.Text, "SELECT ProductID,ProductNo,Name,ColorName,UnitName,Num,CostPrice,SellPrice,JobPrice FROM " + BaseConfigs.GetTablePrefix + "Products WHERE Num<=1 ORDER BY ProductID ASC").Tables[0];
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Step = 1;            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                progressBar1.PerformStep();
            }

            this.Close();
        }       
    }
}
