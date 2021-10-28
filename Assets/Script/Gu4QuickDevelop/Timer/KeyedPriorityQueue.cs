namespace Gu4.Timer
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.InteropServices;

    [Serializable]
    public class KeyedPriorityQueue<K, V, P> where V : class
    {
        private List<HeapNode<K, V, P>> heap;
        private HeapNode<K, V, P> placeHolder;
        private Comparer<P> priorityComparer;

        public event EventHandler<KeyedPriorityQueueHeadChangedEventArgs<V>> FirstElementChanged;

        public KeyedPriorityQueue()
        {
            heap = new List<HeapNode<K, V, P>>();
            priorityComparer = Comparer<P>.Default;
            placeHolder = new HeapNode<K, V, P>();
            heap.Add(new HeapNode<K, V, P>());
        }

        public void Clear()
        {
            heap.Clear();
            Count = 0;
        }

        public V Dequeue()
        {
            V local = (Count < 1) ? default : DequeueImpl();
            V newHead = (Count < 1) ? default : heap[1].Value;
            RaiseHeadChangedEvent(default, newHead);
            return local;
        }

        private V DequeueImpl()
        {
            V local = heap[1].Value;
            heap[1] = heap[Count];
            heap[Count--] = placeHolder;
            Heapify(1);
            return local;
        }

        public void Enqueue(K key, V value, P priority)
        {
            V local = (Count > 0) ? heap[1].Value : default;
            int num = ++Count;
            int num2 = num / 2;
            if (num == heap.Count)
            {
                heap.Add(placeHolder);
            }
            while ((num > 1) && IsHigher(priority, heap[num2].Priority))
            {
                heap[num] = heap[num2];
                num = num2;
                num2 = num / 2;
            }
            heap[num] = new HeapNode<K, V, P>(key, value, priority);
            V newHead = heap[1].Value;
            if (!newHead.Equals(local))
            {
                RaiseHeadChangedEvent(local, newHead);
            }
        }

        public V FindByPriority(P priority, Predicate<V> match)
        {
            if (Count >= 1)
            {
                return Search(priority, 1, match);
            }
            return default;
        }

        private void Heapify(int i)
        {
            int num = 2 * i;
            int num2 = num + 1;
            int j = i;
            if ((num <= Count) && IsHigher(heap[num].Priority, heap[i].Priority))
            {
                j = num;
            }
            if ((num2 <= Count) && IsHigher(heap[num2].Priority, heap[j].Priority))
            {
                j = num2;
            }
            if (j != i)
            {
                Swap(i, j);
                Heapify(j);
            }
        }

        protected virtual bool IsHigher(P p1, P p2)
        {
            return (priorityComparer.Compare(p1, p2) < 1);
        }

        public V Peek()
        {
            if (Count >= 1)
            {
                return heap[1].Value;
            }
            return default;
        }

        private void RaiseHeadChangedEvent(V oldHead, V newHead)
        {
            if (oldHead != newHead)
            {
                FirstElementChanged?.Invoke(this, new KeyedPriorityQueueHeadChangedEventArgs<V>(oldHead, newHead));
            }
        }

        public V Remove(K key)
        {
            if (Count >= 1)
            {
                V oldHead = heap[1].Value;
                for (int i = 1; i <= Count; i++)
                {
                    if (heap[i].Key.Equals(key))
                    {
                        V local2 = heap[i].Value;
                        Swap(i, Count);
                        heap[Count--] = placeHolder;
                        Heapify(i);
                        V local3 = heap[1].Value;
                        if (!oldHead.Equals(local3))
                        {
                            RaiseHeadChangedEvent(oldHead, local3);
                        }
                        return local2;
                    }
                }
            }
            return default;
        }

        private V Search(P priority, int i, Predicate<V> match)
        {
            V local = default;
            if (IsHigher(heap[i].Priority, priority))
            {
                if (match(heap[i].Value))
                {
                    local = heap[i].Value;
                }
                int num = 2 * i;
                int num2 = num + 1;
                if ((local == null) && (num <= Count))
                {
                    local = Search(priority, num, match);
                }
                if ((local == null) && (num2 <= Count))
                {
                    local = Search(priority, num2, match);
                }
            }
            return local;
        }

        private void Swap(int i, int j)
        {
            HeapNode<K, V, P> node = heap[i];
            heap[i] = heap[j];
            heap[j] = node;
        }

        public int Count { get; private set; }

        public ReadOnlyCollection<K> Keys
        {
            get
            {
                List<K> list = new List<K>();
                for (int i = 1; i <= Count; i++)
                {
                    list.Add(heap[i].Key);
                }
                return new ReadOnlyCollection<K>(list);
            }
        }

        public ReadOnlyCollection<V> Values
        {
            get
            {
                List<V> list = new List<V>();
                for (int i = 1; i <= Count; i++)
                {
                    list.Add(heap[i].Value);
                }
                return new ReadOnlyCollection<V>(list);
            }
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        private struct HeapNode<KK, VV, PP>
        {
            public KK Key;
            public VV Value;
            public PP Priority;

            public HeapNode(KK key, VV value, PP priority)
            {
                Key = key;
                Value = value;
                Priority = priority;
            }
        }
    }
}