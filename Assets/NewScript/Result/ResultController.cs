using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField, Header("�V�[���̖��O")] string[] sceneName;
    public AudioSource audioSource;
    public AudioClip clearSE;

    [SerializeField] private Button firstButton;//�ŏ��ɑI�������{�^��

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
        SceneManager.LoadScene(sceneName[1]);
        ResultClear.Instance.isGameClear = false;
    }

    public void GotToTitleScene()
    {
        SceneManager.LoadScene(sceneName[0]);
        ResultClear.Instance.isGameClear = false;
    }

    private IEnumerator SelectFirstButtonNextFrame(Button button)
    {
        yield return new WaitForSeconds(1f); // 1�b�҂�
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null); //�O�̂��߈�����
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }
    }

}
