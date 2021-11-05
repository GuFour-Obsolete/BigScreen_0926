namespace Gu4.Timer
{
    using System;

    public sealed class KeyedPriorityQueueHeadChangedEventArgs<T> : EventArgs where T : class
    {
        public KeyedPriorityQueueHeadChangedEventArgs(T oldFirstElement, T newFirstElement)
        {
            OldFirstElement = oldFirstElement;
            NewFirstElement = newFirstElement;
        }

        public T NewFirstElement { get; }

        public T OldFirstElement { get; }
    }
}