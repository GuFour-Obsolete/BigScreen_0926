using Gu4.Frame;
using System;
using System.Diagnostics;
using UnityEngine;

namespace Gu4.Timer
{
    public delegate void TimerActionObj(object obj);

    /*
     * FileName:    TimerHeap
     * Author:
     * CreateTime:  2019-12-31
     * Description: 延时调用、携程调用
    */

    public class TimerHeap : Singleton<TimerHeap>
    {
        /// <summary>
        /// 每帧事件
        /// </summary>
        private static event Action UpdateFun;

        private static event Action FixedUpdateFun;

        private static uint m_nNextTimerId;
        private static uint m_unTick;
        private static KeyedPriorityQueue<uint, AbsTimerData, ulong> m_queue = new KeyedPriorityQueue<uint, AbsTimerData, ulong>();
        private static Stopwatch m_stopWatch = new Stopwatch();
        private static readonly object m_queueLock = new object();

        //private static TimerHeapStub sStub = (new GameObject("TimerHeapStub")).AddComponent<TimerHeapStub>();

        #region 公有接口

        //public void Init()
        //{
        //    m_queue = new KeyedPriorityQueue<uint, AbsTimerData, ulong>();
        //    m_stopWatch = new Stopwatch();
        //}

        public void AddUpdate(Action action)
        {
            UpdateFun += action;
        }

        public void DelUpdate(Action action)
        {
            UpdateFun -= action;
        }

        public void AddFixedUpdate(Action action)
        {
            FixedUpdateFun += action;
        }

        public void DelFixedUpdate(Action action)
        {
            FixedUpdateFun -= action;
        }

        #region 延时调用接口

        /// <summary>
        /// 添加延时调用
        /// </summary>
        /// <param name="delayTime">开始时间</param>
        /// <param name="handler">回调方法</param>
        public uint AddDelayCall(float delayTime, Action handler, bool needPause = false)
        {
            return AddTimer(delayTime, 0, handler, needPause);
        }

        public uint AddDelayCall(float delayTime, TimerActionObj handler, object args, bool needPause = false)
        {
            return AddTimer(delayTime, 0, handler, args, needPause);
        }

        public uint AddDelayCall<T>(float delayTime, Action<T> handler, T arg1, bool needPause = false)
        {
            return AddTimer(delayTime, 0, handler, arg1, needPause);
        }

        public uint AddDelayCall<T, U>(float delayTime, Action<T, U> handler, T arg1, U arg2, bool needPause = false)
        {
            return AddTimer(delayTime, 0, handler, arg1, arg2, needPause);
        }

        internal uint AddCountTimer(float effectDelayTime, float _callInterval, int count, Action call, bool needPause = false)
        {
            //tmp 临时
            throw new NotImplementedException();
        }

        public uint AddDelayCall<T, U, V>(float delayTime, Action<T, U, V> handler, T arg1, U arg2, V arg3, bool needPause = false)
        {
            return AddTimer(delayTime, 0, handler, arg1, arg2, arg3, needPause);
        }

        /// <summary>
        /// 添加自动重复调用
        /// </summary>
        /// <param name="delayTime">开始时间</param>
        /// <param name="interval">调用间隔</param>
        /// <param name="handler">回调方法</param>
        public uint AddTimer(float delayTime, float interval, Action handler, bool needPause = false)
        {
            uint start = (uint)(delayTime * 1000);
            int iInterval = (int)(interval * 1000);
            var p = GetTimerData(new TimerData(), start, iInterval);
            p.Action = handler;
            p.NeedPause = needPause;
            return AddTimer(p);
        }

        public uint AddTimer(float delayTime, float interval, TimerActionObj handler, object args, bool needPause = false)
        {
            uint start = (uint)(delayTime * 1000);
            int iInterval = (int)(interval * 1000);
            var p = GetTimerData(new TimerDataObj(), start, iInterval);
            p.Action = handler;
            p.Arg1 = args;
            p.NeedPause = needPause;
            return AddTimer(p);
        }

        public uint AddTimer<T>(float delayTime, float interval, Action<T> handler, T arg1, bool needPause = false)
        {
            uint start = (uint)(delayTime * 1000);
            int iInterval = (int)(interval * 1000);
            var p = GetTimerData(new TimerData<T>(), start, iInterval);
            p.Action = handler;
            p.Arg1 = arg1;
            p.NeedPause = needPause;
            return AddTimer(p);
        }

        public uint AddTimer<T, U>(float delayTime, float interval, Action<T, U> handler, T arg1, U arg2, bool needPause = false)
        {
            uint start = (uint)(delayTime * 1000);
            int iInterval = (int)(interval * 1000);
            var p = GetTimerData(new TimerData<T, U>(), start, iInterval);
            p.Action = handler;
            p.Arg1 = arg1;
            p.Arg2 = arg2;
            p.NeedPause = needPause;
            return AddTimer(p);
        }

        public uint AddTimer<T, U, V>(float delayTime, float interval, Action<T, U, V> handler, T arg1, U arg2, V arg3, bool needPause = false)
        {
            uint start = (uint)(delayTime * 1000);
            int iInterval = (int)(interval * 1000);
            var p = GetTimerData(new TimerData<T, U, V>(), start, iInterval);
            p.Action = handler;
            p.Arg1 = arg1;
            p.Arg2 = arg2;
            p.Arg3 = arg3;
            p.NeedPause = needPause;
            return AddTimer(p);
        }

        public uint DelTimer(uint id)
        {
            if (id == 0) return 0;
            lock (m_queueLock)
                m_queue.Remove(id);
            return 0;
        }

        #endregion 延时调用接口

        /// <summary>
        /// 重置定时触发器
        /// </summary>
        public static void Reset()
        {
            ClearEvent(UpdateFun);
            ClearEvent(FixedUpdateFun);

            m_unTick = 0;
            m_nNextTimerId = 0;
            lock (m_queueLock)
                while (m_queue.Count != 0)
                    m_queue.Dequeue();
        }

        /// <summary>
        /// 周期调用触发任务
        /// </summary>
        public static void Tick()
        {
            try
            {
                uint tick = (uint)m_stopWatch.ElapsedMilliseconds;
                m_unTick += tick;
                m_stopWatch.Reset();
                m_stopWatch.Start();

                while (m_queue.Count != 0)
                {
                    AbsTimerData p = null;
                    {
                        lock (m_queueLock)
                            p = m_queue.Peek();
                    }
                    if (p != null)
                    {
                        if (p.NeedPause && Gu4.Tools.DrawUtil.IsPause)
                        {
                            p.UnNextTick += tick;
                        }
                        if (m_unTick < p.UnNextTick)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    {
                        lock (m_queueLock)
                            m_queue.Dequeue();
                    }
                    if (p.NInterval > 0)
                    {
                        p.UnNextTick += (ulong)p.NInterval;
                        {
                            lock (m_queueLock)
                                m_queue.Enqueue(p.NTimerId, p, p.UnNextTick);
                        }
                        p.DoAction();
                    }
                    else
                    {
                        p.DoAction();
                    }
                }
                OnUpdateFun();
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
                UnityEngine.Debug.LogError(e.StackTrace);
            }
        }

        #endregion 公有接口

        //public void Update()
        //{
        //    OnUpdateFun();
        //}

        //public void FixedUpdate()
        //{
        //    OnFixedUpdateFun();
        //}

        private static uint AddTimer(AbsTimerData p)
        {
            lock (m_queueLock)
                m_queue.Enqueue(p.NTimerId, p, p.UnNextTick);
            return p.NTimerId;
        }

        private static T GetTimerData<T>(T p, uint start, int interval) where T : AbsTimerData
        {
            p.NInterval = interval;
            p.NTimerId = ++m_nNextTimerId;
            p.UnNextTick = m_unTick + 1 + start;
            return p;
        }

        public static void OnUpdateFun()
        {
            UpdateFun?.Invoke();
        }

        public static void OnFixedUpdateFun()
        {
            FixedUpdateFun?.Invoke();
        }

        /// <summary>
        /// 移除所有的事件绑定
        /// </summary>
        /// <param name="clearEvent"></param>
        private static void ClearEvent(Action clearEvent)
        {
            if (clearEvent == null) return;
            Delegate[] dels = clearEvent.GetInvocationList();
            foreach (Delegate d in dels)
            {
                //得到方法名
                object delObj = d.GetType().GetProperty("Method").GetValue(d, null);
                string funcName = (string)delObj.GetType().GetProperty("Name").GetValue(delObj, null);

                clearEvent -= d as Action;
            }
        }
    }

    public sealed class TimerHeapStub : MonoBehaviour
    {
        private void Awake()
        {
            // Don't destroyed automatically when loading a new scene
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            TimerHeap.Tick();
        }

        private void FixedUpdate()
        {
            TimerHeap.OnFixedUpdateFun();
        }

        public void OnDisable()
        {
            TimerHeap.Reset();
        }
    }
}