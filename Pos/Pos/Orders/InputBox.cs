using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

         
        /// <summary>
        /// 对键盘进行响应
        /// </summary>
        private void txtData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                this.Close();

            }

            else if (e.KeyCode == Keys.Escape)
            {

                txtData.Text = string.Empty;

                this.Close();

            }

        }

        /// <summary>
        /// 显示InputBox 
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="keyInfo">内容</param>
        /// <returns></returns>
        public static string Show(string title, string keyInfo, string sValue)
        {
            InputBox inputBox = new InputBox();

            inputBox.Text = title;

            if (keyInfo.Trim() != "")
                inputBox.lblInfo.Text = keyInfo;

            if (sValue.Trim() != "")
                inputBox.txtData.Text = sValue;

            inputBox.ShowDialog();

            return inputBox.txtData.Text.Trim();

        } 
    }
}
