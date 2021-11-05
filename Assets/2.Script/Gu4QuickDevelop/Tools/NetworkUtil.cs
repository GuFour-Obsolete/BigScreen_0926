using Gu4.Frame;
using UnityEngine;

namespace Gu4.Tools
{
    //=============================================================
    //==创建人：Gu4                                              ==
    //==创建时间：2020/10/10                                     ==
    //==功能说明：该类为网络工具类                               ==
    //=============================================================
    public class NetworkUtil : Singleton<NetworkUtil>
    {
        public static bool IsWifi
        {
            get
            {
                return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
            }
        }

        public static bool IsMobileNet
        {
            get
            {
                return Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork;
            }
        }
    }
}