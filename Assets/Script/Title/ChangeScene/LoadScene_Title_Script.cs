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
        //�O�̃��[�h�V�[�����A�����[�h
        SceneManager.UnloadSceneAsync("LoadScene");

        //���̃V�[����񓯊��œǂݍ���
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneLoader.nowLoadScene[2]);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
