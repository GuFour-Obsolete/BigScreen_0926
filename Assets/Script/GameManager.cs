using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Gu4.Extend;
using Gu4.Frame;
using UnityEngine.SceneManagement;

using System.Runtime.InteropServices;

//==============================
//Synopsis  :  全局管理者
//CreatTime :  2021/9/26 14:50:20
//For       :  Gu4
//==============================

public class GameManager : MonoSingleton<GameManager>
{
    [DllImport("__Internal")]
    private static extern void IAMREADY();

    public Transform cam;

    public MainMap mainMap { get; private set; }

    public Light directionalLight { get; private set; }
    public Light pointLight { get; private set; }

    //进程
    public int gameProgress;

    private void Awake()
    {
        mainMap = GameObject.Find("MainMap").transform.TryGet<MainMap>();
        cam = Camera.main.transform;
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
        pointLight = GameObject.Find("Point Light").GetComponent<Light>();
        gameProgress = 0;
    }

    private void Start()
    {
        InitScene();
        //mainMap.PLayStartAnim();

#if !UNITY_EDITOR
        IAMREADY();
#endif

        GOGOGO();
    }

    private void Update()
    {
        //返回
        if (Input.GetMouseButtonDown(1))
        {
            if (gameProgress == 0)
            {
                return;
            }
            else if (gameProgress == 1)
            {
                gameProgress = 0;
                OneToZero();
            }
            else if (gameProgress == 2)
            {
                gameProgress = 1;
                SceneManager.LoadScene(0);
            }
        }
    }

    /// <summary>
    /// 前端调用，启动程序
    /// </summary>
    public void GOGOGO()
    {
        mainMap.PLayStartAnim();
    }

    /// <summary>
    /// 初始化场景
    /// </summary>
    private void InitScene()
    {
        //cam.SetPositionAndRotation(new Vector3(0f, 45f, 49f), Quaternion.Euler(90f, 0f, 0f));
        //pointLight.transform.SetPositionAndRotation(new Vector3(10.84f, 2.61f, 48.92f), Quaternion.Euler(0f, 0f, 0f));

        cam.position = new Vector3(10.64f, 0.49f, 45.85f);
        cam.SetPositionAndRotation(new Vector3(10.64f, 1.44f, 45.85f),
            Quaternion.Euler(45f, 0f, 0f));

        mainMap.transform.position = new Vector3(-2.2f, -2.7f, 46.5f);
        mainMap.transform.localScale = new Vector3(1.2f, 1f, 1f);
        directionalLight.intensity = .5f;

        pointLight.intensity = 12f;
        mainMap.hebeiMap.localPosition = new Vector3(mainMap.hebeiMap.localPosition.x, .42f, mainMap.hebeiMap.localPosition.z);
        mainMap.southMap.localPosition = new Vector3(mainMap.southMap.localPosition.x, .4f, mainMap.southMap.localPosition.z);
        for (int i = 0; i < mainMap.hebeiMap.Find("CityPoints").childCount; i++)
        {
            mainMap.hebeiMap.Find("CityPoints").GetChild(i).
                TryGet<TextMesh>("New Text").color = Color.gray;
        }

        for (int i = 0; i < mainMap.southMap.Find("SouthPoints").childCount; i++)
        {
            mainMap.southMap.Find("SouthPoints").GetChild(i).
                TryGet<TextMesh>("New Text").color = Color.white;
        }
    }

    /// <summary>
    /// 阶段1跳转至阶段0
    /// </summary>
    private void OneToZero()
    {
        UIManager.m_Instance.CloseAllPanel();
        UIManager.m_Instance.OpenPanel("LeftPanel").transform.TryGet<RectTransform>();
        UIManager.m_Instance.OpenPanel("RightPanel").transform.TryGet<RectTransform>();
        UIManager.m_Instance.OpenPanel("TopPanel");

        mainMap.Get_Point_City(true);

        cam.DOMove(new Vector3(10.64f, 1.439999f, 45.85f), .5f);

        mainMap.SJZMapExit();

        pointLight.DOIntensity(10f, .5f);

        gameProgress = 0;
    }

    /// <summary>
    /// 阶段2跳转至阶段1
    /// </summary>
    private void TwoToOne()
    {
        mainMap.SJZMapEnter(.5f);
        cam.DOMove(new Vector3(9.93f, -1.031f, 48.636f), .5f);
        cam.DORotate(new Vector3(45f, 0f, 0f), .5f);

        UIManager.m_Instance.CloseAllPanel();
        UIManager.m_Instance.OpenPanel("LeftPanel2_1");
        UIManager.m_Instance.OpenPanel("LeftPanel2_2");
        UIManager.m_Instance.OpenPanel("RightPanel2_1");
        UIManager.m_Instance.OpenPanel("RightPanel2_2");

        pointLight.DOIntensity(1f, .5f);
        gameProgress = 1;
    }

    /// <summary>
    /// 开场动画
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartAnim()
    {
        //UIManager.m_Instance.OpenPanel("LeftPanel").transform.TryGet<RectTransform>();
        //UIManager.m_Instance.OpenPanel("RightPanel").transform.TryGet<RectTransform>();
        //UIManager.m_Instance.OpenPanel("TopPanel");

        //yield return new WaitForSeconds(1f);

        yield return null;

        mainMap.PLayStartAnim();

        //cam.transform.DOMove(new Vector3(10.64f, 1.44f, 45.85f), 2f);
        //cam.transform.DORotate(new Vector3(45f, 0f, 0f), 2f);
        //directionalLight.DOIntensity(.5f, 4f);
        //mainMap.transform.DOScaleX(1.2f, 2f);
        //mainMap.transform.DOMove(new Vector3(-2.2f, -2.7f, 46.5f), 2f);

        //yield return new WaitForSeconds(2f);

        //mainMap.Find("中国地图/河北地图/MapLight").TryGet<Animator>().SetBool("IsPlay", true);
        //mainMap.MapLightAnim();
        //pointLight.transform.DOMoveY(1.32f, 6f);

        //yield return new WaitForSeconds(4f);

        //mainMap.Find("中国地图/河北地图/MapLight").TryGet<SpriteRenderer>().DOFade(0f, 2f).SetEase(Ease.Linear);
        //mainMap.PLayStartAnim();
        //mainMap.MapLightHide();

        //yield return new WaitForSeconds(1f);

        //mainMap.hebeiMap.DOLocalMoveY(0.12f, 2f);

        //yield return new WaitForSeconds(2f);

        //mainMap.Find("中国地图/河北地图/南网地图/BurstDount").DOScale(Vector3.one * 1.5f, 2f);
        //mainMap.Find("中国地图/河北地图/南网地图/BurstDount").TryGet<SpriteRenderer>().DOFade(0f, 3f);

        //for (int i = 0; i < mapPoint2s.Length; i++)
        //{
        //    mapPoint2s[i] = ObjectPools.m_Instance.GetObject("Model/MapPoint2").transform;
        //    mapPoint2s[i].SetParent(mainMap.southMap);
        //    mapPoint2s[i].localPosition = posis[i];
        //    mapPoint2s[i].localEulerAngles = new Vector3(0f, 180f, 0f);
        //}
        //mapPoint2s[5].Find("Panel").localPosition = new Vector3(0f, .6f, 0f);
    }
}