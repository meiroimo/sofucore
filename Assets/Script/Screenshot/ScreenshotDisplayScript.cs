using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotDisplayScript : MonoBehaviour
{
    [SerializeField] private Image display;

    void Start()
    {
        if (ScreenshotManagerScript.CapturedTexture != null)
        {
            Texture2D tex = ScreenshotManagerScript.CapturedTexture;

            Sprite sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f)
            );

            display.sprite = sprite;
            display.preserveAspect = true;

            FitToImageSize(display);
        }
        else
        {
            Debug.LogWarning("スクリーンショットが存在しません。");
        }
    }

    private void FitToImageSize(Image img)
    {
        RectTransform rt = img.rectTransform;

        float parentWidth = rt.rect.width;
        float parentHeight = rt.rect.height;
        float texWidth = img.sprite.texture.width;
        float texHeight = img.sprite.texture.height;

        float parentAspect = parentWidth / parentHeight;
        float texAspect = texWidth / texHeight;

        Vector2 newSize = Vector2.zero;

        if (texAspect > parentAspect)
        {
            newSize.x = parentWidth;
            newSize.y = parentWidth / texAspect;
        }
        else
        {
            newSize.y = parentHeight;
            newSize.x = parentHeight * texAspect;
        }

        rt.sizeDelta = newSize;
    }
}
