using Gu4.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Gu4.Extend
{
    public static class TranfromExtend
    {
        /// <summary>
        /// 删除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="game"></param>
        /// <param name="t">组件</param>
        /// <returns></returns>
        public static Transform DesComponent<T>(this Transform tran) where T : Component
        {
            T t = tran.GetComponent<T>();
            if (t != null)
            {
                Object.Destroy(t);
            }
            return tran;
        }

        /// <summary>
        /// 删除脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="game"></param>
        /// <param name="t">脚本</param>
        /// <returns></returns>
        public static Transform DesScripts<T>(this Transform tran) where T : MonoBehaviour
        {
            T t = tran.GetComponent<T>();
            if (t != null)
            {
                Object.Destroy(t);
            }
            return tran;
        }

        public static void Destory(this Transform tran)
        {
            Object.Destroy(tran.gameObject);
        }

        public static T TryGet<T>(this Transform tran) where T : Component
        {
            T t;
            if (tran.TryGetComponent<T>(out t))
            {
                return t;
            }
            else
            {
                return tran.gameObject.AddComponent<T>();
            }
        }

        /// <summary>
        /// TryGet组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">子物体名字</param>
        /// <returns></returns>
        public static T TryGet<T>(this Transform tran, string name) where T : Component
        {
            T t;

            Transform temp = tran.Find(name);
            if (temp == null)
            {
                LogUtil.LogError($"{tran.name}下找不到名为{name}的子物体，无法Get或Add组件");
                return null;
            }
            else
            {
                if (temp.TryGetComponent<T>(out t))
                {
                    return t;
                }
                else
                {
                    return temp.gameObject.AddComponent<T>();
                }
            }
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="name">子物体名称</param>
        /// <returns></returns>
        public static T Get<T>(this Transform tran, string name = null)
        {
            T t;
            if (name == null)
            {
                t = tran.GetComponent<T>();
            }
            else
            {
                t = tran.Find(name).GetComponent<T>();
            }
            return t;
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="name">子物体名称</param>
        /// <returns></returns>
        public static T Get<T>(this Transform tran, int index)
        {
            T t;
            if (index < 0)
            {
                t = tran.GetComponent<T>();
            }
            else
            {
                t = tran.GetChild(index).GetComponent<T>();
            }
            return t;
        }

        /// <summary>
        /// 清除所有子物体
        /// </summary>
        /// <param name="tran"></param>
        public static void ClearAllChild(this Transform tran)
        {
            for (int i = 0; i < tran.childCount; i++)
            {
                tran.GetChild(i).Destory();
            }
        }

        /// <summary>
        /// 便捷添加EventTrigger
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="type"></param>
        /// <param name="events"></param>
        public static void AddEventTrigger(this Transform tran, EventTriggerType type, UnityAction<BaseEventData> events)
        {
            UnityAction<BaseEventData> click = new UnityAction<BaseEventData>(events);
            EventTrigger.Entry myclick = new EventTrigger.Entry();
            myclick.eventID = type;
            myclick.callback.AddListener(click);
            EventTrigger trigger = tran.TryGet<EventTrigger>();
            trigger.triggers.Add(myclick);
        }
    }
}