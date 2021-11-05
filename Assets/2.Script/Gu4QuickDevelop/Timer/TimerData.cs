using System;

namespace Gu4.Timer
{
    /// <summary>
    /// 定时器抽象实体
    /// </summary>
    internal abstract class AbsTimerData
    {
        public uint NTimerId { get; set; }
        public bool NeedPause { get; set; }

        public int NInterval { get; set; }

        public ulong UnNextTick { get; set; }

        public abstract Delegate Action
        {
            get;
            set;
        }

        public abstract void DoAction();
    }

    /// <summary>
    /// 无参数定时器实体
    /// </summary>
    internal class TimerData : AbsTimerData
    {
        private Action m_action;

        public override Delegate Action
        {
            get { return m_action; }
            set { m_action = value as Action; }
        }

        public override void DoAction()
        {
            m_action();
        }
    }

    /// <summary>
    /// 1个参数定时器实体
    /// </summary>
    /// <typeparam name="T">参数1</typeparam>
    internal class TimerData<T> : AbsTimerData
    {
        private Action<T> m_action;

        public override Delegate Action
        {
            get { return m_action; }
            set { m_action = value as Action<T>; }
        }

        public T Arg1 { get; set; }

        public override void DoAction()
        {
            m_action(Arg1);
        }
    }

    internal class TimerDataObj : AbsTimerData
    {
        private TimerActionObj m_action;

        public override Delegate Action
        {
            get { return m_action; }
            set { m_action = value as TimerActionObj; }
        }

        public object Arg1 { get; set; }

        public override void DoAction()
        {
            m_action(Arg1);
        }
    }

    /// <summary>
    /// 2个参数定时器实体
    /// </summary>
    /// <typeparam name="T">参数1</typeparam>
    /// <typeparam name="U">参数2</typeparam>
    internal class TimerData<T, U> : AbsTimerData
    {
        private Action<T, U> m_action;

        public override Delegate Action
        {
            get { return m_action; }
            set { m_action = value as Action<T, U>; }
        }

        public T Arg1 { get; set; }

        public U Arg2 { get; set; }

        public override void DoAction()
        {
            m_action(Arg1, Arg2);
        }
    }

    /// <summary>
    /// 3个参数定时器实体
    /// </summary>
    /// <typeparam name="T">参数1</typeparam>
    /// <typeparam name="U">参数2</typeparam>
    /// <typeparam name="V">参数3</typeparam>
    internal class TimerData<T, U, V> : AbsTimerData
    {
        private Action<T, U, V> m_action;

        public override Delegate Action
        {
            get { return m_action; }
            set { m_action = value as Action<T, U, V>; }
        }

        public T Arg1 { get; set; }

        public U Arg2 { get; set; }

        public V Arg3 { get; set; }

        public override void DoAction()
        {
            m_action(Arg1, Arg2, Arg3);
        }
    }
}