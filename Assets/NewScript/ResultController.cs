using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    [SerializeField, Header("ÉVÅ[ÉìÇÃñºëO")] string[] sceneName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainGameScene()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void GotToTitleScene()
    {
        SceneManager.LoadScene(sceneName[1]);
    }
}
