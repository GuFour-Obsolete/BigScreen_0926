using Gu4.Extend;
using Gu4.Frame;
using Gu4.Tools;
using System.Collections.Generic;
using UnityEngine;

//==============================
//Synopsis  :  ��UI������
//CreatTime :  2021/9/28 11:48:40
//For       :  Gu4
//==============================

public class UIManager : Singleton<UIManager>
{
    private Transform canvasTransform;

    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;
            }
            return canvasTransform;
        }
    }

    //Panel���ֺ�·��
    private Dictionary<string, string> nameAndPath;

    //�������
    private Dictionary<string, BasePanel> panelDict;

    public UIManager()
    {
        nameAndPath = new Dictionary<string, string>();

        nameAndPath.Add("LeftPanel", "Prefab/UI/LeftPanel");
        nameAndPath.Add("RightPanel", "Prefab/UI/RightPanel");
        nameAndPath.Add("InfoPanel", "Prefab/UI/InfoPanel");
        nameAndPath.Add("TopPanel", "Prefab/UI/TopPanel");
        nameAndPath.Add("LeftPanel2_1", "Prefab/UI/LeftPanel2_1");
        nameAndPath.Add("LeftPanel2_2", "Prefab/UI/LeftPanel2_2");
        nameAndPath.Add("RightPanel2_1", "Prefab/UI/RightPanel2_1");
        nameAndPath.Add("RightPanel2_2", "Prefab/UI/RightPanel2_2");
        nameAndPath.Add("VideoPanel", "Prefab/UI/VideoPanel");
        nameAndPath.Add("OrderStatPanel", "Prefab/UI/OrderStatPanel");

        //nameAndPath.Add("", "Prefab/UI/");
    }

    public T GetPanelBehaviour<T>(string panelType) where T : BasePanel
    {
        panelDict.TryGetValue(panelType, out BasePanel temp);
        if (!temp)
        {
            LogUtil.LogError($"{panelType.ToString()}��岻����,�޷�GetBehaviour");
            return null;
        }
        if (!temp.gameObject.activeSelf)
        {
            LogUtil.LogError($"{temp.gameObject.name}���δ����");
            return null;
        }
        return temp as T;
    }

    #region �����

    //��һ�����
    public BasePanel OpenPanel(string panelType)
    {
        if (panelDict == null)
            panelDict = new Dictionary<string, BasePanel>();

        BasePanel panel = GetPanel(panelType);
        //panelDict.Add(panelType, panel);
        panel.gameObject.SetActive(true);
        panel.OnEnter();
        return panel;
    }

    //Panel��ջ
    public void ClosePanel(string panelType)
    {
        if (!panelDict.ContainsKey(panelType))
            return;

        BasePanel topPanel = panelDict[panelType];
        topPanel.OnExit();

        //ʧ�������Panel��OnExit������
        //topPanel.gameObject.SetActive(false);
    }

    //�˳�����Panel
    public void CloseAllPanel()
    {
        foreach (var item in panelDict)
        {
            if (!item.Value.gameObject.activeSelf)
                continue;
            item.Value.OnExit();
            //item.Value.gameObject.Destory();
        }
        //panelDict = new Dictionary<string, BasePanel>();
    }

    public void CleanAllPanel()
    {
        foreach (var item in panelDict)
        {
            if (!item.Value.gameObject.activeSelf)
                continue;
            item.Value.OnExit();
            item.Value.gameObject.Destory();
        }
        panelDict = new Dictionary<string, BasePanel>();
    }

    #endregion �����

    #region ˽�з���

    private BasePanel GetPanel(string panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<string, BasePanel>();
        }

        BasePanel panel = panelDict.GetValue(panelType);

        //��������в����ڣ�������ʵ��������ӽ������
        if (panel == null)
        {
            string path = nameAndPath.GetValue(panelType);
            GameObject panelGo = GameObject.Instantiate(Resources.Load<GameObject>(path), CanvasTransform, false);
            panel = panelGo.GetComponent<BasePanel>();
            panelDict.Add(panelType, panel);
        }
        return panel;
    }

    #endregion ˽�з���
}

public abstract class BasePanel : MonoBehaviour
{
    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }
}