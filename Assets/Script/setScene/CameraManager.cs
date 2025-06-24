using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject SetCamera;
    
    void Start()
    {

        // �e�J�����I�u�W�F�N�g���擾
        mainCamera = GameObject.Find("Main Camera");
        SetCamera = GameObject.Find("SetSceneCamera");

        // �T�u�J�����̓f�t�H���g�Ŗ����ɂ��Ă���
        SetCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // ����Space�L�[�������ꂽ�Ȃ�΁A
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �e�J�����I�u�W�F�N�g�̗L���t���O���t�](true��false,false��true)������
            mainCamera.SetActive(!mainCamera.activeSelf);

            SetCamera.SetActive(!SetCamera.activeSelf);
        }
    }
    public void changeCamera(GameObject ToCamera)
    {
        GameObject NowMainCamera;
         NowMainCamera = Camera.main.gameObject;
        NowMainCamera.SetActive(false);
        ToCamera.SetActive(true);

    }
}
