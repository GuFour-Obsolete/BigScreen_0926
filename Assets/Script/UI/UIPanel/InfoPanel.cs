using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

//==============================
//Synopsis  :  查看详情面板
//CreatTime :  2021/9/28 9:8:48
//For       :  Gu4
//==============================

public class InfoPanel : BasePanel
{
    //private CanvasGroup canvasGroup;

    //private Button btn_Mask;
    //private Button btn_Enter;

    //private MapPoint1[] mapPoints;

    //private void Awake()
    //{
    //    canvasGroup = transform.TryGet<CanvasGroup>();

    //    btn_Mask = transform.TryGet<Button>("Btn_Mask");
    //    btn_Enter = transform.TryGet<Button>("Btn_Enter");

    //    //mapPoints = GameManager.m_Instance.mainMap.mao;
    //}

    //public override void OnEnter()
    //{
    //    btn_Mask.onClick.AddListener(MaskClickEvent);
    //    btn_Enter.onClick.AddListener(EnterClickEvent);

    //    transform.TryGet<RectTransform>().offsetMax = Vector2.zero;
    //    transform.TryGet<RectTransform>().offsetMin = Vector2.zero;
    //    canvasGroup.alpha = 0f;
    //    btn_Enter.transform.TryGet<RectTransform>().anchoredPosition = new Vector2(1200f, 0f);
    //    canvasGroup.DOFade(1f, 1f);
    //    btn_Enter.transform.TryGet<RectTransform>().DOAnchorPosX(900f, 1f);
    //}

    //public override void OnExit()
    //{
    //    btn_Mask.onClick.RemoveAllListeners();
    //    btn_Enter.onClick.RemoveAllListeners();

    //    canvasGroup.DOFade(0f, 1f).OnComplete(() => gameObject.SetActive(false));
    //}

    //private void MaskClickEvent()
    //{
    //    UIManager.m_Instance.CloseAllPanel();
    //    StartCoroutine(PlayPanelAnim());
    //    Transform camCtrl = GameManager.m_Instance.cam.transform;
    //    camCtrl.SetParent(null);
    //    camCtrl.DOMove(new Vector3(13.14f, -2.84f, 43.53f), 2f);
    //    camCtrl.DORotate(new Vector3(-44.748f, -52.28f, 61.432f), 2f);
    //    for (int i = 0; i < mapPoints.Length; i++)
    //    {
    //        mapPoints[i].gameObject.SetActive(true);
    //    }
    //}

    //private IEnumerator PlayPanelAnim()
    //{
    //    UIManager.m_Instance.OpenPanel("LeftPanel");
    //    UIManager.m_Instance.OpenPanel("RightPanel");

    //    yield return null;

    //    UIManager.m_Instance.OpenPanel("TopPanel");
    //}

    //private void EnterClickEvent()
    //{
    //    UIManager.m_Instance.ClosePanel("InfoPanel");

    //    for (int i = 0; i < mapPoints.Length; i++)
    //    {
    //        mapPoints[i].gameObject.SetActive(false);
    //    }

    //    Transform cameraCtrl = GameManager.m_Instance.cam.transform;
    //    cameraCtrl.SetParent(null);
    //    cameraCtrl.DOMove(new Vector3(9.893f, 2.856f, 42.935f), 2f);//(9.924f,2.87f,43.41f)
    //    cameraCtrl.DORotate(new Vector3(0f, 0f, 0f), 2f);

    //    SJZMap sjzMap = GameManager.m_Instance.sjzMap;
    //    sjzMap.enter();
    //    //GameObject sjzMap = Instantiate(Resources.Load<GameObject>("Prefab/Model/石家庄地图"));
    //}
}