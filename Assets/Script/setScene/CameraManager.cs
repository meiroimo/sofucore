using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject SetCamera;
    
    void Start()
    {

        // 各カメラオブジェクトを取得
        mainCamera = GameObject.Find("Main Camera");
        SetCamera = GameObject.Find("SetSceneCamera");

        // サブカメラはデフォルトで無効にしておく
        SetCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // もしSpaceキーが押されたならば、
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
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
