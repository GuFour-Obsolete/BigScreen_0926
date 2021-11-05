using Gu4.Frame;
using System;
using UnityEngine;

namespace Gu4.Tools
{
    public class TypeUtil : Singleton<TypeUtil>
    {
        public enum FileSizeType
        {
            KB,
            M,
            G,
            T
        }

        public enum LengthType
        {
            KM,
            M,
            DM,
            CM,
            MM,
            µm,
            NM,
            GN,
        }

        /// <summary>
        /// 转为Int类型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int? Int(string o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转为Int类型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int AsInt(string o)
        {
            return Convert.ToInt32(o);
        }

        public static int AsInt(object o)
        {
            return Convert.ToInt32(o);
        }

        /// <summary>
        /// 转为Int类型(四舍五入)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int AsInt(float o)
        {
            int i = 0;
            if (o > 0)
            {
                i = (int)(o + .5f);
            }
            else if (o < 0)
            {
                i = (int)(o - .5f);
            }
            else
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// 时间转换
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime AsDataTime(object o)
        {
            return Convert.ToDateTime(o);
        }

        /// <summary>
        /// 转float类型
        /// </summary>
        /// <param name="o"></param>
        /// <param name="digits">保留小数点位数</param>
        /// <returns></returns>
        public static float? Float(object o, int digits = 2)
        {
            try
            {
                return (float)Math.Round(Convert.ToSingle(o), digits);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转float类型
        /// </summary>
        /// <param name="o"></param>
        /// <param name="digits">保留小数点位数</param>
        /// <returns></returns>
        public static float AsFloat(object o, int digits = 2)
        {
            return (float)Math.Round(Convert.ToSingle(o), digits);
        }

        /// <summary>
        /// 转long类型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static long? Long(object o)
        {
            try
            {
                return Convert.ToInt64(o);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转long类型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static long AsLong(object o)
        {
            return Convert.ToInt64(o);
        }

        /// <summary>
        /// 转Double
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static double AsDouble(object o)
        {
            return Convert.ToDouble(o);
        }

        /// <summary>
        /// 随机Int
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static int RandomInt(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// 随机float
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// byts转Sprite
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="texture2D"></param>
        /// <returns></returns>
        public static Sprite AsSprite(byte[] bytes, Texture2D texture2D = null)
        {
            Texture2D texture = null;
            if (texture2D != null)
            {
                texture = texture2D;
            }
            else
            {
                texture = new Texture2D(100, 100);
            }
            texture.LoadImage(bytes);
            Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            return sp;
        }

        /// <summary>
        /// base64转Sprite
        /// </summary>
        /// <param name="base64"></param>
        /// <param name="texture2D"></param>
        /// <returns></returns>
        public static Sprite AsSprite(string base64, Texture2D texture2D = null)
        {
            Texture2D texture = null;
            if (texture2D != null)
            {
                texture = texture2D;
            }
            else
            {
                texture = new Texture2D(100, 100);
            }
            byte[] bytes = Convert.FromBase64String(base64);
            texture.LoadImage(bytes);
            Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            return sp;
        }

        /// <summary>
        /// Sprite转byte
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static byte[] GetByte(Sprite sp)
        {
            Texture2D texture = sp.texture;
            byte[] data = texture.EncodeToPNG();
            return data;
        }

        /// <summary>
        /// Sprite 转 base64编码
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static string GetBase64(Sprite sp)
        {
            string base64 = Convert.ToBase64String(GetByte(sp));
            return base64;
        }

        /// <summary>
        /// Base64转string
        /// </summary>
        /// <param name="base64">Base64字符串</param>
        /// <returns></returns>
        public static string Base64ToString(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return "";
            }
            byte[] bytes = Convert.FromBase64String(base64);
            return System.Text.Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 文件显示大小转换
        /// </summary>
        /// <param name="a">文件大小</param>
        /// <param name="type">转换类型</param>
        /// <returns></returns>
        public static string AsFileSize(long a, FileSizeType type, int places = 0)
        {
            switch (type)
            {
                case FileSizeType.KB:
                    return (a / 1024).ToString("f" + places) + "Kb";

                case FileSizeType.M:
                    return (a / 1048576).ToString("f" + places) + "M";

                case FileSizeType.G:
                    return (a / 1073741824).ToString("f" + places) + "G";

                case FileSizeType.T:
                    return (a / 1099511627776).ToString("f" + places) + "T";
            }
            return null;
        }

        /// <summary>
        /// 返回间隔天数
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int Day_Interval(string dateTime)
        {
            try
            {
                return DateTime.Now.Subtract(DateTime.Parse(dateTime)).Duration().Days;
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return -1;
            }
        }

        /// <summary>
        /// 返回间隔天数
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int Day_Interval(DateTime dateTime)
        {
            try
            {
                return DateTime.Now.Subtract(dateTime).Duration().Days;
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return -1;
            }
        }

        /// <summary>
        /// 长度转换
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="type">长度类型</param>
        /// <returns></returns>
        public static double AsLength(double data, LengthType dataType, LengthType type)
        {
            double M = AsM(data, dataType);
            switch (type)
            {
                case LengthType.KM:
                    return M / 1000d;

                case LengthType.M:
                    return M;

                case LengthType.DM:
                    return M * 10d;

                case LengthType.CM:
                    return M * 100d;

                case LengthType.MM:
                    return M * 1000d;

                case LengthType.µm:
                    return M * 1000000d;

                case LengthType.NM:
                    return M * 1000000000d;

                case LengthType.GN:
                    return M / 9460000000000000d;

                default:
                    break;
            }
            return 0;
        }

        private static double AsM(double data, LengthType dataType)
        {
            switch (dataType)
            {
                case LengthType.KM:
                    return data * 1000d;

                case LengthType.M:
                    return data;

                case LengthType.DM:
                    return data * .1d;

                case LengthType.CM:
                    return data * .01d;

                case LengthType.MM:
                    return data * .001d;

                case LengthType.µm:
                    return data / 1000000d;

                case LengthType.NM:
                    return data / 1000000000d;

                case LengthType.GN:
                    return data * 9460000000000000d;
            }
            return 0;
        }
    }
}