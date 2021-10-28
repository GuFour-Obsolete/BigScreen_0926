using Gu4.Frame;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//==============================
//Synopsis  :  GameObj组件工具类
//CreatTime :  2021/8/3 14:56:18
//For       :  Gu4
//==============================

namespace Gu4.Tools
{
    public class ComponentUtil : Singleton<ComponentUtil>
    {
        public void AddEventTrigger(GameObject go, EventTriggerType type, UnityAction<BaseEventData> action)
        {
            //获取事件系统
            go.TryGetComponent<EventTrigger>(out EventTrigger trigger);
            if (trigger == null)
                trigger = go.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = type;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(action);
            trigger.triggers.Add(entry);
        }
    }
}