using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Gu4.Extend;
using Gu4.Timer;

namespace Gu4.Tools
{
    public class DrawUtil
    {
        public static bool IsPause;
        private static Queue<GameObject> m_Objs = new Queue<GameObject>();

        private static Queue<GameObject> m_Radar = new Queue<GameObject>();

        //private static int m_Poolnum = 50;
        private static uint m_Expansion = 0;

        /// <summary>
        /// 圆环持续膨胀
        /// </summary>
        /// <param name="interval">膨胀间隔</param>
        /// <param name="parent">父级</param>
        /// <param name="endR">膨胀半径</param>
        /// <param name="nums">绘制圆环总点数</param>
        /// <param name="width">线宽</param>
        /// <param name="duration">膨胀时间</param>
        /// <param name="mat">材质</param>
        public static void DrawExpansionContinueCircle(float interval, Transform parent, float endR, int nums, float width, float duration, Material mat)
        {
            m_Expansion = TimerHeap.m_Instance.AddTimer(0, interval, () => { if (parent == null) return; DrawExpansionOneCircle(parent, endR, nums, width, duration, mat); }, true);
        }

        /// <summary>
        /// 停止圆环膨胀
        /// </summary>
        public static void StopCircleExpansion()
        {
            if (m_Expansion != 0)
            {
                TimerHeap.m_Instance.DelTimer(m_Expansion);
            }
        }

        /// <summary>
        /// 绘制单次圆环膨胀
        /// </summary>
        /// <param name="parent">父级</param>
        /// <param name="endR">膨胀半径</param>
        /// <param name="nums">绘制圆环总点数</param>
        /// <param name="width">线宽</param>
        /// <param name="duration">膨胀时间</param>
        /// <param name="mat">材质</param>
        public static void DrawExpansionOneCircle(Transform parent, float endR, int nums, float width, float duration, Material mat)
        {
            GameObject lineObj = null;
            LineRenderer line = null;
            float r = 0;
            Tweener tweener;
            if (m_Objs.Count == 0)
            {
                lineObj = new GameObject("ExpansionOneCircle");
                lineObj.SetParent(parent);
                line = lineObj.AddComponent<LineRenderer>();
            }
            else
            {
                lineObj = m_Objs.Dequeue();
                lineObj.name = "ExpansionOneCircle";
                lineObj.SetParent(parent);
                line = lineObj.AddComponent<LineRenderer>();
            }
            line.positionCount = nums + 1;
            line.widthMultiplier = width;
            line.material = mat;
            tweener = DOTween.To(() => r, R => r = R, endR, duration).OnUpdate(() => { CircleExpansion(parent.position, line, r, nums); }).OnComplete(() =>
              {
                  if (m_Objs.Count >= 10)
                  {
                      lineObj.Destory();
                  }
                  else
                  {
                      m_Objs.Enqueue(lineObj);
                      lineObj.DesComponent<LineRenderer>();
                  }
              });
        }

        /// <summary>
        /// 绘制三角形
        /// </summary>
        /// <param name="point_1"></param>
        /// <param name="point_2"></param>
        /// <param name="point_3"></param>
        /// <returns></returns>
        public static GameObject DrawTriangle(Vector3 point_1, Vector3 point_2, Vector3 point_3)
        {
            GameObject triangle = new GameObject("三角形");
            triangle.AddComponent<MeshFilter>();
            triangle.AddComponent<MeshRenderer>();
            int[] triangles = new int[3];
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;

            Vector3[] vectors = new Vector3[3];
            vectors[0] = point_1;
            vectors[1] = point_2;
            vectors[2] = point_3;

            Mesh m = new Mesh();
            m.vertices = vectors;
            m.triangles = triangles;
            triangle.Get<MeshFilter>().mesh = m;
            triangle.Get<MeshRenderer>().material = new Material(Shader.Find("Standard"));
            return triangle;
        }

        /// <summary>
        /// 圆环膨胀
        /// </summary>
        /// <param name="point">中心点</param>
        /// <param name="line"></param>
        /// <param name="r"></param>
        private static void CircleExpansion(Vector3 point, LineRenderer line, float r, int nums)
        {
            for (int i = 0; i <= nums; i++)
            {
                float x = Mathf.Cos((360 * (i + 1) / nums + 1) * Mathf.Deg2Rad) * r;
                float z = Mathf.Sin((360 * (i + 1) / nums + 1) * Mathf.Deg2Rad) * r;
                line.SetPosition(i, new Vector3(point.x + x, point.y, point.z + z));
            }
        }

        /// <summary>
        /// 绘制圆弧
        /// </summary>
        /// <param name="point">父节点</param>
        /// <param name="line">线段</param>
        /// <param name="r">半径</param>
        /// <param name="nums">构成圆弧所需要的点数</param>
        /// <param name="angle">圆弧角度</param>
        /// <param name="offset">圆弧旋转偏移量</param>
        public static void DrawArc(Vector3 point, LineRenderer line, float r, int nums, int angle, float offset)
        {
            for (int i = 0; i <= nums; i++)
            {
                float x = Mathf.Cos((angle * (i + 1) / nums + 1) * Mathf.Deg2Rad) * r;
                float z = Mathf.Sin((angle * (i + 1) / nums + 1) * Mathf.Deg2Rad) * r;
                Vector3 Point = new Vector3(point.x + x, point.y, point.z + z);
                float X = (Point.x - point.x) * Mathf.Cos(offset) - (Point.z - point.z) * Mathf.Sin(offset) + point.x;
                float Z = (Point.x - point.x) * Mathf.Sin(offset) + (Point.z - point.z) * Mathf.Cos(offset) + point.z;
                Point = new Vector3(X, point.y, Z);
                line.SetPosition(i, Point);
            }
        }

        /// <summary>
        /// 绘制单次圆弧膨胀
        /// </summary>
        /// <param name="parent">父级</param>
        /// <param name="endR">膨胀半径</param>
        /// <param name="nums">绘制圆环总点数</param>
        /// <param name="width">线宽</param>
        /// <param name="duration">膨胀时间</param>
        /// <param name="mat">材质</param>
        public static LineRenderer DrawExpansionOneArc(Transform parent, float endR, int nums, float width, float duration, Material mat, int angle, float offset)
        {
            GameObject lineObj = null;
            LineRenderer line = null;
            float r = 0;
            Tweener tweener;
            if (m_Objs.Count == 0)
            {
                lineObj = new GameObject("ExpansionOneArc");
                lineObj.SetParent(parent);
                line = lineObj.AddComponent<LineRenderer>();
            }
            else
            {
                lineObj = m_Objs.Dequeue();
                lineObj.name = "ExpansionOneArc";
                lineObj.SetParent(parent);
                line = lineObj.AddComponent<LineRenderer>();
            }
            line.positionCount = nums + 1;
            line.widthMultiplier = width;
            line.material = mat;
            tweener = DOTween.To(() => r, R => r = R, endR, duration).OnUpdate(() => { DrawArc(parent.position, line, r, nums, angle, offset); }).OnComplete(() =>
                {
                    if (m_Objs.Count >= 10)
                    {
                        lineObj.Destory();
                    }
                    else
                    {
                        m_Objs.Enqueue(lineObj);
                        lineObj.DesComponent<LineRenderer>();
                    }
                }).SetEase(Ease.Linear);

            return line;
        }

        public static Mesh CreateMesh(float radius, float innerradius, float angledegree, int segments)
        {
            //vertices(顶点):
            int vertices_count = segments * 2 + 2;              //因为vertices(顶点)的个数与triangles（索引三角形顶点数）必须匹配
            Vector3[] vertices = new Vector3[vertices_count];
            float angleRad = Mathf.Deg2Rad * angledegree;
            float angleCur = angleRad;
            float angledelta = angleRad / segments;
            for (int i = 0; i < vertices_count; i += 2)
            {
                float cosA = Mathf.Cos(angleCur);
                float sinA = Mathf.Sin(angleCur);
                float _x = radius * cosA;
                float _z = radius * sinA;
                float in_x = innerradius * cosA;
                float in_z = innerradius * sinA;

                Vector3 Point = new Vector3(_x, 0, _z);
                Vector3 Point1 = new Vector3(in_x, 0, in_z);

                vertices[i] = Point;
                vertices[i + 1] = Point1;
                angleCur -= angledelta;
            }
            //triangles:
            int triangle_count = segments * 6;
            int[] triangles = new int[triangle_count];
            for (int i = 0, vi = 0; i < triangle_count; i += 6, vi += 2)
            {
                triangles[i] = vi;
                triangles[i + 1] = vi + 3;
                triangles[i + 2] = vi + 1;
                triangles[i + 3] = vi + 2;
                triangles[i + 4] = vi + 3;
                triangles[i + 5] = vi;
            }
            //uv:
            Vector2[] uvs = new Vector2[vertices_count];
            for (int i = 0; i < vertices_count; i++)
            {
                uvs[i] = new Vector2(vertices[i].x / radius / 2 + 0.5f, vertices[i].z / radius / 2 + 0.5f);
            }
            //负载属性与mesh
            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            return mesh;
        }

        public static GameObject DrawExpansionOneArc(Transform parent, float endR, float angle, float duration, Material mat, float offset)
        {
            GameObject lineObj = null;
            Tweener tweener;

            lineObj = new GameObject("ExpansionOneArc");
            lineObj.SetParent(parent);
            lineObj.transform.localPosition = Vector3.zero;
            MeshFilter mesh = lineObj.AddComponent<MeshFilter>();
            mesh.mesh = CreateMesh(0.1f, 0.097f, angle, 20);
            lineObj.AddComponent<MeshRenderer>().material = mat;
            lineObj.AddComponent<MeshCollider>();
            lineObj.layer = LayerMask.NameToLayer("CarRadar");
            lineObj.transform.localEulerAngles = new Vector3(0, offset, 0);

            tweener = lineObj.transform.DOScale(endR, duration).OnComplete(() =>
             {
                 lineObj.Destory();
             }).SetEase(Ease.Linear);
            return lineObj;
        }

        #region 贝塞尔方程

        /// <summary>
        /// 二阶方程
        /// </summary>
        /// <param name="t">取值0-1</param>
        /// <param name="p0">起始点</param>
        /// <param name="p1">控制点</param>
        /// <param name="p2">结束点</param>
        /// <returns></returns>
        static public Vector3 SecondBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            Vector3 P0P1 = (1 - t) * p0 + t * p1;
            Vector3 P1P2 = (1 - t) * p1 + t * p2;
            Vector3 result = (1 - t) * P0P1 + t * P1P2;
            return result;
        }

        /// <summary>
        /// 三阶方程
        /// </summary>
        /// <param name="p0">起始点</param>
        /// <param name="p1">控制点1</param>
        /// <param name="p2">控制点2</param>
        /// <param name="p3">结束点</param>
        /// <param name="t">取值0-1</param>
        /// <returns></returns>
        public static Vector3 ThirdBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            Vector3 result;
            Vector3 p0p1 = (1 - t) * p0 + t * p1;
            Vector3 p1p2 = (1 - t) * p1 + t * p2;
            Vector3 p2p3 = (1 - t) * p2 + t * p3;
            Vector3 p0p1p2 = (1 - t) * p0p1 + t * p1p2;
            Vector3 p1p2p3 = (1 - t) * p1p2 + t * p2p3;
            result = (1 - t) * p0p1p2 + t * p1p2p3;
            return result;
        }

        /// <summary>
        /// N阶方程
        /// </summary>
        /// <param name="points"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 N_Bezier(List<Vector3> points, float t)
        {
            if (points.Count < 2)
                return points[0];
            List<Vector3> Points = new List<Vector3>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                Vector3 p0p1 = (1 - t) * points[i] + t * points[i + 1];
                Points.Add(p0p1);
            }
            return N_Bezier(Points, t);
        }

        #endregion 贝塞尔方程
    }
}