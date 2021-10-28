using Gu4.Frame;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gu4.Tools
{
    //==============================
    //Synopsis  :  正则表达式类封装
    //CreatTime :  2021/7/27 11:14:50
    //For       :  Gu4
    //==============================

    public class RegexUtil : Singleton<RegexUtil>
    {
        /// <summary>
        /// 从字符串中获取中文字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetChineseFromString(string str)
        {
            string x = @"[\u4E00-\u9FFF]+";
            MatchCollection Matches = Regex.Matches(str, x, RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder();
            foreach (Match NextMatch in Matches)
            {
                sb.Append(NextMatch.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 检查字符串是否为字符或者数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckStrIsNumOrChar(string str)
        {
            Regex pRegex = new Regex(@"^[A-Za-z0-9_]+$");
            if (!pRegex.IsMatch(str))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 校验手机号码是否符合标准。
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool ValidateMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
                return false;

            return Regex.IsMatch(mobile, @"^(13|14|15|16|18|19|17)\d{9}$");
        }

        ///<summary>
        /// 正则表达式检测Email格式
        /// </summary>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        public static bool CheckEmail(string Email)
        {
            bool Flag = false;
            string str = "([a-zA-Z0-9_\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9]{2,5})+";
            string[] result = GetPathPoint(Email, str);
            if (result != null)
            {
                Flag = result.Contains(Email) ? true : Flag;
            }
            return Flag;
        }

        /// <summary>
        /// 获取正则表达式匹配结果集
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="regx">正则表达式</param>
        /// <returns></returns>
        private static string[] GetPathPoint(string value, string regx)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            bool isMatch = Regex.IsMatch(value, regx);
            if (!isMatch)
            {
                return null;
            }
            MatchCollection matchCol = Regex.Matches(value, regx);
            string[] result = new string[matchCol.Count];
            if (matchCol.Count > 0)
            {
                for (int i = 0; i < matchCol.Count; i++)
                {
                    result[i] = matchCol[i].Value;
                }
            }
            return result;
        }

        /// <summary>
        /// 检测字符串是否为整数或小数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsIntOrFloat(string num)
        {
            Regex regex = new Regex(@"^[0 - 9] +\.{ 0,1}[0-9]{0,2}$");
            return regex.IsMatch(num);
        }
    }
}