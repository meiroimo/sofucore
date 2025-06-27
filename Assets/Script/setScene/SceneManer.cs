using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManer : MonoBehaviour
{

    public GameObject UIManagerObject;
    private UIManager UIManegeScript;
    public GameObject CameraManegerObject;
    private CameraManager CameraManegerScript;
    bool SetFlg=false;//開いているか判定

    // Start is called before the first frame update
    private void Awake()
    {
        Scene sceneB = SceneManager.GetSceneByName("SetSofviScene");
        Debug.LogFormat("sceneB ={0}", sceneB.IsValid());
        //var gameObject = GameObject.Find("SetSceneCanvas");
        if (sceneB.IsValid()==false)
        {
            OnLoadSceneAdditive();
            Debug.Log("設置シーン読み込み");
        }


    }
    void Start()
    {
        
        UIManagerObject = GameObject.Find("UIManeger");
        UIManegeScript = UIManagerObject.GetComponent<UIManager>();
        CameraManegerObject = GameObject.Find("CameraManager");
        CameraManegerScript = CameraManegerObject.GetComponent<CameraManager>();
      
    }
    public void OnLoadSceneAdditive()
    {
        
        //SceneBを加算ロード。現在のシーンは残ったままで、シーンBが追加される
        SceneManager.LoadScene("SetSofviScene", LoadSceneMode.Additive);
    }
    // Update is called once per frame
    void Update()
    {
        PauseKey();
    }

    public void OpenSetScene()
    {
        UIManegeScript.UIOpen();
        CameraManegerScript.changeCamera(CameraManegerScript.SetCamera);
        SetFlg = true;
    }

    public void CloseSetScene()
    {
        UIManegeScript.UIClose();
        CameraManegerScript.changeCamera(CameraManegerScript.mainCamera);
        SetFlg = false;

    }

    private void PauseKey()//キー入力を得る関数
    {
        if (Input.GetKeyDown(KeyCode.Tab))//tab押したら
        {
            Debug.Log("tabおした");
            if (!SetFlg)
            {
                Time.timeScale = 0f;
                OpenSetScene();

            }
            else
            {
                Time.timeScale = 1f;

                CloseSetScene();
            }
        }
    }
}
