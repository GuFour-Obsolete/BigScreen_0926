using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

//==============================
//Synopsis  :
//CreatTime :  2021/9/28 15:56:19
//For       :  Gu4
//==============================

public class LeftPanel2_1 : BasePanel
{
    private RectTransform self;

    private void Awake()
    {
        self = transform.TryGet<RectTransform>();
        transform.AddEventTrigger(EventTriggerType.PointerEnter, (BaseEventData data) => transform.DOScale(Vector3.one * 1.2f, .5f));
        transform.AddEventTrigger(EventTriggerType.PointerExit, (BaseEventData data) => transform.DOScale(Vector3.one * .8f, .5f));
    }

    public override void OnEnter()
    {
        self.anchoredPosition = new Vector2(-1000f, 300f);
        self.DOAnchorPosX(60f, 1f);
    }

    public override void OnExit()
    {
        self.DOAnchorPosX(-1000f, 1f).OnComplete(() => gameObject.SetActive(false));
    }
}