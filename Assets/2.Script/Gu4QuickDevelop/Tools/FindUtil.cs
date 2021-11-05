using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Gu4.Frame;

namespace Gu4.Tools
{
    //=============================================================
    //==创建人：Gu4                                              ==
    //==创建时间：2020/10/10                                     ==
    //==功能说明：该类为查找工具类                               ==
    //=============================================================
    public class FindUtil : Singleton<FindUtil>
    {
        /// <summary>
        /// 搜索子物体组件-GameObject版
        /// </summary>
        public static T Get<T>(GameObject go, string subnode) where T : Component
        {
            if (go != null)
            {
                Transform sub = go.transform.Find(subnode);
                if (sub != null) return sub.GetComponent<T>();
            }
            return null;
        }

        /// <summary>
        /// 搜索子物体组件-Transform版
        /// </summary>
        public static T Get<T>(Transform go, string subnode) where T : Component
        {
            if (go != null)
            {
                Transform sub = go.Find(subnode);
                if (sub != null) return sub.GetComponent<T>();
            }
            return null;
        }

        /// <summary>
        /// 搜索子物体组件-Component版
        /// </summary>
        public static T Get<T>(Component go, string subnode) where T : Component
        {
            return go.transform.Find(subnode).GetComponent<T>();
        }

        /// <summary>
        /// 获取同级物体组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static T GetPeer<T>(GameObject go, string subnode) where T : Component
        {
            return Peer(go, subnode).GetComponent<T>();
        }

        /// <summary>
        /// 获取同级物体组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static T GetPeer<T>(Transform go, string subnode) where T : Component
        {
            return Peer(go, subnode).GetComponent<T>();
        }

        /// <summary>
        /// 获取同级物体组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="subnode"></param>
        /// <returns></returns>
        public static T GetPeer<T>(Component go, string subnode) where T : Component
        {
            return Peer(go.transform, subnode).GetComponent<T>();
        }

        /// <summary>
        /// 查找子对象
        /// </summary>
        public static GameObject Child(GameObject go, string subnode)
        {
            return Child(go.transform, subnode);
        }

        /// <summary>
        /// 查找子对象
        /// </summary>
        public static GameObject Child(Transform go, string subnode)
        {
            Transform tran = go.Find(subnode);
            if (tran == null) return null;
            return tran.gameObject;
        }

        /// <summary>
        /// 取平级对象
        /// </summary>
        public static GameObject Peer(GameObject go, string subnode)
        {
            return Peer(go.transform, subnode);
        }

        /// <summary>
        /// 取平级对象
        /// </summary>
        public static GameObject Peer(Transform go, string subnode)
        {
            Transform tran = go.parent.Find(subnode);
            if (tran == null) return null;
            return tran.gameObject;
        }

        /// <summary>
        /// 清除所有子节点
        /// </summary>
        public static void ClearChild(Transform go)
        {
            if (go == null) return;
            for (int i = go.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(go.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// 获取本地streamingAssetsPath路径下的MP3音频文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioClip GetAudioClipFromFile(string path)
        {
            path = string.Format("{0}/{1}", Application.streamingAssetsPath, path);
            try
            {
                var webRequest = LoadFromFile(path).webRequest;
                if (webRequest != null && webRequest.isDone)
                {
                    return DownloadHandlerAudioClip.GetContent(webRequest);
                }
                return null;
            }
            catch (Exception ex)
            {
                LogUtil.LogError(ex.Message);
                LogUtil.LogError("Path:" + path);
                return null;
            }
        }

        private static UnityWebRequestAsyncOperation LoadFromFile(string path)
        {
            var enumerator = LoadFromFileEnumerator(path);

            while (enumerator.MoveNext())
                ;

            return enumerator.Current as UnityWebRequestAsyncOperation;
        }

        private static IEnumerator LoadFromFileEnumerator(string path)
        {
            var allPath = "file://" + path;
#if UNITY_ANDROID
            if (!Application.isEditor)
            {
                allPath = path;
            }
#endif
            var request = UnityWebRequestMultimedia.GetAudioClip(allPath, AudioType.MPEG);
            yield return request.SendWebRequest();
            while (!request.isDone)
                ;
        }

        /// <summary>
        /// 获取BoxCollider的八个顶点
        /// </summary>
        /// <param name="boxcollider"></param>
        /// <returns></returns>
        public static Vector3[] GetBoxColliderVertexPositions(BoxCollider boxcollider)
        {
            var vertices = new Vector3[8];
            //下面4个点
            vertices[0] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, -boxcollider.size.y, boxcollider.size.z) * 0.5f);
            vertices[1] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, -boxcollider.size.y, boxcollider.size.z) * 0.5f);
            vertices[2] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, -boxcollider.size.y, -boxcollider.size.z) * 0.5f);
            vertices[3] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, -boxcollider.size.y, -boxcollider.size.z) * 0.5f);
            //上面4个点
            vertices[4] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
            vertices[5] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
            vertices[6] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, boxcollider.size.y, -boxcollider.size.z) * 0.5f);
            vertices[7] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, -boxcollider.size.z) * 0.5f);

            return vertices;
        }
    }
}