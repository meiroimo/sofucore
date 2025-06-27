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
    bool SetFlg=false;//�J���Ă��邩����

    // Start is called before the first frame update
    private void Awake()
    {
        Scene sceneB = SceneManager.GetSceneByName("SetSofviScene");
        Debug.LogFormat("sceneB ={0}", sceneB.IsValid());
        //var gameObject = GameObject.Find("SetSceneCanvas");
        if (sceneB.IsValid()==false)
        {
            OnLoadSceneAdditive();
            Debug.Log("�ݒu�V�[���ǂݍ���");
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
        
        //SceneB�����Z���[�h�B���݂̃V�[���͎c�����܂܂ŁA�V�[��B���ǉ������
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

    private void PauseKey()//�L�[���͂𓾂�֐�
    {
        if (Input.GetKeyDown(KeyCode.Tab))//tab��������
        {
            Debug.Log("tab������");
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
