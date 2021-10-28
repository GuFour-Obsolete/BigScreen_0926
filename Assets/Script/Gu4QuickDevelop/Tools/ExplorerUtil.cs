using Gu4.Frame;
using System;
using System.Collections;
using UnityEngine;

namespace Gu4.Tools
{
    /// <summary>
    /// 资源管理类
    /// </summary>
    public class ExplorerUtil : Singleton<ExplorerUtil>
    {
        /// <summary>
        /// 进度
        /// </summary>
        public int m_Prog { get; private set; }

        /// <summary>
        /// 从文件异步加载所有AB资源
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="offset">加载偏移量</param>
        /// <param name="beginCallBack">开始加载回调</param>
        /// <param name="callBack">进度回调</param>
        /// <param name="endCallBack">加载结束回调</param>
        /// <returns></returns>
        public IEnumerator LoadABFromFile_Async(string path, ulong offset, Action beginCallBack = null, Action<int> callBack = null, Action<AssetBundle> endCallBack = null)
        {
            m_Prog = 0;
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            beginCallBack?.Invoke();
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path, 0, offset);
            while (!request.isDone)
            {
                m_Prog = (int)(request.progress * 100);
                callBack?.Invoke(m_Prog);
                yield return wait;
            }
            while (m_Prog < 100)
            {
                m_Prog++;
                callBack?.Invoke(m_Prog);
                yield return wait;
            }
            yield return request;
            AssetBundle ab = request.assetBundle;
            endCallBack?.Invoke(ab);
        }
    }
}