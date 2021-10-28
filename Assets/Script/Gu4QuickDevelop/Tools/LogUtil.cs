using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Gu4.Tools
{
    //==============================
    //Synopsis  :  调试日志工具类
    //CreatTime :  2021/7/27 11:14:50
    //For       :  Gu4
    //==============================

    public class LogUtil
    {
        private static Stopwatch m_Run;

        private static bool IsLog()
        {
#if Gu4Log || UNITY_EDITOR
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="showColor">是否显示颜色</param>
        public static void Log(object str, bool showColor = true)
        {
            if (!IsLog())
                return;

            if (showColor)
            {
                Debug.Log("<color=#FF41A8>[Gu4] </color><color=green>" + str + "</color>");
            }
            else
            {
                Debug.Log(str);
            }
        }

        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="context">输出对象</param>
        /// <param name="showColor">是否设置颜色</param>
        public static void Log(object str, Object context, bool showColor = false)
        {
            if (!IsLog())
                return;

            if (showColor)
            {
                Debug.Log("<color=#FF41A8>[Gu4] </color><color=green>" + str + "</color>", context);
            }
            else
            {
                Debug.Log(str, context);
            }
        }

        /// <summary>
        /// 警告输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="showColor">是否显示颜色</param>
        public static void LogWarning(object str, bool showColor = true)
        {
            if (!IsLog())
                return;

            if (showColor)
            {
                Debug.LogWarning("<color=#FF41A8>[Gu4] </color><color=yellow>" + str + "</color>");
            }
            else
            {
                Debug.LogWarning(str);
            }
        }

        /// <summary>
        /// 警告输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="context">输出对象</param>
        /// <param name="showColor">是否显示颜色</param>
        public static void LogWarning(object str, Object context, bool showColor = false)
        {
            if (!IsLog())
                return;

            if (showColor)
            {
                Debug.LogWarning("<color=#FF41A8>[Gu4] </color><color=yellow>" + str + "</color>", context);
            }
            else
            {
                Debug.LogWarning(str, context);
            }
        }

        /// <summary>
        /// 错误输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="showColor">是否显示颜色</param>
        public static void LogError(object str, bool showColor = true)
        {
            if (!IsLog())
                return;

            if (showColor)
            {
                Debug.LogError("<color=#FF41A8>[Gu4] </color><color=red>" + str + "</color>");
            }
            else
            {
                Debug.LogError(str);
            }
        }

        /// <summary>
        /// 错误输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="context">输出对象</param>
        /// <param name="showColor">是否显示颜色</param>
        public static void LogError(object str, Object context, bool showColor = true)
        {
            if (!IsLog())
                return;

            if (showColor)
            {
                Debug.LogError("<color=#FF41A8>[Gu4] </color><color=red>" + str + "</color>", context);
            }
            else
            {
                Debug.LogError(str, context);
            }
        }

        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="str">输出内容</param>
        /// <param name="arg">args</param>
        public static void LogFormat(string str, params string[] arg)
        {
            if (!IsLog())
                return;

            Debug.LogFormat("<color=#FF41A8>[Gu4] </color>" + str, arg);
        }

        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="context">输出对象</param>
        /// <param name="str">输出内容</param>
        /// <param name="arg">args</param>
        public static void LogFormat(Object context, string str, params string[] arg)
        {
            if (!IsLog())
                return;

            Debug.LogFormat(context, "<color=#FF41A8>[Gu4] </color>" + str, arg);
        }

        /// <summary>
        /// 日志输出
        /// </summary>
        /// <param name="type">日志类型</param>
        /// <param name="option">日志选项</param>
        /// <param name="context">输出对象</param>
        /// <param name="str">输出内容</param>
        /// <param name="arg">args</param>
        public static void LogFormat(LogType type, LogOption option, Object context, string str, params string[] arg)
        {
            if (!IsLog())
                return;

            Debug.LogFormat(type, option, context, "<color=#FF41A8>[Gu4] </color>" + str, arg);
        }

        /// <summary>
        /// 输出方法运行时间
        /// </summary>
        public static string LogRunTime(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action?.Invoke();
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            string timer = ts2.TotalMilliseconds.ToString();
            LogFormat("<color=#FF41A8>[Gu4] </color><color=blue>该方法总共花费{0}ms.</color>", timer);
            return timer;
        }

        public static void LogRunTimeStart()
        {
            m_Run = new Stopwatch();
            m_Run.Start();
        }

        public static void LogRunTimeEnd()
        {
            m_Run.Stop();
            TimeSpan ts2 = m_Run.Elapsed;
            string timer = ts2.TotalMilliseconds.ToString();
            LogFormat("<color=#FF41A8>[Gu4] </color><color=blue>该方法总共花费{0}ms.</color>", timer);
        }

        /// <summary>
        /// 复制string
        /// </summary>
        /// <param name="str"></param>
        public static void Copy(string str)
        {
            TextEditor te = new TextEditor();
            te.text = str;
            te.SelectAll();
            te.Copy();
            Log(string.Format("参数复制成功：【{0}】", str));
        }
    }
}