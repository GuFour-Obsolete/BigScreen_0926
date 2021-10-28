using System;
using System.Collections.Generic;
using Gu4.Tools;
using Random = UnityEngine.Random;

namespace Gu4.Extend
{
    public static class StringExtend
    {
        /// <summary>
        /// 转Int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return TypeUtil.Int(str) == null ? 0 : TypeUtil.AsInt(str);
        }

        /// <summary>
        /// 移除字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        public static string RemoveChar(this string str, char c)
        {
            int index = str.IndexOf(c);
            return index == -1 ? str : str.Remove(index);
        }

        /// <summary>
        /// 转Base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            var bytes = System.Text.Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 转string列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> ToStringList(this string str)
        {
            List<string> strs = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                strs.Add(str[i].ToString());
            }
            return strs;
        }

        /// <summary>
        /// 转字符列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<char> ToCharList(this string str)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                chars.Add(str[i]);
            }
            return chars;
        }

        /// <summary>
        /// 判断两个字符串包含的内容是否相同
        /// </summary>
        /// <param name="str"></param>
        /// <param name="content">比较的字符串</param>
        /// <returns></returns>
        public static bool TheSame(this string str, string content)
        {
            if (str.Length != content.Length)
            {
                return false;
            }
            for (int i = 0; i < content.Length; i++)
            {
                if (!str.Contains(content[i].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 随机打乱数组
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string[] RandomStr(this string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string temp = arr[i];
                int index = Random.Range(0, arr.Length);
                arr[i] = arr[index];
                arr[index] = temp;
            }
            return arr;
        }
    }
}