using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenshotManagerScript : MonoBehaviour
{
    public static Texture2D CapturedTexture { get; private set; }

    /// <summary>
    /// 指定カメラの映像をスクリーンショットとして保存（UI除外）
    /// </summary>
    public static IEnumerator CaptureFromCamera(Camera targetCamera)
    {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;

        RenderTexture rt = new RenderTexture(width, height, 24);
        targetCamera.targetTexture = rt;
        targetCamera.Render();

        RenderTexture.active = rt;

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        targetCamera.targetTexture = null;
        RenderTexture.active = null;
        Object.Destroy(rt);

        CapturedTexture = tex;
    }

    public static void Clear()
    {
        if (CapturedTexture != null)
        {
            Object.Destroy(CapturedTexture);
            CapturedTexture = null;
        }
    }
}
