using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//==============================
//Synopsis  :
//CreatTime :  2021/9/30 16:17:19
//For       :  Gu4
//==============================

public class HousePlane : MonoBehaviour
{
    private Transform[] trails;

    private Vector3[] points;

    private void Awake()
    {
        trails = new Transform[5];
        points = new Vector3[transform.childCount];

        for (int i = 0; i < trails.Length; i++)
        {
            trails[i] = Instantiate(Resources.Load<GameObject>("Prefab/Model/Trail")).transform;
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).position;
        }
    }

    private void Start()
    {
        Vector3[] path1 = new Vector3[] { points[0], points[1], points[2], points[5], points[4], points[3], points[6], points[7], points[8] };
        trails[0].transform.GetComponent<TrailRenderer>().enabled = false;
        trails[0].position = path1[0];
        trails[0].transform.GetComponent<TrailRenderer>().enabled = true;
        trails[0].DOPath(path1, 9f, PathType.Linear, PathMode.Full3D).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        Vector3[] path2 = new Vector3[] { points[2], points[1], points[4], points[7] };
        trails[1].transform.GetComponent<TrailRenderer>().enabled = false;
        trails[1].position = path2[0];
        trails[1].transform.GetComponent<TrailRenderer>().enabled = true;
        trails[1].DOPath(path2, 4f, PathType.Linear, PathMode.Ignore).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        Vector3[] path3 = new Vector3[] { points[8], points[7], points[4], points[1], points[2] };
        trails[2].transform.GetComponent<TrailRenderer>().enabled = false;
        trails[2].position = path3[0];
        trails[2].transform.GetComponent<TrailRenderer>().enabled = true;
        trails[2].DOPath(path3, 6f, PathType.Linear, PathMode.Full3D).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        Vector3[] path4 = new Vector3[] { points[6], points[3], points[4], points[1], points[0] };
        trails[3].transform.GetComponent<TrailRenderer>().enabled = false;
        trails[3].position = path4[0];
        trails[3].transform.GetComponent<TrailRenderer>().enabled = true;
        trails[3].DOPath(path4, 3f, PathType.Linear, PathMode.Full3D).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        Vector3[] path5 = new Vector3[] { points[5], points[4], points[7], points[8] };
        trails[4].transform.GetComponent<TrailRenderer>().enabled = false;
        trails[4].position = path5[0];
        trails[4].transform.GetComponent<TrailRenderer>().enabled = true;
        trails[4].DOPath(path5, 5f, PathType.Linear, PathMode.Full3D).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}