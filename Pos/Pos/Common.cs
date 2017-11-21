using System;
using System.Data;

namespace Pos
{
    /// <summary>
    /// 公用变量
    /// </summary>
    public class Common
    {
        public static int CustID = 0;

        public static int SupplierID = 0;

        public static int UserID = 0;

        public static int UnitID = 0;

        public static int ColorID = 0;

        public static int ProductID = 0;

        public static string sqlstring = string.Empty;

        /// <summary>
        /// 格式化日期函数
        /// </summary>
        /// <param name="sDate">日期</param>
        /// <returns></returns>
        public static string FormatDate(string sDate)
        {
            return sDate.Replace("年", "-").Replace("月", "-").Replace("日", "");
        }
    }
}
