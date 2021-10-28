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

    /// <summary>
    /// �ƶ��������
    /// </summary>
    /// <param name="target"></param>
    /// <param name="distance"></param>
    /// <param name="enterObserve"></param>
    //public void MoveFocus(Transform target, float distance = -1f, bool enterObserve = false)
    //{
    //    if (enterObserve)
    //        GameManager.m_Instance.camView = CameraViewMode.Observe;
    //    //target.DOMove(new Vector3(target.position.x, .1f, target.position.z), 1.5f);
    //    this.target.position = new Vector3(target.position.x, .1f, target.position.z);
    //    if (distance < 3f)
    //        return;
    //    distance = distance > 60f ? 60f : distance;
    //    desiredDistance = distance;
    //}

    /// <summary>
    /// ����Ѳ�춯��
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    //public Tween YieldPatrolTween(Transform[] line)
    //{
    //    Vector3[] path = new Vector3[line.Length];
    //    for (int i = 0; i < line.Length; i++)
    //    {
    //        path[i] = line[i].position;
    //    }

    //    return target.DOPath(path, path.Length * 5f, PathType.Linear, PathMode.Full3D, 10).SetEase(Ease.Linear).Pause();
    //}

    private void OnEnable()
    {
        //new Vector3(10.64f,-2.118869f,49.14441f)
        //if (!target)
        //{
        //    GameObject go = new GameObject("Cam Target");
        //    go.transform.position = transform.position + (transform.forward * distance);
        //    target = go.transform;
        //}

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
        //if (GameManager.m_Instance.camView != CameraViewMode.Normal)
        //    return;

        if (Input.GetMouseButton(0) && !OperationUtil.m_Instance.IsClickUI /*&& GameManager.m_Instance.camView == CameraViewMode.Normal*/)
        {
            xDeg += Input.GetAxis("Mouse X") * 5f;
            //yDeg -= Input.GetAxis("Mouse Y") * 5f;
        }
        yDeg = ClampAngle(yDeg, 3f, 50f);

        // ���������ת
        desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * zoomDampening);

        // Ӱ��scrollwheel�佹����
        //if (GameManager.m_Instance.camView == CameraViewMode.Normal)
        //{
        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 40f * Mathf.Abs(desiredDistance);
        //}
        desiredDistance = Mathf.Clamp(desiredDistance, 3f, 7f);
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
        distance = Mathf.Abs(Vector3.Distance(transform.position, target.position));

        transform.position = target.position - (transform.rotation * Vector3.forward * currentDistance);
        target.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);

        //if (Input.GetMouseButton(1) && !OperationUtil.m_Instance.IsClickUI /*&& GameManager.m_Instance.camView == CameraViewMode.Normal*/)
        //{
        //    desiredFocusPosi.x = -Input.GetAxis("Mouse X") * Time.deltaTime * currentDistance;
        //    desiredFocusPosi.z = -Input.GetAxis("Mouse Y") * Time.deltaTime * currentDistance;
        //}

        //if (GameManager.m_Instance.camView == CameraViewMode.Normal)
        //{
        //    target.Translate(desiredFocusPosi, Space.Self);
        //}
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