using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string[] nowLoadScene = { "TitleScene_Mei", "LoadScene", "SampleScene_MM" };

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextSceneAsync();
        }
    }

    public void LoadNextSceneAsync()
    {
        SceneManager.LoadScene(nowLoadScene[2]);
        //StartCoroutine(LoadSceneAsync(nowLoadScene[1]));
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
