using Gu4.Frame;
using UnityEngine;

namespace Gu4.Tools
{
    //=============================================================
    //==创建人：Gu4                                              ==
    //==创建时间：2020/10/10                                     ==
    //==功能说明：安卓工具类                                     ==
    //=============================================================
    public class AndroidUtil : Singleton<AndroidUtil>
    {
        /// <summary>
        /// 获取设备UID
        /// </summary>
        public string GetID()
        {
            string id = null;
            id = SystemInfo.deviceUniqueIdentifier;
            return id;
        }

        /// <summary>
        /// 获取标识码+设备UID
        /// </summary>
        /// <param name="key">标识码</param>
        public string GetID(string key = null)
        {
            string id = null;
            id = SystemInfo.deviceUniqueIdentifier;
            return string.IsNullOrEmpty(key) ? id : id + "_" + key;
        }
    }
}