using UnityEngine;
using UnityEngine.UI;

public class EventPopupUI : MonoBehaviour
{
    [SerializeField] private Text newsText;
    [SerializeField] private float displayDuration = 3f;
    [SerializeField] private Vector2 startOffset = new Vector2(-300, 0);//左からスライド開始
    [SerializeField] private Vector2 endOffset = new Vector2(10, 0);//最終位置

    private float timer = 0f;
    private bool active = false;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = newsText.GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ShowPopup(string message)
    {
        newsText.text = message;
        rectTransform.anchoredPosition = startOffset;
        gameObject.SetActive(true);
        timer = 0f;
        active = true;
    }

    private void Update()
    {
        if (!active) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / displayDuration);

        // 左から右にスライド
        rectTransform.anchoredPosition = Vector2.Lerp(startOffset, endOffset, t);

        if (t >= 1f)
        {
            Debug.LogWarning("fdsgd");
            gameObject.SetActive(false);
            active = false;
        }
    }
}
