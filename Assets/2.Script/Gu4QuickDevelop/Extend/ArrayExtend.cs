using Gu4.Tools;

//==============================
//Synopsis  :  数组拓展
//CreatTime :  2021/7/9 14:43:36
//For       :  Gu4
//==============================

namespace Gu4.Extend
{
    public static class ArrayExtend
    {
        /// <summary>
        /// 冒泡排序int数组（低效慎用）
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        public static int[] BubbleSort(this int[] intArray)
        {
            if (intArray.Length <= 1)
            {
                LogUtil.LogError("进行排序的数组有点问题");
                return intArray;
            }

            int temp;
            for (int i = 0; i < intArray.Length - 1; i++)
            {
                for (int j = 0; j < intArray.Length - 1 - i; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        temp = intArray[j + 1];
                        intArray[j + 1] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }
            return intArray;
        }
    }
}