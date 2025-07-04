using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    [SerializeField, Header("ÉVÅ[ÉìÇÃñºëO")] string[] sceneName;
    public AudioSource audioSource;
    public AudioClip clearSE;


    // Start is called before the first frame update
    void Start()
    {
        if(ResultClear.Instance.isGameClear)
        {
            audioSource.PlayOneShot(clearSE);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainGameScene()
    {
        SceneManager.LoadScene(sceneName[1]);
    }

    public void GotToTitleScene()
    {
        SceneManager.LoadScene(sceneName[0]);
    }
}
