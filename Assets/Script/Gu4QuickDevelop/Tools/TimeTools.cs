using System;

namespace Gu4.Tools
{
    public static class TimeTools
    {
        /// <summary>
        /// 获取日期0- 1/ 2年
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetSystemDate(int style = 0)
        {
            string date = string.Empty;

            switch (style)
            {
                case 0:
                    date = DateTime.Now.ToString("yyyy-MM-dd");
                    break;

                case 1:
                    date = DateTime.Now.ToString("yyyy/MM/dd");
                    break;

                case 2:
                    date = DateTime.Now.ToString("yyyy年MM月dd日");
                    break;
            }

            return date;
        }

        /// <summary>
        /// 获取星期
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetSystemWeek(int style = 0)
        {
            string week = string.Empty;
            string[] weeks1 = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string[] weeks2 = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            switch (style)
            {
                case 0:
                    week = weeks1[(int)DateTime.Now.DayOfWeek];
                    break;

                case 1:
                    week = weeks2[(int)DateTime.Now.DayOfWeek];
                    break;
            }
            return week;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetSystemTime(int style = 0)
        {
            string time = string.Empty;

            switch (style)
            {
                case 0:
                    time = System.DateTime.Now.ToString("HH:mm");
                    break;

                case 1:
                    time = System.DateTime.Now.ToString("HH时mm分");
                    break;
            }

            return time;
        }
    }
}