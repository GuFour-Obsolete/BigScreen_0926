using Gu4.Extend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

//==============================
//Synopsis  :  ��ͼ��״��λ
//CreatTime :  2021/9/26 16:23:57
//For       :  Gu4
//==============================

public class Point_City : MonoBehaviour
{
    private TextMesh number;
    private TextMesh city;
    private Transform cube;
    private SpriteRenderer panel;
    private bool isSelect = false;
    private Transform[] points_City;

    private void Awake()
    {
        number = transform.TryGet<TextMesh>("Num");
        city = transform.TryGet<TextMesh>("Num/City");
        cube = transform.Find("Cube");
        panel = transform.TryGet<SpriteRenderer>("Panel");
        panel.color = new Color(1f, 1f, 1f, 0f);

        //cube.AddEventTrigger(EventTriggerType.PointerClick, CubeClickEvent);
        //panel.transform.AddEventTrigger(EventTriggerType.PointerClick, PanelClickEvent);
        cube.AddEventTrigger(EventTriggerType.PointerEnter, PointerEnterPiller);
        cube.AddEventTrigger(EventTriggerType.PointerExit, PointerExitPiller);

        points_City = GameManager.m_Instance.mainMap.Points_City;
    }

    private void PointerEnterPiller(BaseEventData data)
    {
        panel.DOFade(1f, .5f);
    }

    private void PointerExitPiller(BaseEventData data)
    {
        panel.DOFade(0f, .5f);
    }

    /// <summary>
    /// 柱子点击事件
    /// </summary>
    /// <param name="data"></param>
    private void CubeClickEvent(BaseEventData data)
    {
        Transform camCtrl = Camera.main.transform;
        if (isSelect)
        {
            UIManager.m_Instance.CloseAllPanel();
            UIManager.m_Instance.OpenPanel("LeftPanel");
            UIManager.m_Instance.OpenPanel("RightPanel");
            UIManager.m_Instance.OpenPanel("TopPanel");

            camCtrl.SetParent(null);
            camCtrl.DOMove(new Vector3(10.64f, 1.439999f, 45.85f), 2f);
            camCtrl.DORotate(new Vector3(45f, 0f, 0f), 2f);
            for (int i = 0; i < points_City.Length; i++)
            {
                points_City[i].gameObject.SetActive(true);
            }
            panel.DOFade(0f, .2f);
        }
        else
        {
            camCtrl.SetParent(transform);
            camCtrl.DOLocalMove(new Vector3(0f, 1.208f, 2f), 1f);
            camCtrl.DOLocalRotate(new Vector3(10f, -180f, 0f), 1f);

            for (int i = 0; i < points_City.Length; i++)
            {
                if (points_City[i] != transform)
                {
                    points_City[i].gameObject.SetActive(false);
                }
            }
            StartCoroutine(EnterPanelAnim());
        }
        isSelect = !isSelect;
    }

    /// <summary>
    /// 柱子点击动画
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnterPanelAnim()
    {
        UIManager.m_Instance.CloseAllPanel();
        panel.DOFade(1f, .2f);

        yield return new WaitForSeconds(1f);

        //UIManager.m_Instance.OpenPanel("InfoPanel");

        yield return new WaitForSeconds(1f);

        UIManager.m_Instance.OpenPanel("LeftPanel2_1");

        yield return new WaitForSeconds(1f);

        UIManager.m_Instance.OpenPanel("LeftPanel2_2");

        yield return new WaitForSeconds(1f);

        UIManager.m_Instance.OpenPanel("RightPanel2_1");

        yield return new WaitForSeconds(1f);

        UIManager.m_Instance.OpenPanel("RightPanel2_2");
    }

    /// <summary>
    /// 设置顶部数字并播放数字滚动动画
    /// </summary>
    /// <param name="num"></param>
    public void PlayNumberAnim(int num, string cityName, float dura = .02f)
    {
        gameObject.SetActive(true);
        city.text = cityName;
        StartCoroutine(NumAnim(num, dura));
    }

    /// <summary>
    /// 顶部数字滚动动画
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private IEnumerator NumAnim(int num, float dura = .02f)
    {
        panel.color = new Color(1f, 1f, 1f, 0f);

        int a = 0;
        while (a < num)
        {
            a++;
            number.text = a.ToString();
            cube.localScale = new Vector3(cube.localScale.x, a / 10f, cube.localScale.z);
            yield return new WaitForSeconds(dura);
        }

        //panel.DOFade(1f, .5f);
    }

    /// <summary>
    /// 关闭自身
    /// </summary>
    public void CloseThis()
    {
        number.text = "0";
        cube.localScale = new Vector3(1f, 0f, 1f);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 数字面向相机
    /// 调整数字位置在Cube顶部
    /// 调整面板在数字旁边
    /// </summary>
    private void Update()
    {
        number.transform.LookAt(Camera.main.transform, Vector3.forward);
        number.transform.localEulerAngles = new Vector3(0f,
            number.transform.localEulerAngles.y, 0f);
        number.transform.localPosition = new Vector3(0f, (cube.localScale.y + 1) * .2f, 0f);
        panel.transform.localPosition = new Vector3(panel.transform.localPosition.x, number.transform.localPosition.y - .5f, panel.transform.localPosition.z);
        panel.transform.LookAt(Camera.main.transform);
    }

    /// <summary>
    /// 面板点击事件——石家庄地图进入
    /// </summary>
    private void PanelClickEvent(BaseEventData data)
    {
        for (int i = 0; i < points_City.Length; i++)
        {
            points_City[i].gameObject.SetActive(false);
        }

        //Transform cameraCtrl = GameManager.m_Instance.cam.transform;
        //cameraCtrl.SetParent(null);
        //cameraCtrl.DOMove(new Vector3(9.893f, 2.856f, 42.935f), 2f);//(9.924f,2.87f,43.41f)
        //cameraCtrl.DORotate(new Vector3(0f, 0f, 0f), 2f);

        GameManager.m_Instance.mainMap.SJZMapEnter();
    }
}