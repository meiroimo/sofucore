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
    [Header("削除ボタンRectTransform")]
    public RectTransform deleteButtonRect;

    [Header("削除ボタンのオフセット")]
    public Vector2 deleteButtonOffset = new Vector2(0, -150);


    [Header("UI全体をまとめているパネル（Canvas内のRectTransform）")]
    public RectTransform basePanel;

    [Header("ステータスを表示するTextのRectTransform")]
    public RectTransform statusTextRect;

    [Header("ステータスのテキストコンポーネント")]
    public Text statusText;
    [Header("テキストRect")]
    public RectTransform textRect;
    [Header("マウス座標からのオフセット量")]
    private Vector2 offset = new Vector2(0, 0);

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

        // ステータステキスト
        statusTextRect.anchoredPosition =
            CalcMouseUIPositionSmart(statusTextRect, offset);

    }
     
    public void deleteButton_potion_set()
    {
        // 削除ボタン
        deleteButtonRect.anchoredPosition =
            CalcMouseUIPosition(deleteButtonRect, deleteButtonOffset);

    }

    /// <summary>
    /// マウス位置を基準にUIを表示するための座標を計算する
    /// ・Screen座標 → UI(Local)座標へ変換
    /// ・指定オフセットを加算
    /// ・UIが親パネルからはみ出さないように補正
    /// </summary>
    Vector2 CalcMouseUIPosition(
        RectTransform targetRect, // 表示したいUI（ツールチップ等）
        Vector2 offset             // マウス位置からの表示オフセット
    )
    {
        // マウスのScreen座標を、basePanel内のLocal座標へ変換した結果を受け取る
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            basePanel,              // 座標変換の基準となる親RectTransform
            Input.mousePosition,    // 現在のマウスのScreen座標
            null,                   // Overlay Canvasの場合はnullでOK
            out localPoint           // 変換後のLocal座標
        );

        // マウス位置 + 表示したいオフセット分だけずらす
        Vector2 targetPos = localPoint + offset;

        // 親パネル（表示範囲）の矩形情報を取得
        Rect panelRect = basePanel.rect;

        // 表示するUIの半分サイズ（中心基準で配置するため）
        Vector2 halfSize = targetRect.sizeDelta * 0.5f;


        // UIがはみ出さないようにするための制限範囲を計算
        // 左端・右端・下端・上端
        float minX = panelRect.xMin + halfSize.x;
        float maxX = panelRect.xMax - halfSize.x;
        float minY = panelRect.yMin + halfSize.y;
        float maxY = panelRect.yMax - halfSize.y;

        // X方向をパネル内に収める
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);

        // Y方向をパネル内に収める
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // 補正後の最終UI座標を返す
        return targetPos;
    }

    /// <summary>
    /// ウィンドウの位置
    /// </summary>
    Vector2 CalcMouseUIPositionSmart(RectTransform targetRect,Vector2 baseOffset)
    {
        //マウスのScreen座標を、basePanel内のローカル座標へ変換する
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            basePanel,              //座標変換の基準となる親パネル
            Input.mousePosition,    //現在のマウスのScreen座標
            null,                   //Overlay Canvas の場合は null
            out localPoint          //変換後のローカル座標
        );

        //親パネルの表示領域
        Rect panelRect = basePanel.rect;

        //表示するUIのサイズ
        Vector2 size = targetRect.sizeDelta;

        Vector2 pos = localPoint;

        //横方向の表示判定

        //右側にUIを表示しても、パネル右端を超えないか判定
        bool canShowRight =
            localPoint.x + baseOffset.x + size.x < panelRect.xMax;

        if (canShowRight)
        {
            //右側に表示
            //offset分だけ離し、UIの半分サイズを加算して中心位置を決定
            pos.x += baseOffset.x + size.x * 0.5f;
        }
        else
        {
            //右に置けない場合は左側に表示
            pos.x -= baseOffset.x + size.x * 0.5f;
        }

        //縦方向の表示判定

        //上側にUIを表示しても、パネル上端を超えないか判定
        bool canShowUp =
            localPoint.y + baseOffset.y + size.y < panelRect.yMax;

        if (canShowUp)
        {
            //上側に表示
            pos.y += baseOffset.y + size.y * 0.5f;
        }
        else
        {
            //上に置けない場合は下側に表示
            pos.y -= baseOffset.y + size.y * 0.5f;
        }

        //UIは中心基準なので、半分サイズを考慮して制限する
        Vector2 halfSize = size * 0.5f;

        //X方向をパネル内に強制的に収める
        pos.x = Mathf.Clamp(
            pos.x,
            panelRect.xMin + halfSize.x,
            panelRect.xMax - halfSize.x
        );

        //Y方向をパネル内に強制的に収める
        pos.y = Mathf.Clamp(
            pos.y,
            panelRect.yMin + halfSize.y,
            panelRect.yMax - halfSize.y
        );

        return pos;
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

    }    /// <summary>
         /// ボタンからカーソルが離れた時に呼ぶ
         /// </summary>
    public void OnHoverExit()
    {
        statusTextRect.gameObject.SetActive(false);
        isShowing = false;
    }

  
  
   
}
