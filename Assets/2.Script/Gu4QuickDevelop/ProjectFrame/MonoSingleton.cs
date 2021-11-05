using UnityEngine;

namespace Gu4.Frame
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        private static object m_lock = new object();

        public static T m_Instance
        {
            get
            {
                lock (m_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError($"单例类{typeof(T)}发生重复!");
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();

                            _instance = singleton.AddComponent<T>();
                            singleton.name = typeof(T).ToString();

                            DontDestroyOnLoad(singleton);

                            return _instance;
                        }
                    }

                    return _instance;
                }
            }
        }

        public virtual void OnDestroy()
        {
            _instance = null;
        }
    }
}