using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class BossWarningUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] GameObject warningUI;
    [SerializeField] CanvasGroup canvasGroup;

    [Header("Animation Settings")]
    [SerializeField] float fadeInTime = 0.5f;
    [SerializeField] float stayTime = 1.5f;
    [SerializeField] float fadeOutTime = 0.5f;
    [SerializeField] Vector3 startScale = new Vector3(0.8f, 0.8f, 1f);

    private Vector3 defaultScale;

    private float displayTime;

    public float DisplayTime { get => displayTime; set => displayTime = value; }

    private void Awake()
    {
        displayTime = fadeInTime + stayTime + fadeOutTime;
        defaultScale = warningUI.transform.localScale;

        warningUI.SetActive(false);
        canvasGroup.alpha = 0f;
    }

    public void Show()
    {
        StartCoroutine(PlayWarningAnimation());
    }

    private IEnumerator PlayWarningAnimation()
    {
        warningUI.SetActive(true);

        // 初期状態
        canvasGroup.alpha = 0f;
        warningUI.transform.localScale = startScale;

        //フェードイン＋拡大
        float t = 0f;
        while (t < fadeInTime)
        {
            t += Time.deltaTime;
            float rate = t / fadeInTime;

            canvasGroup.alpha = Mathf.Lerp(0f, 1f, rate);
            warningUI.transform.localScale =
                Vector3.Lerp(startScale, defaultScale, rate);

            yield return null;
        }

        //表示キープ
        yield return new WaitForSeconds(stayTime);

        //フェードアウト
        t = 0f;
        while (t < fadeOutTime)
        {
            t += Time.deltaTime;
            float rate = t / fadeOutTime;

            canvasGroup.alpha = Mathf.Lerp(1f, 0f, rate);
            yield return null;
        }

        //完全に消す
        warningUI.SetActive(false);
    }
}
