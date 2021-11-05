using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BuildWindowMoudle : MonoBehaviour
{
    public int resHorizontal, resVertical;//程序运行分辨率

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;//最左坐标
        public int Top;//最上坐标
        public int Right;//最右坐标
        public int Bottom;//最下坐标
    }

    [DllImport("user32.dll")]
    public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

    private IntPtr myintptr;//当前窗口引用

    private RECT winRect;//当前窗口rect信息
    private float w_h;//宽高比

    private int winWidth, winHeight;//窗口宽高
    private int x, y;//窗口左上角坐标

    private void Start()
    {
#if UNITY_STANDALONE&&!UNITY_EDITOR
        Init();
#endif
    }

    private void LateUpdate()
    {
#if UNITY_STANDALONE&&!UNITY_EDITOR
        SetWindow();
#endif
    }

    private void Init()
    {
        myintptr = GetActiveWindow();
        w_h = resHorizontal / resVertical;//窗口横纵比例
        GetWindowRect(myintptr, ref winRect);

        winWidth = winRect.Right - winRect.Left;//窗口的宽度
        winHeight = winRect.Bottom - winRect.Top;//窗口的高度
    }

    private void SetWindow()
    {
        GetWindowRect(myintptr, ref winRect);
        winWidth = winRect.Right - winRect.Left;//窗口的宽度
        winHeight = winRect.Bottom - winRect.Top;//窗口的高度
        x = winRect.Left;
        y = winRect.Top;
        float z = winWidth / winHeight;
        if (z > w_h + 0.01f || z < w_h - 0.01f)
        {
            winHeight = (int)(winWidth / w_h);
            MoveWindow(myintptr, x, y, winWidth, winHeight, true);
        }
    }
}