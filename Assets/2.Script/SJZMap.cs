using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Gu4.Extend;
using UnityEngine.EventSystems;

//==============================
//Synopsis  :
//CreatTime :  2021/9/29 16:55:12
//For       :  Gu4
//==============================

public class SJZMap : MonoBehaviour
{
    //private SpriteRenderer sprenderer;

    //private Transform[] points;

    //private Vector3[] posis;

    //private void Awake()
    //{
    //    sprenderer = transform.GetComponent<SpriteRenderer>();
    //    sprenderer.color = new Color(1f, 1f, 1f, 0f);

    //    posis = new Vector3[] { new Vector3(-0.309f,-0.565f,0f) , new Vector3(0.859f,-0.087f,0f),
    //        new Vector3(0.469f,-0.605f,0f),new Vector3(0.017f,-0.064f,0f)};
    //}

    //public void enter(float dura = 2f)
    //{
    //    sprenderer.DOFade(1f, dura).OnComplete(() =>
    //    {
    //        //for (int i = 0; i < transform.childCount; i++)
    //        //{
    //        //    points[i] = transform.GetChild(i);
    //        //    transform.GetChild(i).gameObject.SetActive(true);
    //        //    points[i].AddEventTrigger(EventTriggerType.PointerClick, (BaseEventData args) =>
    //        //    {
    //        //        UIManager.m_Instance.CloseAllPanel();
    //        //        SceneManager.LoadScene(1);
    //        //    });
    //        //}
    //        points = GameManager.m_Instance.mainMap.MapPoint3Ctrl(true);
    //        for (int i = 0; i < points.Length; i++)
    //        {
    //            points[i].SetParent(GameManager.m_Instance.sjzMap.transform/*.Find("中国地图/河北地图/南网地图/SJZMap")*/);
    //            points[i].localPosition = posis[i];
    //        }
    //    });
    //}

    //public void Exit()
    //{
    //    points = GameManager.m_Instance.mainMap.Get_Point_Districts(false);
    //    sprenderer.DOFade(0f, .5f);
    //}
}