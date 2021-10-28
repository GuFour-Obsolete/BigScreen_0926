using System;
using UnityEngine;

namespace Gu4.Extend
{
    public static class GameObjectExtend
    {
        /// <summary>
        /// 创建基本物体
        /// </summary>
        /// <param name="primitiveType">基本物体类型</param>
        /// <param name="position">位置</param>
        /// <param name="rotate">旋转</param>
        /// <param name="size">大小</param>
        /// <param name="parent">父级</param>
        /// <param name="space">坐标空间</param>
        /// <returns></returns>
        public static GameObject CreatPrimitives(PrimitiveType primitiveType, Vector3 position, Vector3 rotate, float size = 1, Transform parent = null, Space space = Space.World)
        {
            GameObject game = GameObject.CreatePrimitive(primitiveType);
            game.transform.SetParent(parent);
            if (space == Space.World)
            {
                game.transform.position = position;
                game.transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                game.transform.localPosition = position;
                game.transform.localRotation = Quaternion.Euler(rotate);
            }
            game.transform.localScale = Vector3.one * size;
            return game;
        }

        /// <summary>
        /// 创建基本物体
        /// </summary>
        /// <param name="primitiveType">基本物体类型</param>
        /// <param name="target">目标点</param>
        /// <param name="parent">父级</param>
        /// <returns></returns>
        public static GameObject CreatPrimitives(PrimitiveType primitiveType, Transform target, Transform parent = null)
        {
            GameObject game = GameObject.CreatePrimitive(primitiveType);
            game.transform.SetParent(parent);
            game.transform.position = target.position;
            game.transform.rotation = target.rotation;
            game.transform.localScale = target.localScale;
            return game;
        }

        /// <summary>
        /// 设置物体位置
        /// </summary>
        /// <param name="game"></param>
        /// <param name="pos">位置</param>
        /// <param name="space">空间</param>
        /// <returns></returns>
        public static GameObject SetPosition(this GameObject game, Vector3 pos, Space space = Space.World)
        {
            if (space == Space.World)
            {
                game.transform.position = pos;
            }
            else
            {
                game.transform.localPosition = pos;
            }
            return game;
        }

        /// <summary>
        /// 设置角度
        /// </summary>
        /// <param name="game"></param>
        /// <param name="rot">角度</param>
        /// <returns></returns>
        public static GameObject SetRotation(this GameObject game, Vector3 rot)
        {
            game.transform.localEulerAngles = rot;
            return game;
        }

        /// <summary>
        /// 设置物体大小
        /// </summary>
        /// <param name="game"></param>
        /// <param name="size">缩放</param>
        /// <returns></returns>
        public static GameObject SetScale(this GameObject game, Vector3 size)
        {
            game.transform.localScale = size;
            return game;
        }

        /// <summary>
        /// 设置Transform本地属性
        /// </summary>
        /// <param name="game"></param>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static GameObject SetTransfrom(this GameObject game, Vector3 pos, Vector3 rot, Vector3 size)
        {
            game.SetPosition(pos, Space.Self);
            game.SetRotation(rot);
            game.SetScale(size);
            return game;
        }

        /// <summary>
        /// 删除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="game"></param>
        /// <param name="t">组件</param>
        /// <returns></returns>
        public static GameObject DesComponent<T>(this GameObject game) where T : Component
        {
            T t = game.GetComponent<T>();
            if (t != null)
            {
                GameObject.Destroy(t);
            }
            return game;
        }

        /// <summary>
        /// 删除脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="game"></param>
        /// <param name="t">脚本</param>
        /// <returns></returns>
        public static GameObject DesScripts<T>(this GameObject game) where T : MonoBehaviour
        {
            T t = game.GetComponent<T>();
            if (t != null)
            {
                GameObject.Destroy(t);
            }
            return game;
        }

        /// <summary>
        /// 删除脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="game"></param>
        /// <param name="t">脚本</param>
        /// <returns></returns>
        public static GameObject DesScripts<T>(this GameObject game, T t) where T : MonoBehaviour
        {
            t = game.GetComponent<T>();
            if (t != null)
            {
                GameObject.Destroy(t);
            }
            return game;
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="game"></param>
        /// <param name="color">颜色</param>
        /// <param name="isEmission">开启自发光 ?</param>
        /// <returns></returns>
        public static GameObject SetColor(this GameObject game, Color color, bool isEmission = false)
        {
            MeshRenderer renderer = game.GetComponent<MeshRenderer>();
            if (isEmission)
            {
                renderer.material.EnableKeyword("_EMISSION");
                renderer.material.color = color;
                renderer.material.SetColor("_EmissionColor", color);
            }
            else
            {
                renderer.material.DisableKeyword("_EMISSION");
                renderer.material.color = color;
            }
            return game;
        }

        /// <summary>
        /// 设置父级
        /// </summary>
        /// <param name="game"></param>
        /// <param name="parent">父级</param>
        public static GameObject SetParent(this GameObject game, Transform parent)
        {
            game.transform.SetParent(parent);
            return game;
        }

        /// <summary>
        /// 删除物体
        /// </summary>
        /// <param name="game"></param>
        /// <param name="t">延迟时间</param>
        public static void Destory(this GameObject game, float t = 0)
        {
            GameObject.Destroy(game, t);
        }

        /// <summary>
        /// 删除物体
        /// </summary>
        /// <param name="game"></param>
        /// <param name="t">延迟时间</param>
        public static void Destory(this GameObject game, Action action, float t = 0)
        {
            action?.Invoke();
            GameObject.Destroy(game, t);
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="name">子物体名称</param>
        /// <returns></returns>
        public static T Get<T>(this GameObject game, string name = null)
        {
            T t;
            if (string.IsNullOrEmpty(name))
            {
                t = game.GetComponent<T>();
            }
            else
            {
                t = game.transform.Find(name).GetComponent<T>();
            }
            return t;
        }

        public static T Get<T>(this GameObject game, int index)
        {
            T t;
            if (index < 0)
            {
                t = game.GetComponent<T>();
            }
            else
            {
                t = game.transform.GetChild(index).GetComponent<T>();
            }
            return t;
        }

        /// <summary>
        /// 获取子物体
        /// </summary>
        /// <param name="game"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject GetGame(this GameObject game, string name)
        {
            GameObject Obj;
            Obj = game.transform.Find(name).gameObject;
            return Obj;
        }

        /// <summary>
        /// 获取子物体
        /// </summary>
        /// <param name="game"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject GetGame(this GameObject game, int index)
        {
            GameObject Obj;
            Obj = game.transform.GetChild(index).gameObject;
            return Obj;
        }
    }
}