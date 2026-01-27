using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マウス位置に追従する比較用ステータスウィンドウ
/// </summary>
public class ComparrisonTextWindow : MonoBehaviour
{
    [Header("UI全体をまとめている親パネル")]
    public RectTransform basePanel;

    [Header("ステータス表示ウィンドウ")]
    public RectTransform ShowstatusTextRect;


    [Header("比較用ステータスウィンドウ")]
    public RectTransform statusTextRect;

    [Header("ステータス表示用Text")]
    public Text statusText;

    [Header("TextのRectTransform")]
    public RectTransform textRect;

    [Header("マウスからのオフセット")]
    public Vector2 offset = Vector2.zero;

    [Header("余白")]
    public Vector2 padding;

    [Header("最大サイズ")]
    public Vector2 maxTextSize;


    /// <summary>表示中かどうか</summary>
    private bool isShowing = false;

    void Update()
    {
        if (!isShowing) return;

        statusTextRect.anchoredPosition =
            CalcMouseUIPositionSmart(statusTextRect, offset);
    }

    /// <summary>
    /// マウス位置基準でUIを配置（はみ出し防止付き）
    /// </summary>
    Vector2 CalcMouseUIPositionSmart(RectTransform targetRect, Vector2 baseOffset)
    {
        // マウス座標 → ローカル座標
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            basePanel,
            Input.mousePosition,
            null,
            out localPoint
        );

        Rect panelRect = basePanel.rect;
        Vector2 size = targetRect.sizeDelta;
        Vector2 size_show = ShowstatusTextRect.sizeDelta;
        Vector2 pos = localPoint;

        // ---------- 横方向 ----------
        bool canShowRight =
            localPoint.x + baseOffset.x + size.x < panelRect.xMax;

        if (canShowRight)
        { 
            pos.x += baseOffset.x + size.x * 0.5f;
            // =============================
            // ★変更点：ウィンドウ1つ分 下にずらす
            // =============================
            pos.x += size_show.x;
        }

        else
        {
            pos.x -= baseOffset.x + size.x * 0.5f;
            // =============================
            // ★変更点：ウィンドウ1つ分 下にずらす
            // =============================
            pos.x -= size_show.x;


        }

        // ---------- 縦方向 ----------
        bool canShowUp =
            localPoint.y + baseOffset.y + size.y < panelRect.yMax;

        if (canShowUp)
            pos.y += baseOffset.y + size.y * 0.5f;
        else
            pos.y -= baseOffset.y + size.y * 0.5f;


        // ---------- はみ出し防止 ----------
        Vector2 halfSize = size * 0.5f;

        pos.x = Mathf.Clamp(
            pos.x,
            panelRect.xMin + halfSize.x,
            panelRect.xMax - halfSize.x
        );

        pos.y = Mathf.Clamp(
            pos.y,
            panelRect.yMin + halfSize.y,
            panelRect.yMax - halfSize.y
        );

        return pos;
    }

    /// <summary>Hover開始</summary>
    public void OnHoverEnter()
    {
        statusTextRect.gameObject.SetActive(true);
        isShowing = true;
    }

    /// <summary>サイズ更新</summary>
    public void UpdateWindowSize()
    {
        float textW = statusText.preferredWidth;
        float textH = statusText.preferredHeight;

        textW = Mathf.Min(textW, maxTextSize.x);
        textH = Mathf.Min(textH, maxTextSize.y);


        textRect.sizeDelta = new Vector2(textW, textH);

        statusTextRect.sizeDelta = new Vector2(
            textW / 2 + padding.x,
            textH / 2 + padding.y
        );
    }

    /// <summary>Hover終了</summary>
    public void OnHoverExit()
    {
        statusTextRect.gameObject.SetActive(false);
        isShowing = false;
    }
}
