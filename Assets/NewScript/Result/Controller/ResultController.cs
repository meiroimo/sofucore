using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField, Header("シーンの名前")] string[] sceneName;
    public AudioSource audioSource;
    public AudioClip clearSE;

    [SerializeField] private Button firstButton;//最初に選択されるボタン

    void Start()
    {
        if(ResultClear.Instance.isGameClear)
        {
            audioSource.PlayOneShot(clearSE);
        }
        StartCoroutine(SelectFirstButtonNextFrame(firstButton));
    }

    void Update()
    {
        
    }

    public void GoToMainGameScene()
    {
        Difficulty.ResetDifficulty();
        SceneManager.LoadScene(sceneName[1]);
        sofviSotrage.sofviStrageList.Clear();
        ResultClear.Instance.isGameClear = false;
    }

    public void GotToTitleScene()
    {
        sofviSotrage.sofviStrageList.Clear();
        SceneManager.LoadScene(sceneName[0]);
        ResultClear.Instance.isGameClear = false;
    }

    private IEnumerator SelectFirstButtonNextFrame(Button button)
    {
        yield return new WaitForSeconds(1f); // 1秒待つ
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null); //念のため一回解除
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }
    }

}
