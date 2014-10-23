using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    class Helper
    {

        /// <summary>
        /// 去掉超过两个的符号空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveTokens(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"([\x21-\x2F][\x3A-\x40][\x5B-\x60][\x7B-\x7E][…]){2,}", "");
        }

        /// <summary>
        /// 去掉换行符,又去掉控制表的字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveASCIIControlCharacter(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"[\x00-\x08]|[\x0B-\x0C]|[\x0E-\x1F]|[\r\n]", "");
        }
        #region 全角半角转换

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        /// <summary> 转半角的函数(DBC case) </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion
    }
}
