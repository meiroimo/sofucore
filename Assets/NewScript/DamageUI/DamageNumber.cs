using UnityEngine;
using TMPro;
using System.Collections;

//表示用
public class DamageNumber : MonoBehaviour
{
    [Header("アニメーション")]
    public float lifeTime = 1.0f;//表示されている時間
    public float startScale = 0.6f;//最小
    public float endScale = 1.2f;//最大
    public Vector3 moveOffset = new Vector3(0, 1.0f, 0);

    private TextMeshProUGUI text;
    private Coroutine animCoroutine;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Setup(int damage, Color color)
    {
        text.text = damage.ToString();
        text.color = color;

        transform.localScale = Vector3.one * startScale;

        if (animCoroutine != null)
            StopCoroutine(animCoroutine);

        animCoroutine = StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float time = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + moveOffset;
        Color startColor = text.color;

        while (time < lifeTime)
        {
            float t = time / lifeTime;

            //拡大
            transform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, t);

            //少し上に移動
            transform.position = Vector3.Lerp(startPos, endPos, t);

            //フェードアウト
            text.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                Mathf.Lerp(1f, 0f, t)
            );

            time += Time.deltaTime;
            yield return null;
        }

        DamageNumberController.Instance.PlaceInPool(this);
    }
}
