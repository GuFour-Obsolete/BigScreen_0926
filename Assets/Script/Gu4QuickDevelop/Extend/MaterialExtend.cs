using DG.Tweening;
using UnityEngine;

namespace Gu4.Extend
{
    public static class MaterialExtend
    {
        /// <summary>
        /// 材质球闪烁
        /// </summary>
        /// <param name="material"></param>
        /// <param name="endColor">目标颜色</param>
        /// <param name="loops">循环次数</param>
        /// <param name="duration">持续时间</param>
        public static void Flicker(this Material material, Color endColor, int loops, float duration)
        {
            Tweener tweener, tweener1;
            Color color = material.color;
            Color color1 = material.color;
            bool isOpen = material.IsKeywordEnabled("_EMISSION");
            if (!isOpen)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", material.color);
            }
            tweener = material.DOColor(endColor, duration).SetLoops(loops, LoopType.Yoyo).OnKill(() => material.color = color);
            tweener1 = DOTween.To(() => material.GetColor("_EmissionColor"),
                X => color1 = X, endColor, duration).SetLoops(loops, LoopType.Yoyo).
                OnUpdate(() => material.SetColor("_EmissionColor", color1)).OnKill(() =>
            {
                material.SetColor("_EmissionColor", color);
                if (!isOpen)
                {
                    material.DisableKeyword("_EMISSION");
                }
            });
        }

        /// <summary>
        /// 材质球闪烁
        /// </summary>
        /// <param name="material"></param>
        /// <param name="endColor">目标颜色</param>
        /// <param name="loops">循环次数</param>
        /// <param name="duration">持续时间</param>
        public static void Flicker_NoEmission(this Material material, Color endColor, int loops, float duration)
        {
            Tweener tweener;
            Color color = material.color;

            tweener = material.DOColor(endColor, duration).SetLoops(loops, LoopType.Yoyo).OnKill(() => material.color = color);
        }
    }
}