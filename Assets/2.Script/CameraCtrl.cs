using Gu4.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//==============================
//Synopsis  :  �¿�������ƽű�
//CreatTime :  2021/9/17 16:11:44
//For       :  Gu4
//==============================

public class CameraCtrl : MonoBehaviour
{
    private Transform target;
    public float distance = 20f;
    private float zoomDampening = 5.0f;
    private float xDeg = 0.0f;//����ĽǶȼ�¼
    private float yDeg = 0.0f;//����ĽǶ�
    private float currentDistance;//��ǰ����
    private float desiredDistance;//Ԥ�ھ���
    private Quaternion desiredRotation;//Ԥ����ת
    private Vector3 desiredFocusPosi = new Vector2();

    private void OnEnable()
    {
        target = GameObject.Find("CamFocus").transform;

        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);

        desiredDistance = 5f;
        yDeg = 30f;
        xDeg = 0f;

        desiredFocusPosi = new Vector3(0f, 0f, 0f);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && !OperationUtil.m_Instance.IsClickUI /*&& GameManager.m_Instance.camView == CameraViewMode.Normal*/)
        {
            xDeg += Input.GetAxis("Mouse X") * 5f;
            //yDeg -= Input.GetAxis("Mouse Y") * 5f;
        }
        yDeg = ClampAngle(yDeg, 3f, 50f);

        desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * zoomDampening);

        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 40f * Mathf.Abs(desiredDistance);

        desiredDistance = Mathf.Clamp(desiredDistance, 3f, 7f);
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
        distance = Mathf.Abs(Vector3.Distance(transform.position, target.position));

        transform.position = target.position - (transform.rotation * Vector3.forward * currentDistance);
        target.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}

public enum CameraViewMode
{
    Normal = 0,
    Observe = 1
}