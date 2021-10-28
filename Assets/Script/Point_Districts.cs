using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gu4.Extend;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;

//==============================
//Synopsis  :  地图标记点3
//CreatTime :  2021/10/12 17:36:0
//For       :  Gu4
//==============================

public class Point_Districts : MonoBehaviour
{
    private SpriteRenderer panel;

    private void Awake()
    {
        panel = transform.TryGet<SpriteRenderer>("Panel");
        panel.color = new Color(1f, 1f, 1f, 1f);
        //transform.AddEventTrigger(EventTriggerType.PointerEnter, MapPoint2Enter);
        //transform.AddEventTrigger(EventTriggerType.PointerExit, MapPoint2Exit);
        transform.AddEventTrigger(EventTriggerType.PointerClick, BubbleClick);
    }

    private void MapPoint2Enter(BaseEventData data)
    {
        panel.DOFade(1f, .5f);

        //UIManager.m_Instance.OpenPanel("OrderStatPanel");
    }

    private void MapPoint2Exit(BaseEventData data)
    {
        panel.DOFade(0f, .5f);

        //UIManager.m_Instance.ClosePanel("OrderStatPanel");
    }

    private void BubbleClick(BaseEventData data)
    {
        UIManager.m_Instance.CleanAllPanel();
        SceneManager.LoadScene(1);
    }
}