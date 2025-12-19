using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ボタンにカーソルを合わせると、カーソルの位置にステータスを表示するマネージャースクリプト。
/// 参考：UIMagicTextの座標変換を応用。
/// </summary>
public class TextWindow : MonoBehaviour
{
    [Header("設置シーンカメラ")]
    public Camera cam;

    [Header("UI全体をまとめているパネル（Canvas内のRectTransform）")]
    public RectTransform basePanel;

    [Header("ステータスを表示するTextのRectTransform")]
    public RectTransform statusTextRect;

    [Header("ステータスのテキストコンポーネント")]
    public Text statusText;
    [Header("テキストRect")]
    public RectTransform textRect;
    [Header("マウス座標からのオフセット量")]
    private Vector2 offset = new Vector2(0, -150);

    [Header("余白")]
    public Vector2 padding ;

    [Header("最大サイズ制限")]
    public Vector2 maxTextSize ;
    // 内部用：テキストの現在表示状態
    private bool isShowing = false;

    void Start()
    {
       
    }

    void Update()
    {
        if (!isShowing) return;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            basePanel,
            Input.mousePosition,
            null,
            out localPoint
        );

        // まず通常の位置
        Vector2 targetPos = localPoint + offset;

        // basePanel のサイズ
        Rect panelRect = basePanel.rect;

        // ウィンドウの半サイズ
        Vector2 windowHalfSize = statusTextRect.sizeDelta * 0.5f;

        // Clamp（はみ出し防止）
        float minX = panelRect.xMin + windowHalfSize.x+100;
        float maxX = panelRect.xMax - windowHalfSize.x - 100;
        float minY = panelRect.yMin + windowHalfSize.y + 100;
        float maxY = panelRect.yMax - windowHalfSize.y - 100;

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        statusTextRect.anchoredPosition = targetPos;
    }


    /// <summary>
    /// ボタンにカーソルが乗った時に呼ぶ（EventTrigger などで設定）
    /// </summary>
    public void OnHoverEnter()
    {
        statusTextRect.gameObject.SetActive(true);
        isShowing = true;
    }

    public void UpdateWindowSize()
    {
        // Textが必要とするサイズ取得
        float textW = statusText.preferredWidth+50;
        float textH = statusText.preferredHeight;

        // Textの最大制限
        textW = Mathf.Min(textW, maxTextSize.x);
        textH = Mathf.Min(textH, maxTextSize.y);

        // Textのサイズ更新
        textRect.sizeDelta = new Vector2(textW, textH);

        // WindowはText＋padding
        statusTextRect.sizeDelta = new Vector2(
            textW/2 + padding.x,
            textH/2 + padding.y
        );

        //// Textが必要とするサイズ
        //float preferredW = statusText.preferredWidth;
        //float preferredH = statusText.preferredHeight;

        //// padding込みサイズ
        //float width = preferredW + padding.x;
        //float height = preferredH + padding.y;

        //// 最大サイズ制限
        //width = Mathf.Min(width, maxSize.x);
        //height = Mathf.Min(height, maxSize.y);

        //statusTextRect.sizeDelta = new Vector2(width, height);
    }    /// <summary>
         /// ボタンからカーソルが離れた時に呼ぶ
         /// </summary>
    public void OnHoverExit()
    {
        statusTextRect.gameObject.SetActive(false);
        isShowing = false;
    }

  
  
   
}
