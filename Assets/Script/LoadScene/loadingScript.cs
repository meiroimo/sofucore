using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScript : MonoBehaviour
{

    ////　非同期動作で使用するAsyncOperation
    //private AsyncOperation async;

    [SerializeField, Header("ローディング時間")] float waiteTime;
    [SerializeField,Header("シーンの名前")] string[] sceneName;
    //ローディングのオブジェクト
    [SerializeField] GameObject loadPanel;
    [SerializeField] GameObject transitionOBJ;
    [SerializeField] transitionScript transition;
    float nowTime = 0;
    bool isLoading;
    int nextLoadingSceneNo;

    async void Start()
    {
        if (!transitionOBJ.activeSelf) transitionOBJ.SetActive(true);
        if (loadPanel.activeSelf) loadPanel.SetActive(false);
        isLoading = false;
    }

    void Update()
    {
        if (!isLoading) return;
        nowTime += Time.deltaTime;
        //loadSlider.value = nowTime / waiteTime;
        if (nowTime < waiteTime) return;
        SceneManager.LoadSceneAsync(sceneName[nextLoadingSceneNo]);
    }

    public void setFadeIn(int sceneNo)
    {
        nextLoadingSceneNo = sceneNo;
        transition.isFadein = true;
        transitionOBJ.gameObject.SetActive(true);
        transition.Start();
    }

    public void NextScene()
    {
        //　ロード画面UIをアクティブにする
        loadPanel.SetActive(true);

        isLoading = true;

        ////　コルーチンを開始
        //StartCoroutine("LoadData");
    }
    /*コルーチン使う　読み込み速すぎて意味をなしてないので一旦保留
    IEnumerator LoadData()
    {

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("testPlayScene");

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            Debug.Log("nipc");

            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            loadSlider.value = progressVal;
            yield return null;
        }

    }
    */
}
