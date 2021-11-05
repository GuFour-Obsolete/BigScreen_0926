using System;
using System.Threading;

/// <summary>
/// 普通单例类
/// </summary>
namespace Gu4.Frame
{
    public class Singleton<T> where T : new()
    {
        private static T s_singleton = default;
        private static readonly object s_objectLock = new object();

        public static T m_Instance
        {
            get
            {
                if (s_singleton == null)
                {
                    object obj;
                    Monitor.Enter(obj = s_objectLock);             //加锁防止多线程创建单例
                    try
                    {
                        if (s_singleton == null)
                        {
                            s_singleton = (default(T) == null) ? Activator.CreateInstance<T>() : default;//创建单例的实例
                        }
                    }
                    finally
                    {
                        Monitor.Exit(obj);
                    }
                }
                return s_singleton;
            }
        }

        protected Singleton()
        {
            Initialize();
        }

        public virtual bool Initialize()
        {
            return true;
        }
    }
}