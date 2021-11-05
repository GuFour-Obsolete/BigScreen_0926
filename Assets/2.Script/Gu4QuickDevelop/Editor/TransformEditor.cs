using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Gu4.Tools;

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformEditor : Editor
{
    private enum SpacePos
    {
        Self,
        World,
    }

    private SpacePos spacePos;
    private Transform transform;
    private float R_X, R_Y, R_Z;
    private float S_X, S_Y, S_Z;

    private void OnEnable()
    {
        transform = (Transform)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("复制参数"))
        {
            if (spacePos == SpacePos.Self)
            {
                LogUtil.Copy(string.Format("new Vector3({0}f,{1}f,{2}f)", transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));
            }
            else if (spacePos == SpacePos.World)
            {
                LogUtil.Copy(string.Format("new Vector3({0}f,{1}f,{2}f)", transform.position.x, transform.position.y, transform.position.z));
            }
        }
        if (GUILayout.Button("重置", GUILayout.Width(100)))
        {
            transform.localPosition = Vector3.zero;
        }
        spacePos = (SpacePos)EditorGUILayout.EnumPopup(spacePos, GUILayout.Width(100));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("P", GUILayout.Width(30)))
        {
            if (spacePos == SpacePos.Self)
            {
                LogUtil.Copy(string.Format("new Vector3({0}f,{1}f,{2}f)", transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));
            }
            else if (spacePos == SpacePos.World)
            {
                LogUtil.Copy(string.Format("new Vector3({0}f,{1}f,{2}f)", transform.position.x, transform.position.y, transform.position.z));
            }
        }
        if (spacePos == SpacePos.Self)
        {
            transform.localPosition = EditorGUILayout.Vector3Field("Postion", transform.localPosition);
            //Debug.Log(serializedObject.targetObject);
            //EditorGUILayout.PropertyField(serializedObject.FindProperty("localPosition"),new GUIContent("Postion"));
        }
        else if (spacePos == SpacePos.World)
        {
            transform.position = EditorGUILayout.Vector3Field("Postion", transform.position);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("复制参数(Vector)"))
        {
            LogUtil.Copy(string.Format("new Vector3({1}f,{2}f,{3}f)", transform.name, transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z));
        }
        if (GUILayout.Button("复制参数(Quaternion)"))
        {
            LogUtil.Copy(string.Format("Quaternion.Euler({1}f,{2}f,{3}f)", transform.name, transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z));
        }
        if (GUILayout.Button("重置", GUILayout.Width(100)))
        {
            transform.localEulerAngles = Vector3.zero;
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("R", GUILayout.Width(30)))
        {
            LogUtil.Copy(string.Format("new Vector3({0}f,{1}f,{2}f)", transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z));
        }
        if (GUILayout.Button("Q", GUILayout.Width(30)))
        {
            LogUtil.Copy(string.Format("Quaternion.Euler({0}f,{1}f,{2}f)", transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z));
        }
        transform.localEulerAngles = EditorGUILayout.Vector3Field("Rotation", transform.localEulerAngles);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("复制参数"))
        {
            LogUtil.Copy(string.Format("new Vector3({1}f,{2}f,{3}f)", transform.name, transform.localScale.x, transform.localScale.y, transform.localScale.z));
        }
        if (GUILayout.Button("重置", GUILayout.Width(100)))
        {
            transform.localScale = Vector3.one;
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("S", GUILayout.Width(30)))
        {
            LogUtil.Copy(string.Format("new Vector3({0}f,{1}f,{2}f)", transform.localScale.x, transform.localScale.y, transform.localScale.z));
        }
        transform.localScale = EditorGUILayout.Vector3Field("Scale", transform.localScale);
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}