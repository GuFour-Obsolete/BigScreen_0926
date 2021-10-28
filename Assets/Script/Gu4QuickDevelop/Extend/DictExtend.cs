using System.Collections.Generic;

namespace Gu4.Extend
{
    //==============================
    //Synopsis  : 字典拓展
    //CreatTime :  2021/7/15 14:33:9
    //For       :  Gu4
    //==============================

    public static class DictExtend
    {
        /// <summary>
        /// TryGetValue
        /// </summary>
        public static Tvalue GetValue<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
        {
            Tvalue value = default(Tvalue);
            dict.TryGetValue(key, out value);
            return value;
        }

        /// <summary>
        /// 通过Key获取Value
        /// </summary>
        public static Tkey GetKey<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tvalue value)
        {
            Tkey kay = default(Tkey);
            foreach (KeyValuePair<Tkey, Tvalue> item in dict)
            {
                if (item.Value.Equals(value))
                {
                    kay = item.Key;
                }
            }
            return kay;
        }
    }
}