using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventAlertUI : MonoBehaviour
{
    [SerializeField] private Text alertText;
    [SerializeField] private float displayDuration = 3f;
    [SerializeField] private float blinkSpeed = 0.5f;

    private float timer = 0f;
    private bool active = false;
    private bool visible = true;
    private float blinkTimer = 0f;

    private void Awake()
    {
        if (alertText == null)
        {
            return;
        }

        alertText.gameObject.SetActive(false);//UIだけ非表示
    }

    public void ShowAlert(string message)
    {
        if (alertText == null) return;

        Debug.LogWarning("イベント開始");
        alertText.text = message;
        alertText.gameObject.SetActive(true);

        timer = 0f;
        blinkTimer = 0f;
        visible = true;
        active = true;
        StartCoroutine(BlinkRoutine());
    }

    private void Update()
    {
        if (!active) return;

        timer += Time.deltaTime;

    }


    private IEnumerator BlinkRoutine()
    {
        alertText.gameObject.SetActive(true);

        while (active)
        {

            // ON
            alertText.enabled = true;
            yield return new WaitForSeconds(0.3f);

            // OFF
            alertText.enabled = false;
            yield return new WaitForSeconds(0.3f);

            if (timer >= displayDuration)
            {
                active = false;
                alertText.gameObject.SetActive(false);
            }

        }
    }
}
