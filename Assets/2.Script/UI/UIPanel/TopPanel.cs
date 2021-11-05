using Gu4.Extend;
using UnityEngine;
using DG.Tweening;

//==============================
//Synopsis  :  TopPanel
//CreatTime :  2021/9/28 10:32:46
//For       :  Gu4
//==============================

public class TopPanel : BasePanel
{
    private RectTransform self;

    private void Awake()
    {
        self = transform.TryGet<RectTransform>();
    }

    public override void OnEnter()
    {
        self.anchoredPosition = new Vector2(40f, -289f);
        self.localScale = Vector2.zero;

        self.DOScale(Vector3.one, 1f);
    }

    public override void OnExit()
    {
        self.DOScale(Vector3.zero, 1f).OnComplete(() => gameObject.SetActive(false));
    }
}