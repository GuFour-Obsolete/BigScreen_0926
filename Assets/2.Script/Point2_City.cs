using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gu4.Extend;
using Gu4.Tools;
using UnityEngine.EventSystems;
using DG.Tweening;
using Gu4.Frame;

//==============================
//Synopsis  :  地图标记点2
//CreatTime :  2021/10/11 19:36:47
//For       :  Gu4
//==============================

public class Point2_City : MonoBehaviour
{
    private SpriteRenderer panel;

    private Transform[] mapPoint2;

    private MainMap mainMap;

    private bool canReturn;

    private Vector3[] posis = new Vector3[] { new Vector3(0.676f,1.312f,-0.731f), new Vector3(1.537f, 1.312f, 0.043f),
            new Vector3(-1.584f,1.312f,-0.233f) ,new Vector3(-0.362f,1.312f,0.585f),new Vector3(1.578f,1.312f,1.144f),
        new Vector3(0.637f,1.312f,2.066f)};

    private void Awake()
    {
        panel = transform.TryGet<SpriteRenderer>("Panel");
        //panel.color = new Color(1f, 1f, 1f, 1f);
        //transform.AddEventTrigger(EventTriggerType.PointerEnter, MapPoint2Enter);
        //transform.AddEventTrigger(EventTriggerType.PointerExit, MapPoint2Exit);
        transform.AddEventTrigger(EventTriggerType.PointerClick, PanelClickEvent);

        mapPoint2 = GameManager.m_Instance.mainMap.mapPoint2;
        mainMap = GameManager.m_Instance.mainMap;
    }

    private void OnEnable()
    {
        canReturn = true;
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

    private void PanelClickEvent(BaseEventData data)
    {
        UIManager.m_Instance.ClosePanel("OrderStatPanel");
        GameManager.m_Instance.mainMap.MapPoint2Ctrl(false);
        GameManager.m_Instance.mainMap.SJZMapEnter();
        //GameManager.m_Instance.cam.DOMove(new Vector3(9.93f, -1.031f, 48.636f), 2f);
        //GameManager.m_Instance.cam.DORotate(new Vector3(45f, 0f, 0f), 2f);

        UIManager.m_Instance.CloseAllPanel();
        UIManager.m_Instance.OpenPanel("LeftPanel2_1");
        UIManager.m_Instance.OpenPanel("LeftPanel2_2");
        UIManager.m_Instance.OpenPanel("RightPanel2_1");
        UIManager.m_Instance.OpenPanel("RightPanel2_2");

        //GameManager.m_Instance.pointLight.DOIntensity(1f, 2f);
        GameManager.m_Instance.gameProgress = 1;
    }

    private void Update()
    {
        //panel.transform.DOLookAt(Camera.main.transform.position, .5f, AxisConstraint.Y, Vector3.up);
        //panel.transform.LookAt(Camera.main.transform);

        if (Input.GetMouseButtonDown(1) && canReturn == true)
        {
            ReturnEvent();
            canReturn = false;
        }
    }

    private void ReturnEvent()
    {
        for (int i = 0; i < mapPoint2.Length; i++)
        {
            mapPoint2[i] = ObjectPools.m_Instance.GetObject("Model/MapPoint2").transform;
            mapPoint2[i].SetParent(mainMap.southMap);
            mapPoint2[i].localPosition = posis[i];
            mapPoint2[i].localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        mapPoint2[5].Find("Panel").localPosition = new Vector3(0f, .6f, 0f);
    }
}