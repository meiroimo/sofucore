using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject SetCamera;
    
    void Start()
    {
        var gameObject = GameObject.Find("SetSceneCamera");
        if (gameObject != null)
        {
            // 各カメラオブジェクトを取得
            mainCamera = GameObject.Find("Main Camera");
            SetCamera = GameObject.Find("SetSceneCamera");
            Debug.Log("カメラスタート");
            // サブカメラはデフォルトで無効にしておく
            SetCamera.SetActive(false);
        }
          
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    public void changeCamera(GameObject ToCamera)
    {
        GameObject NowMainCamera;
         NowMainCamera = Camera.main.gameObject;
        NowMainCamera.SetActive(false);
        ToCamera.SetActive(true);

    }
}
