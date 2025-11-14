using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject setCamera;

    private GameObject currentCamera;


    void Start()
    {

        // 各カメラオブジェクトを取得
        mainCamera = GameObject.Find("Main Camera");
        setCamera = GameObject.Find("SetSceneCamera");
        currentCamera = mainCamera;
        // サブカメラはデフォルトで無効にしておく
        setCamera.SetActive(false);
               
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeCamera()
    {
        if(currentCamera == mainCamera)
        {
            currentCamera = setCamera;
            setCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
        else
        {
            currentCamera = mainCamera;
            mainCamera.SetActive(true);
            setCamera.SetActive(false);
        }


    }
}
