using UnityEngine;
using UnityEngine.EventSystems;
using Gu4.Frame;

namespace Gu4.Tools
{
    //==============================
    //Synopsis  :  输入操作工具类
    //CreatTime :  2021/7/27 11:14:50
    //For       :  Gu4
    //==============================

    public class OperationUtil : Singleton<OperationUtil>
    {
        /// <summary>
        /// UI穿透
        /// </summary>
        /// <returns>YesOrNo</returns>
        public bool IsClickUI
        {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR
            int fingerID = Input.GetTouch(0).fingerId;
            if (EventSystem.current.IsPointerOverGameObject(fingerID))
            {
                return true;
            }
            else
            {
                return false;
            }
#else
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return true;
                }
                else
                {
                    return false;
                }
#endif
            }
        }
    }
}