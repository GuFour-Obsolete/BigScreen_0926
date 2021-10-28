using DG.Tweening;
using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==============================
//Synopsis  :  RightPanel
//CreatTime :  2021/9/28 10:32:37
//For       :  Gu4
//==============================

public class RightPanel : BasePanel
{
    private RectTransform self;

    private void Awake()
    {
        self = transform.TryGet<RectTransform>();
    }

    public override void OnEnter()
    {
        self.anchoredPosition = new Vector2(3500f, -90f);
        self.DOAnchorPosX(-360f, 3f);
    }

    public override void OnExit()
    {
        self.DOAnchorPosX(3000f, 1f).OnComplete(() => gameObject.SetActive(false));
    }
}