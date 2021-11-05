using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gu4.Extend
{
    public static class UIExtend
    {
        public static Button[] SetClickColor(this Button[] buttons, Color end)
        {
            Color[] colors = new Color[buttons.Length];
            for (int i = 0; i < buttons.Length; i++)
            {
                colors[i] = buttons[i].Get<RectTransform>().GetColor();
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[i].onClick.AddListener(() => SetButtonColor(buttons, index, colors, end));
            }
            return buttons;
        }

        public static Color GetColor(this RectTransform rect)
        {
            if (rect.Get<Image>() != null)
                return rect.Get<Image>().color;
            else if (rect.Get<TMP_Text>() != null)
                return rect.Get<TMP_Text>().color;
            else if (rect.Get<Text>() != null)
                return rect.Get<Text>().color;
            else
                return Color.white;
        }

        public static void SetColor(this RectTransform rect, Color color)
        {
            if (rect.Get<Image>() != null)
                rect.Get<Image>().color = color;
            else if (rect.Get<TMP_Text>() != null)
                rect.Get<TMP_Text>().color = color;
            else if (rect.Get<Text>() != null)
                rect.Get<Text>().color = color;
        }

        private static void SetButtonColor(Button[] buttons, int index, Color[] colors, Color color)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == index)
                {
                    buttons[i].Get<RectTransform>().SetColor(color);
                }
                else
                {
                    buttons[i].Get<RectTransform>().SetColor(colors[i]);
                }
            }
        }

        public static Image SetColor(this Image image, float r = 1, float g = 1, float b = 1, float a = 1)
        {
            image.color = new Color(r, g, b, a);
            return image;
        }

        public static Image SetColor32(this Image image, byte r = 255, byte g = 255, byte b = 255, byte a = 255)
        {
            image.color = new Color32(r, g, b, a);
            return image;
        }

        public static TMP_Text SetColor(this TMP_Text text, Color color)
        {
            text.color = color;
            return text;
        }

        public static TMP_Text SetColor(this TMP_Text text, float r = 1, float g = 1, float b = 1, float a = 1)
        {
            text.color = new Color(r, g, b, a);
            return text;
        }

        public static TMP_Text SetColor32(this TMP_Text text, byte r = 255, byte g = 255, byte b = 255, byte a = 255)
        {
            text.color = new Color32(r, g, b, a);
            return text;
        }

        /// <summary>
        /// 设置图片大小
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Image SetSize(this Image image, float x, float y)
        {
            image.rectTransform.sizeDelta = new Vector2(x, y);
            return image;
        }
        public static Image SetSize(this Image image, Vector2 size)
        {
            image.rectTransform.sizeDelta = size;
            return image;
        }
    }
}