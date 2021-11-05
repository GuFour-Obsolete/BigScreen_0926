using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//==============================
//Synopsis  :  LeftPanel
//CreatTime :  2021/9/28 10:32:28
//For       :  Gu4
//==============================

public class LeftPanel : BasePanel
{
    private RectTransform self;

    private void Awake()
    {
        self = transform.TryGet<RectTransform>();
    }

    public override void OnEnter()
    {
        self.anchoredPosition = new Vector2(-3500f, -90f);
        self.DOAnchorPosX(363f, 3f);
    }

    public override void OnExit()
    {
        self.DOAnchorPosX(-3000f, 1f).OnComplete(() => gameObject.SetActive(false));
    }
}