using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gu4.Extend;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//==============================
//Synopsis  :
//CreatTime :  2021/10/13 9:17:44
//For       :  Gu4
//==============================

public class RoadCameras : MonoBehaviour
{
    private Transform[] cameraIcon;
    public Transform modelHouses;

    private void Awake()
    {
        cameraIcon = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            cameraIcon[i] = transform.GetChild(i);
            cameraIcon[i].AddEventTrigger(EventTriggerType.PointerClick, (BaseEventData arg) => UIManager.m_Instance.OpenPanel("VideoPanel"));
        }

        UIManager.m_Instance.OpenPanel("LeftPanel2_1");
        UIManager.m_Instance.OpenPanel("LeftPanel2_2");
        UIManager.m_Instance.OpenPanel("RightPanel2_1");
        UIManager.m_Instance.OpenPanel("RightPanel2_2");

        //for (int i = 0; i < modelHouses.childCount; i++)
        //{
        //    modelHouses.GetChild(i).localScale = Vector3.one * .5f;
        //}
    }

    private void Update()
    {
        for (int i = 0; i < cameraIcon.Length; i++)
        {
            cameraIcon[i].LookAt(Camera.main.transform);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(0);
            UIManager.m_Instance.CleanAllPanel();
        }
    }
}