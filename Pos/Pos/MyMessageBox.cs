using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pos
{
    public class MyMessageBox
    {
        /// <summary>
        /// “消息”对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void MessageBoxByInformation(string msg)
        {
            MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// “疑问”对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void MessageBoxByQuestion(string msg)
        {
            MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        
        /// <summary>
        /// “疑问”对话框
        /// </summary>
        /// <param name="msg"></param>
        public static DialogResult MessageBoxByOKCancel(string msg)
        {
            DialogResult result = MessageBox.Show(msg, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }

        /// <summary>
        /// “警告”对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void MessageBoxByWarning(string msg)
        {
            MessageBox.Show(msg, "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// “错误”对话框
        /// </summary>
        /// <param name="msg"></param>
        public static void MessageBoxByError(string msg)
        {
            MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
