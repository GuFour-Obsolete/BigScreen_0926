using UnityEngine;

namespace Gu4.Extend
{
    /// <summary>
    /// 组件拓展类
    /// </summary>
    public static class ComponentExtend
    {
        /// <summary>
        /// 该组件所属物体FindName
        /// </summary>
        /// <param name="name">所找物体的名字</param>
        /// <returns></returns>
        public static Transform GetChind(this Component tran, string name)
        {
            return tran.transform.Find(name);
        }

        /// <summary>
        /// 该组件所属物体FindIndex
        /// </summary>
        /// <param name="name">所找物体的索引</param>
        /// <returns></returns>
        public static Transform GetChind(this Component tran, int index)
        {
            return tran.transform.GetChild(index);
        }

        /// <summary>
        /// 设置物体是否隐藏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj"></param>
        /// <param name="isActive"></param>
        public static void SetActive<T>(this T Obj, bool isActive) where T : Component
        {
            Obj.gameObject.SetActive(isActive);
        }

        /// <summary>
        /// 根据组件所属物体设置父级
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="parent"></param>
        public static void SetParent(this Component obj, Transform parent)
        {
            obj.transform.SetParent(parent, false);
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name">子物体名字</param>
        /// <returns></returns>
        public static T Get<T>(this Component obj, string name = null)
        {
            T t;
            if (string.IsNullOrEmpty(name))
            {
                t = obj.GetComponent<T>();
            }
            else
            {
                t = obj.transform.Find(name).GetComponent<T>();
            }
            return t;
        }

        public static T Get<T>(this Component obj, int index)
        {
            T t;
            if (index == -1)
            {
                t = obj.GetComponent<T>();
            }
            else
            {
                t = obj.transform.GetChild(index).GetComponent<T>();
            }
            return t;
        }

        public static T GetPeer<T>(this Component obj, string name)
        {
            T t;
            if (string.IsNullOrEmpty(name))
            {
                t = obj.GetComponent<T>();
            }
            else
            {
                t = obj.transform.parent.Find(name).GetComponent<T>();
            }
            return t;
        }

        public static Transform GetPeer(this Component obj, string name)
        {
            Transform tran;
            if (string.IsNullOrEmpty(name))
            {
                tran = obj.transform;
            }
            else
            {
                tran = obj.transform.parent.Find(name);
            }
            return tran;
        }

        /// <summary>
        /// 根据组件摧毁GO
        /// </summary>
        /// <param name="obj"></param>
        public static void Destory(this Component obj)
        {
            Object.Destroy(obj.gameObject);
        }
    }
}