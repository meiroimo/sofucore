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

        // --- 現在の設定を保存 ---
        Rect originalRect = targetCamera.rect;
        RenderTexture prevTarget = targetCamera.targetTexture;
        RenderTexture prevActive = RenderTexture.active;

        // --- 一時的にViewportをフルに広げる ---
        targetCamera.rect = new Rect(0, 0, 1, 1);

        int width = Screen.width;
        int height = Screen.height;
        RenderTexture tempRT = new RenderTexture(width, height, 24);

        // --- 一時RTへ描画 ---
        targetCamera.targetTexture = tempRT;
        targetCamera.Render();

        // --- ピクセル読み取り ---
        RenderTexture.active = tempRT;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // --- 復元 ---
        targetCamera.rect = originalRect;
        targetCamera.targetTexture = prevTarget;
        RenderTexture.active = prevActive;
        tempRT.Release();
        Object.Destroy(tempRT);

        CapturedTexture = tex;
        /*
 yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;

        // カメラのアスペクトを画面に合わせる
        targetCamera.aspect = (float)width / height;

        // RenderTexture準備
        RenderTexture rt = new RenderTexture(width, height, 24);
        targetCamera.targetTexture = rt;
        targetCamera.Render();

        RenderTexture.active = rt;

        // ViewportRectに基づいて実際の描画範囲を取得
        Rect vp = targetCamera.rect;
        int x = Mathf.RoundToInt(vp.x * width);
        int y = Mathf.RoundToInt(vp.y * height);
        int w = Mathf.RoundToInt(vp.width * width);
        int h = Mathf.RoundToInt(vp.height * height);

        // トリミングしてテクスチャ作成
        Texture2D tex = new Texture2D(w, h, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(x, y, w, h), 0, 0);
        tex.Apply();

        // 後片付け
        targetCamera.targetTexture = null;
        RenderTexture.active = null;
        Object.Destroy(rt);

        CapturedTexture = tex;
        */

        /*
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
        */
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
