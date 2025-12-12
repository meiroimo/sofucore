using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// イベント通知UI
/// </summary>
public class EventAlertUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject alertPanel;//背景帯
    [SerializeField] private Text alertText;

    [Header("テキスト点滅設定")]
    [SerializeField] private float displayDuration = 3f;
    [SerializeField] private float blinkSpeed = 0.3f;

    [Header("スライド設定")]
    [SerializeField] private RectTransform panelRect;
    [SerializeField] private Vector2 targetPos = new Vector2(-20, -20);//最終位置
    [SerializeField] private Vector2 offscreenPos = new Vector2(500, -20);//右画面外
    [SerializeField] private float slideSpeed = 6f;
    [SerializeField] private float slideOutSpeed = 5f;

    private float timer = 0f;
    private bool active = false;

    private Coroutine blinkCoroutine;

    private void Awake()
    {
        if (alertText == null) return;

        alertPanel.SetActive(false);//UIだけ非表示
        alertText.gameObject.SetActive(false);

        if (panelRect != null)
        {
            panelRect.anchoredPosition = offscreenPos;
        }
    }

    public void ShowAlert(string message)
    {
        if (alertText == null) return;

        Debug.LogWarning("イベント開始");
        alertText.text = message;

        // パネル表示
        alertPanel.SetActive(true);
        alertText.gameObject.SetActive(true);

        timer = 0f;
        active = true;

        //コルーチン初期化
        StopAllCoroutines();

        //スライドイン開始
        panelRect.anchoredPosition = offscreenPos;
        StartCoroutine(SlideInRoutine());

        //点滅開始
        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    private void Update()
    {
        if (!active) return;

        timer += Time.deltaTime;

        //表示時間が終わったらスライドアウトへ
        if (timer >= displayDuration)
        {
            StartCoroutine(SlideOutAndHide());
            active = false;
        }
    }

    //点滅処理
    private IEnumerator BlinkRoutine()
    {
        while (active)
        {
            alertText.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);

            alertText.enabled = false;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    //スライド処理
    private IEnumerator SlideInRoutine()
    {
        while (Vector2.Distance(panelRect.anchoredPosition, targetPos) > 1f)
        {
            panelRect.anchoredPosition = Vector2.Lerp(panelRect.anchoredPosition, targetPos, Time.deltaTime * slideSpeed);

            yield return null;
        }

        //位置を合わせる
        panelRect.anchoredPosition = targetPos;
    }

    private IEnumerator SlideOutAndHide()
    {
        //点滅停止
        if (blinkCoroutine != null) StopCoroutine(blinkCoroutine);


        alertText.enabled = true;

        //スライドアウト
        while (Vector2.Distance(panelRect.anchoredPosition, offscreenPos) > 1f)
        {
            panelRect.anchoredPosition = Vector2.Lerp(panelRect.anchoredPosition, offscreenPos, Time.deltaTime * slideOutSpeed);

            yield return null;
        }

        panelRect.anchoredPosition = offscreenPos;

        // 完全非表示
        alertPanel.SetActive(false);
        alertText.gameObject.SetActive(false);
    }
}
