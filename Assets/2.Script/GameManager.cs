using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Gu4.Extend;
using Gu4.Frame;
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

    public MainMap mainMap { get; private set; }

    //游戏进程
    public int gameProgress;

    private void Awake()
    {
        gameProgress = 0;
        mainMap = GameObject.Find("MainMap").transform.TryGet<MainMap>();
    }

    private void Start()
    {
#if UNITY_EDITOR
        mainMap.PLayStartAnim();
#endif

#if !UNITY_EDITOR && UNITY_WEBGL
        IAMREADY();
#endif
    }

    /// <summary>
    /// 前端调用，启动程序
    /// </summary>
    public void GOGOGO()
    {
        mainMap.PLayStartAnim();
    }

    private void Update()
    {
        //返回
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (gameProgress == 0)
        //    {
        //        return;
        //    }
        //    else if (gameProgress == 1)
        //    {
        //        gameProgress = 0;
        //        OneToZero();
        //    }
        //    else if (gameProgress == 2)
        //    {
        //        gameProgress = 1;
        //        SceneManager.LoadScene(0);
        //    }
        //}
    }

    #region 跳转

    ///// <summary>
    ///// 阶段1跳转至阶段0
    ///// </summary>
    //private void OneToZero()
    //{
    //    UIManager.m_Instance.CloseAllPanel();
    //    UIManager.m_Instance.OpenPanel("LeftPanel").transform.TryGet<RectTransform>();
    //    UIManager.m_Instance.OpenPanel("RightPanel").transform.TryGet<RectTransform>();
    //    UIManager.m_Instance.OpenPanel("TopPanel");

    //    mainMap.Get_Point_City(true);

    //    cam.DOMove(new Vector3(10.64f, 1.439999f, 45.85f), .5f);

    //    mainMap.SJZMapExit();

    //    pointLight.DOIntensity(10f, .5f);

    //    gameProgress = 0;
    //}

    ///// <summary>
    ///// 阶段2跳转至阶段1
    ///// </summary>
    //private void TwoToOne()
    //{
    //    mainMap.SJZMapEnter(.5f);
    //    cam.DOMove(new Vector3(9.93f, -1.031f, 48.636f), .5f);
    //    cam.DORotate(new Vector3(45f, 0f, 0f), .5f);

    //    UIManager.m_Instance.CloseAllPanel();
    //    UIManager.m_Instance.OpenPanel("LeftPanel2_1");
    //    UIManager.m_Instance.OpenPanel("LeftPanel2_2");
    //    UIManager.m_Instance.OpenPanel("RightPanel2_1");
    //    UIManager.m_Instance.OpenPanel("RightPanel2_2");

    //    pointLight.DOIntensity(1f, .5f);
    //    gameProgress = 1;
    //}

    #endregion 跳转
}