using System.Collections.Generic;
using UnityEngine;

namespace Gu4.Tools
{
    /// <summary>
    /// 物体遮罩
    /// </summary>
    public class ObjMask : MonoBehaviour
    {
        public Transform m_Section;
        public Transform m_Target;

        private MeshRenderer[] m_TargetMeshRenderers;
        private List<Material> m_TargetMaterials = new List<Material>();

        private Vector3 m_SectionPos;
        private Vector3 m_SectionNormal;

        private void Start()
        {
            m_TargetMeshRenderers = m_Target.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < m_TargetMeshRenderers.Length; i++)
            {
                for (int j = 0; j < m_TargetMeshRenderers[i].materials.Length; j++)
                {
                    m_TargetMaterials.Add(m_TargetMeshRenderers[i].materials[j]);
                }
            }
        }

        /// <summary>
        /// 设置材质球的值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="normal"></param>
        private void SetMaterialValue(Vector3 pos, Vector3 normal)
        {
            if (m_TargetMaterials.Count == 0)
                return;
            for (int i = 0; i < m_TargetMaterials.Count; i++)
            {
                m_TargetMaterials[i].SetVector("_ClipObjPos", pos);
                m_TargetMaterials[i].SetVector("_ClipObjNormal", normal);
            }
        }

        private void Update()
        {
            if (m_Section == null || m_TargetMaterials.Count == 0)
                return;

            m_SectionPos = m_Section.position;

            m_SectionNormal = m_Section.rotation * Vector3.down;

            SetMaterialValue(m_SectionPos, m_SectionNormal);
        }
    }
}