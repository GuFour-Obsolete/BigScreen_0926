namespace Gu4.Extend
{
    public static class ObjectExtend
    {
        /// <summary>
        /// 获取元组元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="index">元组索引从1开始</param>
        /// <returns></returns>
        public static T GetValue<T>(this object obj, int index)
        {
            T t = (T)obj.GetType().GetField("Item" + index).GetValue(obj);
            return t;
        }
    }
}