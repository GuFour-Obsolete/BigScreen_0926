using DG.Tweening;
using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==============================
//Synopsis  :  工单统计小面板
//CreatTime :  2021/10/12 15:38:51
//For       :  Gu4
//==============================

public class OrderStatPanel : BasePanel
{
    private RectTransform panel;

    private void Awake()
    {
        panel = transform.TryGet<RectTransform>("Img_Panel");
    }

    public override void OnEnter()
    {
        Vector3 posi = new Vector3(
         Input.mousePosition.x - Screen.width / 2f + panel.TryGet<RectTransform>().sizeDelta.x / 2f,
         Input.mousePosition.y - Screen.height / 2f - panel.TryGet<RectTransform>().sizeDelta.y / 2f, 0f);

        panel.anchoredPosition = posi;
        panel.localScale = new Vector3(1f, 0f, 1f);

        panel.DOScaleY(1f, .4f);
    }

    public override void OnExit()
    {
        //panel.DOScaleY(0f, .4f).OnComplete(() => gameObject.SetActive(false));
        gameObject.SetActive(false);
    }
}