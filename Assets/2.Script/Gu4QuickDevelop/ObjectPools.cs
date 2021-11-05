using System.Collections.Generic;
using UnityEngine;

//==============================
//Synopsis  :  全局对象池
//CreatTime :  2021/9/1 16:56:37
//For       :  Gu4
//==============================

namespace Gu4.Frame
{
    public class ObjectPools : MonoSingleton<ObjectPools>
    {
        private Dictionary<string, List<GameObject>> poolDic = new Dictionary<string, List<GameObject>>();

        public GameObject GetObject(string objName)
        {
            GameObject obj = null;
            //List<GameObject> pool = null;
            //if(poolDic.TryGetValue(objName,out pool))
            //{
            //    if(pool.Count>0)
            //    {
            //        obj = pool[0];
            //        pool.RemoveAt(0);
            //    }
            //}
            if (poolDic.ContainsKey(objName))
            {
                if (poolDic[objName].Count > 0)
                {
                    obj = poolDic[objName][0];
                    poolDic[objName].RemoveAt(0);
                }
            }
            if (obj == null)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefab/" + objName);
                obj = Instantiate(prefab);
                obj.name = objName.Substring(objName.LastIndexOf('/') + 1);
            }
            obj.SetActive(true);
            obj.transform.SetParent(null);
            return obj;
        }

        /// <summary>
        /// 重载获取方法
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public GameObject GetObject(string objName, Vector3 position, Quaternion rotation)
        {
            return GetObject(objName, position, rotation, null);
        }

        /// <summary>
        /// 重载获取方法并设置父物体
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public GameObject GetObject(string objName, Vector3 position, Quaternion rotation, Transform parent)
        {
            Debug.Log(objName);
            GameObject obj = GetObject(objName);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.SetParent(parent);
            return obj;
        }

        /// <summary>
        /// 回收物体
        /// </summary>
        /// <param name="obj"></param>
        public void RecycleObject(GameObject obj)
        {
            List<GameObject> pool;
            if (!poolDic.TryGetValue(obj.name, out pool))
            {
                pool = new List<GameObject>();
                poolDic[obj.name] = pool;
            }
            pool.Add(obj);
            obj.SetActive(false);
            obj.transform.SetParent(transform);
        }
    }
}