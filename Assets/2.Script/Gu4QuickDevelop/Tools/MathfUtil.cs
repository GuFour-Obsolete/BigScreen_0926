using Gu4.Frame;
using UnityEngine;

namespace Gu4.Tools
{
    //==============================
    //Synopsis  :  数学运算
    //CreatTime :  2021/7/27 11:14:50
    //For       :  Gu4
    //==============================

    public class MathfUtil : Singleton<MathfUtil>
    {
        /// <summary>
        /// 获取三角形角3的角度
        /// </summary>
        /// <param name="angle1">角1</param>
        /// <param name="angle2">角2</param>
        /// <returns></returns>
        public static float Triangle_GetThirdAngle(float angle1, float angle2)
        {
            return 180 - (angle1 + angle2);
        }

        /// <summary>
        /// 获取三角形外接圆直径
        /// </summary>
        /// <param name="angle">角</param>
        /// <param name="edge">对边</param>
        /// <returns></returns>
        public static float Triangle_GetCircumcircle_Diam(float angle, float edge)
        {
            return edge / Mathf.Sin(angle * Mathf.Deg2Rad);
        }

        /// <summary>
        /// 获取三角形角的对边
        /// </summary>
        /// <param name="angle">角</param>
        /// <param name="Circumcircle">外接圆直径</param>
        /// <returns></returns>
        public static float Triangle_GetEdge(float angle, float Circumcircle)
        {
            return Mathf.Sin(angle * Mathf.Deg2Rad) * Circumcircle;
        }

        /// <summary>
        /// 获取三角形夹角的对边
        /// </summary>
        /// <param name="A_Angle">夹角A</param>
        /// <param name="B_Edge">角B的对边</param>
        /// <param name="C_Edge">角C的对边</param>
        /// <returns>return : 角A的对边</returns>
        static public float Get_A_Edge_EAE(float A_Angle, float B_Edge, float C_Edge)
        {
            return Mathf.Sqrt(B_Edge * B_Edge + C_Edge * C_Edge - 2 * B_Edge * C_Edge * Mathf.Cos(A_Angle * Mathf.Deg2Rad));
        }

        /// <summary>
        /// 光的折射向量
        /// </summary>
        /// <param name="vector">入射向量</param>
        /// <param name="normal">法线向量</param>
        /// <param name="n1">入射介质折射率</param>
        /// <param name="n2">射入介质折射率</param>
        /// <returns></returns>
        public Vector3 Refaction(Vector3 vector, Vector3 normal, float n1, float n2)
        {
            vector.Normalize();
            float dt = Vector3.Dot(vector, normal);
            float absDt = Mathf.Abs(dt);
            float s2 = 1.0f - dt * dt;
            float st2 = n1 / n2 * (n1 / n2) * s2;
            float cost2 = 1.0f - st2;
            float c = -Mathf.Sqrt(cost2);
            float r = Mathf.Abs(n1 / n2);

            return c * normal + r * (vector + absDt * normal);
        }

        /// <summary>
        /// 光的折射向量3D
        /// </summary>
        /// <param name="vector">入射向量</param>
        /// <param name="normal">法线向量</param>
        /// <param name="n1">入射介质折射率</param>
        /// <param name="n2">射入介质折射率</param>
        /// <returns></returns>
        public Vector3 Refaction3D(Vector3 vector, Vector3 normal, float n1, float n2)
        {
            vector = vector.normalized;
            float ratio = n1 / n2;
            float ratios = ratio * ratio;
            float dot = Vector3.Dot(vector, normal);
            float dots = dot * dot;

            float num = ratios * (1 - dots);
            float sign = -Mathf.Sqrt(Mathf.Abs(1 - num));
            Vector3 t;
            t = sign * normal + ratio * (vector - dot * normal);
            return t;
        }
    }
}