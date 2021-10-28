using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

//==============================
//Synopsis  :   ”∆µ√Ê∞Â
//CreatTime :  2021/9/29 14:56:42
//For       :  Gu4
//==============================

public class VideoPanel : BasePanel
{
    private Button btn_Mask;

    private VideoPlayer videoPlayer;

    private Transform panel;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        btn_Mask = transform.TryGet<Button>("Btn_Mask");
        videoPlayer = transform.TryGet<VideoPlayer>("Panel/Video Player");
        panel = transform.Find("Panel");
        canvasGroup = transform.TryGet<CanvasGroup>();
    }

    public override void OnEnter()
    {
        canvasGroup.alpha = 1f;
        //panel.localPosition = new Vector3(
        //    Input.mousePosition.x - Screen.width / 2f + panel.TryGet<RectTransform>().sizeDelta.x / 2f,
        //    Input.mousePosition.y - Screen.height / 2f - panel.TryGet<RectTransform>().sizeDelta.y / 2f, 0f);

        Vector3 posi = new Vector3(
            Input.mousePosition.x - Screen.width / 2f + panel.TryGet<RectTransform>().sizeDelta.x / 2f,
            Input.mousePosition.y - Screen.height / 2f - panel.TryGet<RectTransform>().sizeDelta.y / 2f, 0f);

        panel.DOLocalMove(posi, 1f);

        btn_Mask.onClick.AddListener(btnMaskClickEvent);
        videoPlayer.Play();
    }

    public override void OnExit()
    {
        canvasGroup.DOFade(0f, 1f).OnComplete(() => transform.SetActive(false));
        videoPlayer.Stop();
        btn_Mask.onClick.RemoveAllListeners();
    }

    private void btnMaskClickEvent()
    {
        UIManager.m_Instance.ClosePanel("VideoPanel");
    }
}