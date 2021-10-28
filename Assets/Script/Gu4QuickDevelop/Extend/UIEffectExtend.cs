using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Gu4.Tools;

namespace Gu4.Extend
{
    /// <summary>
    /// UI效果扩展
    /// </summary>
    public static class UIEffectExtend
    {
        /// <summary>
        /// 入场效果，适用从下方出现【Pivot=(1,0.5f)】
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="start">起始点</param>
        /// <param name="end">结束点</param>
        /// <param name="duration">持续时间</param>
        /// <param name="callback">回调</param>
        /// <returns></returns>
        public static RectTransform In_Bottom(this RectTransform rect, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            rect.anchoredPosition = start;
            rect.localRotation = Quaternion.Euler(0, 0, 20);
            tweener = rect.DOAnchorPos(end, duration);
            tweener1 = rect.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), duration).OnComplete(callback);
 
            return rect;
        }

        #region 由小变大

        /// <summary>
        /// 由小变大
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="point">坐标点</param>
        /// <param name="duration">持续时间</param>
        /// <param name="callback">回调</param>
        /// <returns></returns>
        public static RectTransform In_ScaleSmall_OutBounce(this RectTransform rect, Vector2 point, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.localScale = Vector3.zero;
            rect.anchoredPosition = point;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);
       
            return rect;
        }

        public static RectTransform In_ScaleSmall_OutBack(this RectTransform rect, Vector2 point, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.localScale = Vector3.zero;
            rect.anchoredPosition = point;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(callback);
     
            return rect;
        }

        public static RectTransform In_ScaleSmall_OutBack(this RectTransform rect, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.localScale = Vector3.zero;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(callback);
      
            return rect;
        }

        public static RectTransform In_ScaleSmall_OutBounce(this RectTransform rect, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.localScale = Vector3.zero;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);
 
            return rect;
        }

        public static Image In_ScaleSmall_OutBounce(this Image image, Vector2 point, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.localScale = Vector3.zero;
            rect.anchoredPosition = point;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);
       
            return image;
        }

        public static Image In_ScaleSmall_OutBounce(this Image image, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.localScale = Vector3.zero;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);
    
            return image;
        }

        public static Image In_ScaleSmall_OutBounce_Y(this Image image, float duration = 1, float pivotX = .5f, float pivotY = .5f, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.pivot = new Vector2(pivotX, pivotY);
            rect.localScale = new Vector3(1, 0, 1);
            tweener = rect.DOScaleY(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);
   
            return image;
        }

        public static Image In_ScaleSmall_OutBack(this Image image, Vector2 point, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.localScale = Vector3.zero;
            rect.anchoredPosition = point;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(callback);
      
            return image;
        }

        public static Image In_ScaleSmall_OutBack(this Image image, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.localScale = Vector3.zero;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(callback);
    
            return image;
        }

        public static TMP_Text In_ScaleSmall_OutBounce(this TMP_Text text, Vector2 point, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.localScale = Vector3.zero;
            rect.anchoredPosition = point;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);
   
            return text;
        }

        public static TMP_Text In_ScaleSmall_OutBack(this TMP_Text text, Vector2 point, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.localScale = Vector3.zero;
            rect.anchoredPosition = point;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(callback);

            return text;
        }

        public static TMP_Text In_ScaleSmall_OutBack(this TMP_Text text, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.localScale = Vector3.zero;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBack).OnComplete(callback);
 
            return text;
        }

        public static TMP_Text In_ScaleSmall_OutBounce(this TMP_Text text, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.localScale = Vector3.zero;
            tweener = rect.DOScale(1, duration).SetEase(Ease.OutBounce).OnComplete(callback);

            return text;
        }

        #endregion 由小变大

        #region 进入

        public static RectTransform In_Move(this RectTransform rect, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).OnComplete(callback);
       
            return rect;
        }

        public static RectTransform In_Move(this RectTransform rect, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = rect.DOAnchorPos(end, duration).OnComplete(callback);
          
            return rect;
        }

        public static RectTransform In_Move_OutBounce(this RectTransform rect, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBounce).OnComplete(callback);
    
            return rect;
        }

        public static RectTransform In_Move_OutBack(this RectTransform rect, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBack).OnComplete(callback);
    
            return rect;
        }

        public static RectTransform In_Move_OutBack(this RectTransform rect, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBack).OnComplete(callback);

            return rect;
        }

        public static Image In_Move(this Image image, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).OnComplete(callback);

            return image;
        }

        public static Image In_Move(this Image image, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            tweener = rect.DOAnchorPos(end, duration).OnComplete(callback);
 
            return image;
        }

        public static Image In_Move_Color(this Image image, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            RectTransform rect = image.rectTransform;
            image.color = new Color(1, 1, 1, 0);
            rect.anchoredPosition = start;
            tweener = image.DOColor(Color.white, duration);
            tweener1 = rect.DOAnchorPos(end, duration).OnComplete(callback);

            return image;
        }

        public static Image In_Move_Color(this Image image, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            RectTransform rect = image.rectTransform;
            image.color = new Color(1, 1, 1, 0);
            tweener = image.DOColor(Color.white, duration);
            tweener1 = rect.DOAnchorPos(end, duration).OnComplete(callback);
      
            return image;
        }

        public static Image In_Move_OutBounce(this Image image, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBounce).OnComplete(callback);
       
            return image;
        }

        public static Image In_Move_OutBack(this Image image, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBack).OnComplete(callback);
    
            return image;
        }

        public static Image In_Move_OutBack(this Image image, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBack).OnComplete(callback);
            return image;
        }

        public static TMP_Text In_Move(this TMP_Text text, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).OnComplete(callback);
            return text;
        }

        public static TMP_Text In_Move(this TMP_Text text, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            tweener = rect.DOAnchorPos(end, duration).OnComplete(callback);
            return text;
        }

        public static TMP_Text In_Move_Color(this TMP_Text text, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            RectTransform rect = text.rectTransform;
            Color color = text.color;
            text.color = new Color(1, 1, 1, 0);
            rect.anchoredPosition = start;
            tweener = text.DOColor(color, duration);
            tweener1 = rect.DOAnchorPos(end, duration).OnComplete(callback);
            return text;
        }

        public static TMP_Text In_Move_OutBounce(this TMP_Text text, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBounce).OnComplete(callback);
            return text;
        }

        public static TMP_Text In_Move_OutBounce(this TMP_Text text, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBounce).OnComplete(callback);
            return text;
        }

        public static TMP_Text In_Move_OutBack(this TMP_Text text, Vector2 start, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.anchoredPosition = start;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBack).OnComplete(callback);
            return text;
        }

        public static TMP_Text In_Move_OutBack(this TMP_Text text, Vector2 end, float duration, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.OutBack).OnComplete(callback);
            return text;
        }

        #endregion 进入

        #region 由大变小

        public static RectTransform In_ScaleBig(this RectTransform rect, Vector2 point, float duration = 1, float startScale = 5, float endScale = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            rect.anchoredPosition = point;
            rect.localScale = Vector3.one * startScale;
            tweener = rect.DOScale(endScale, duration).OnComplete(callback);
            return rect;
        }

        public static Image In_ScaleBig(this Image image, Vector2 point, float duration = 1, float startScale = 5, float endScale = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            rect.anchoredPosition = point;
            rect.localScale = Vector3.one * startScale;
            tweener = rect.DOScale(endScale, duration).OnComplete(callback);
            return image;
        }

        public static TMP_Text In_ScaleBig(this TMP_Text text, Vector2 point, float duration = 1, float startScale = 5, float endScale = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            rect.anchoredPosition = point;
            rect.localScale = Vector3.one * startScale;
            tweener = rect.DOScale(endScale, duration).OnComplete(callback);
            return text;
        }

        #endregion 由大变小

        #region 淡入

        public static Image In_Thin(this Image image, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            Color color = image.color;
            image.color = new Color(1, 1, 1, 0);
            tweener = image.DOColor(new Color(1, 1, 1, 1), duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static Image In_ThinColor(this Image image, Color color, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            image.color = new Color(1, 1, 1, 0);
            tweener = image.DOColor(color, duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static TMP_Text In_Thin(this TMP_Text text, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            Color color = text.color;
            text.color = new Color(1, 1, 1, 0);
            tweener = text.DOColor(color, duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return text;
        }

        #endregion 淡入

        #region 淡出

        public static Image Out_Thin(this Image image, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = image.DOColor(new Color(1, 1, 1, 0), duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static TMP_Text Out_Thin(this TMP_Text text, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = text.DOColor(new Color(1, 1, 1, 0), duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return text;
        }

        #endregion 淡出

        #region 缩小

        public static RectTransform Out_Scale(this RectTransform rect, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = rect.DOScale(0, duration).OnComplete(() =>
             {
                 callback?.Invoke();
             });
            return rect;
        }

        public static Image Out_Scale(this Image image, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = image.rectTransform;
            tweener = rect.DOScale(0, duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static TMP_Text Out_Scale(this TMP_Text text, float duration = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            RectTransform rect = text.rectTransform;
            tweener = rect.DOScale(0, duration).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return text;
        }

        #endregion 缩小

        #region 移出

        public static RectTransform Out_Move(this RectTransform rect, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = rect.DOAnchorPos(end, durtion).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return rect;
        }

        public static Image Out_Move(this Image image, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = image.rectTransform.DOAnchorPos(end, durtion).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static TMP_Text Out_Move(this TMP_Text text, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = text.rectTransform.DOAnchorPos(end, durtion).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return text;
        }

        public static RectTransform Out_MoveRotate(this RectTransform rect, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            tweener = rect.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 180), durtion);
            tweener1 = rect.DOAnchorPos(end, durtion).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return rect;
        }

        public static Image Out_MoveRotate(this Image image, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            tweener = image.rectTransform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 180), durtion);
            tweener1 = image.rectTransform.DOAnchorPos(end, durtion).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static TMP_Text Out_MoveRotate(this TMP_Text text, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener, tweener1;
            tweener = text.rectTransform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 180), durtion);
            tweener1 = text.rectTransform.DOAnchorPos(end, durtion).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return text;
        }

        public static RectTransform Out_Move_InBack(this RectTransform rect, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = rect.DOAnchorPos(end, durtion).SetEase(Ease.InBack).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return rect;
        }

        public static Image Out_Move_InBack(this Image image, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = image.rectTransform.DOAnchorPos(end, durtion).SetEase(Ease.InBack).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return image;
        }

        public static TMP_Text Out_Move_InBack(this TMP_Text text, Vector2 end, float durtion = 1, TweenCallback callback = null)
        {
            Tweener tweener;
            tweener = text.rectTransform.DOAnchorPos(end, durtion).SetEase(Ease.InBack).OnComplete(() =>
            {
                callback?.Invoke();
            });
            return text;
        }

        /// <summary>
        /// 坠落效果
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="end"></param>
        /// <param name="duration"></param>
        /// <param name="pivotX"></param>
        /// <param name="pivotY"></param>
        public static RectTransform Out_Fall(this RectTransform rect, Vector2 end, float duration = 1, float pivotX = .5f, float pivotY = .5f)
        {
            Tweener tweener, tweener1;
            rect.pivot = new Vector2(pivotX, pivotY);
            tweener = rect.DOAnchorPos(end, duration).SetEase(Ease.InCirc);
            tweener1 = rect.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, -45), duration).SetEase(Ease.InExpo);
            return rect;
        }

        #endregion 移出

        #region 闪烁

        /// <summary>
        /// 闪烁
        /// </summary>
        /// <param name="text"></param>
        /// <param name="end">变化颜色</param>
        /// <param name="num">闪烁次数</param>
        /// <param name="duration">持续时间</param>
        /// <returns></returns>
        public static TMP_Text Filcker(this TMP_Text text, Color end, int num, float duration)
        {
            Tweener tweener;
            tweener = text.DOColor(end, duration).SetLoops(num, LoopType.Yoyo);
            return text;
        }

        /// <summary>
        /// 闪烁
        /// </summary>
        /// <param name="image"></param>
        /// <param name="end">变化颜色</param>
        /// <param name="num">闪烁次数</param>
        /// <param name="duration">持续时间</param>
        /// <returns></returns>
        public static Image Filcker(this Image image, Color end, int num, float duration)
        {
            Tweener tweener;
            tweener = image.DOColor(end, duration).SetLoops(num, LoopType.Yoyo);
            return image;
        }

        #endregion 闪烁
    }
}