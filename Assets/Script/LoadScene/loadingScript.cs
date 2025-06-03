using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScript : MonoBehaviour
{

    ////�@�񓯊�����Ŏg�p����AsyncOperation
    //private AsyncOperation async;

    [SerializeField, Header("���[�f�B���O����")] float waiteTime;
    [SerializeField,Header("�V�[���̖��O")] string[] sceneName;
    //���[�f�B���O�̃I�u�W�F�N�g
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
        //�@���[�h���UI���A�N�e�B�u�ɂ���
        loadPanel.SetActive(true);

        isLoading = true;

        ////�@�R���[�`�����J�n
        //StartCoroutine("LoadData");
    }
    /*�R���[�`���g���@�ǂݍ��ݑ������ĈӖ����Ȃ��ĂȂ��̂ň�U�ۗ�
    IEnumerator LoadData()
    {

        // �V�[���̓ǂݍ��݂�����
        async = SceneManager.LoadSceneAsync("testPlayScene");

        //�@�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
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
