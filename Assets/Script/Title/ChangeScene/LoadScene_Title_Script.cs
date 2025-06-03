using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene_Title_Script : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadNextSceneAsync());
    }

    IEnumerator LoadNextSceneAsync()
    {
        //前のロードシーンをアンロード
        SceneManager.UnloadSceneAsync("LoadScene");

        //次のシーンを非同期で読み込み
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneLoader.nowLoadScene[2]);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
