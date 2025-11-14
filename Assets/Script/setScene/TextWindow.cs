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
    [Header("設置シーンカメラ（自動で設定されます）")]
    public Camera cam;

    [Header("UI全体をまとめているパネル（Canvas内のRectTransform）")]
    public RectTransform basePanel;

    [Header("ステータスを表示するTextのRectTransform")]
    public RectTransform statusTextRect;

    [Header("ステータスのテキストコンポーネント")]
    public Text statusText;

    [Header("マウス座標からのオフセット量")]
    private Vector2 offset = new Vector2(-200, -200);
    // 内部用：テキストの現在表示状態
    private bool isShowing = false;

    void Start()
    {
       
    }

    void Update()
    {
        // テキストが表示中なら、マウスに追従させる
        if (isShowing)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                basePanel,          // 基準となるパネル
                Input.mousePosition,// マウスのスクリーン座標
                null,               // Overlayの場合はカメラ不要
                out localPoint
            );

            // offsetを加えて位置更新
            statusTextRect.anchoredPosition = localPoint + offset;
        }
    }

    /// <summary>
    /// ボタンにカーソルが乗った時に呼ぶ（EventTrigger などで設定）
    /// </summary>
    public void OnHoverEnter()
    {
        statusTextRect.gameObject.SetActive(true);
        isShowing = true;
    }

    /// <summary>
    /// ボタンからカーソルが離れた時に呼ぶ
    /// </summary>
    public void OnHoverExit()
    {
        statusTextRect.gameObject.SetActive(false);
        isShowing = false;
    }

  
  
   
}
