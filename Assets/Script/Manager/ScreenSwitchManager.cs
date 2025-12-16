using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitchManager : MonoBehaviour
{
    public GameObject UIManagerObject;
    private UIManager UIManegeScript;
    public GameObject CameraManegerObject;
    private CameraManager CameraManegerScript;
    public bool SetFlg = false;//ŠJ‚¢‚Ä‚¢‚é‚©”»’è

    private PlayPauseMenu pauseMenu;


    void Start()
    {

        UIManagerObject = GameObject.Find("UIManeger");
        UIManegeScript = UIManagerObject.GetComponent<UIManager>();
        CameraManegerObject = GameObject.Find("CameraManager");
        CameraManegerScript = CameraManegerObject.GetComponent<CameraManager>();

        pauseMenu = FindObjectOfType<PlayPauseMenu>();

    }
  
    // Update is called once per frame
    void Update()
    {
        PauseKey();
    }

    public void OpenSetScene()
    {
        UIManegeScript.UIOpen();
        CameraManegerScript.changeCamera();
        SetFlg = true;
    }

    public void CloseSetScene()
    {
        UIManegeScript.UIClose();
        CameraManegerScript.changeCamera();
        SetFlg = false;

    }

    private void PauseKey()//ƒL[“ü—Í‚ğ“¾‚éŠÖ”
    {
        if (Input.GetKeyDown(KeyCode.Tab))//tab‰Ÿ‚µ‚½‚ç
        {
            if (pauseMenu.IsPaused) return;
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
