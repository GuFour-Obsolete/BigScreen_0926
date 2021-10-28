using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gu4.Extend;
using UnityEngine.EventSystems;

//==============================
//Synopsis  :  ·¿×Ó½Å±¾
//CreatTime :  2021/9/29 14:47:18
//For       :  Gu4
//==============================

public class House : MonoBehaviour
{
    private Transform cameraIcon;

    private Transform cube;

    private void Awake()
    {
        cameraIcon = transform.Find("CameraIcon");
        cube = transform.Find("Cube");
    }

    private void Start()
    {
        cameraIcon.AddEventTrigger(EventTriggerType.PointerClick, (BaseEventData arg) => UIManager.m_Instance.OpenPanel("VideoPanel"));

        UIManager.m_Instance.OpenPanel("LeftPanel2_1");

        UIManager.m_Instance.OpenPanel("LeftPanel2_2");

        UIManager.m_Instance.OpenPanel("RightPanel2_1");

        UIManager.m_Instance.OpenPanel("RightPanel2_2");
    }

    private void Update()
    {
        cameraIcon.LookAt(Camera.main.transform, Vector3.up);
        cameraIcon.localPosition = new Vector3(cameraIcon.localPosition.x, cube.localScale.y + .5f, cameraIcon.localPosition.z);
    }
}