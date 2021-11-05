using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gu4.Extend;
using UnityEngine.UI;
using DG.Tweening;

//==============================
//Synopsis  :  地图上标记点切换面板
//CreatTime :  2021/10/11 11:28:26
//For       :  Gu4
//==============================

public class InfoSwitchOverPanel : BasePanel
{
    //private Button btn_InWay;
    //private Button btn_Stat;

    //private CanvasGroup canvasGroup;

    //private MapPoint1[] mapPoint1s;

    //private void Awake()
    //{
    //    btn_InWay = transform.TryGet<Button>("Btn_InWay");
    //    btn_Stat = transform.TryGet<Button>("Btn_Stat");
    //    canvasGroup = transform.TryGet<CanvasGroup>();
    //    btn_InWay.onClick.AddListener(InWayClick);
    //    btn_Stat.onClick.AddListener(StatClick);

    //    mapPoint1s = GameManager.m_Instance.mapPoint1s;
    //}

    //public override void OnEnter()
    //{
    //    canvasGroup.alpha = 0f;
    //    canvasGroup.DOFade(1f, 1f);
    //}

    //public override void OnExit()
    //{
    //    canvasGroup.DOFade(0f, 1f).OnComplete(() => gameObject.SetActive(false));
    //}

    //private void InWayClick()
    //{
    //    for (int i = 0; i < mapPoint1s.Length; i++)
    //    {
    //        mapPoint1s[i].PlayNumberAnim(40 + i * 7);
    //    }
    //}

    //private void StatClick()
    //{
    //    for (int i = 0; i < mapPoint1s.Length; i++)
    //    {
    //        mapPoint1s[i].CloseThis();
    //    }
    //}
}