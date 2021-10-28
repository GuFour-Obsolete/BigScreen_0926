using System;
using System.Collections.Generic;

namespace Gu4.Extend
{
    public static class ListExtend
    {
        /// <summary>
        /// Add数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="array"></param>
        public static void AddArray<T>(this List<T> list, T[] array)
        {
            if (array.Length < 0) { return; }
            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i]);
            }
        }

        /// <summary>
        /// 随机排列数组元素
        /// </summary>
        /// <param name="ListT"></param>
        /// <returns></returns>
        public static List<T> RandomSort<T>(this List<T> list)
        {
            Random randomNum = new Random();
            int index = 0;
            T temp;
            for (int i = 0; i < list.Count; i++)
            {
                index = randomNum.Next(0, list.Count - 1);
                if (index != i)
                {
                    temp = list[i];
                    list[i] = list[index];
                    list[index] = temp;
                }
            }
            return list;
        }
    }
}