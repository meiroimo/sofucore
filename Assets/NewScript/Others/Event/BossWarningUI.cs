using System.Collections;
using UnityEngine;

public class BossWarningUI : MonoBehaviour
{
    public GameObject warningUI;
    public float displayTime = 2.5f;

    private void Awake()
    {
        warningUI.SetActive(false);
    }

    public void Show()
    {
        StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        warningUI.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        warningUI.SetActive(false);
    }
}
