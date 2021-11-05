using Gu4.Frame;
using System.Text;

namespace Gu4.Tools
{
    //==============================
    //Synopsis  :  字符串操作类
    //CreatTime :  2021/7/27 11:14:50
    //For       :  Gu4
    //==============================

    public class StringUtil : Singleton<StringUtil>
    {
        private StringBuilder stringBuilder = new StringBuilder();
        private StringBuilder shareStringBuilder = new StringBuilder();

        public StringBuilder GetShareStringBuilder()
        {
            shareStringBuilder.Remove(0, stringBuilder.Length);
            return shareStringBuilder;
        }

        public string Format(string src, params object[] args)
        {
            stringBuilder.Remove(0, stringBuilder.Length);
            stringBuilder.AppendFormat(src, args);
            return stringBuilder.ToString();
        }

        public string Concat(string s1, string s2)
        {
            stringBuilder.Remove(0, stringBuilder.Length);
            stringBuilder.Append(s1);
            stringBuilder.Append(s2);
            return stringBuilder.ToString();
        }

        public string Concat(string s1, string s2, string s3)
        {
            stringBuilder.Remove(0, stringBuilder.Length);
            stringBuilder.Append(s1);
            stringBuilder.Append(s2);
            stringBuilder.Append(s3);
            return stringBuilder.ToString();
        }

        public string Concat(string[] str)
        {
            stringBuilder.Remove(0, stringBuilder.Length);
            for (int i = 0; i < str.Length; i++)
            {
                stringBuilder.Append(str[i]);
            }
            return stringBuilder.ToString();
        }
    }
}