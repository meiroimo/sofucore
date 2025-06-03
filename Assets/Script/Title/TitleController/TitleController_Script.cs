using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// タイトルシーンの処理全般を行うスクリプト
/// </summary>
public class TitleController_Script : MonoBehaviour
{
    //各サブシーンのUIパネルを掴む
    public GameObject[] titleUiPanel = new GameObject[5];
    public GameObject settingFirstbutton;
    public GameObject selectFirstbutton;
    public GameObject endFirstbutton;

    //タイトルシーンの処理
    public enum TitleSubScene
    {
        START,//スタート画面
        SELECT,//セレクト画面
        SETTING,//設定画面
        ACHIEVEMENTS,//実績画面
        ITEMBOOK,//図鑑画面
        NONE = -1,
    }

    public TitleSubScene subScene;

    private TitleStart_Script titleStart;
    private TitleGameSelect_Script titleGameSelect;
    private TitleGameSetting_Script titleGameSetting;

    private void Awake()
    {
        titleStart = GetComponent<TitleStart_Script>();
        titleGameSelect = GetComponent<TitleGameSelect_Script>();
        titleGameSetting = GetComponent<TitleGameSetting_Script>();
    }

    void Start()
    {
        //if(titleStart != null)
        //{
        //    Debug.Log("hoge");
        //}

        subScene = TitleSubScene.START;
        IndicationTitleUI();
    }

    void Update()
    {
        SubSceneTransition();
    }

    /// <summary>
    /// サブシーンによって表示するUIを変える関数
    /// </summary>
    public void IndicationTitleUI()
    {
        for(int i = 0;i < titleUiPanel.Length;i++)
        {
            if (titleUiPanel[i] == null) continue;
            if((int)subScene == i)
            {
                titleUiPanel[i].SetActive(true);
            }
            else
            {
                titleUiPanel[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// switch文でサブシーンごとに処理を分けて実行する関数<br/>
    /// 各サブシーンの処理はそれぞれ違うスクリプトに記述
    /// </summary>
    public void SubSceneTransition()
    {
        switch (subScene)
        {
            case TitleSubScene.START:
                titleStart.StartProcessing();
                break;
            case TitleSubScene.SELECT:
                titleGameSetting.PushSettingKey();
                break;
            case TitleSubScene.SETTING:
                titleGameSetting.PushCloseSettingKey();
                break;
            case TitleSubScene.ACHIEVEMENTS:
                break;
            case TitleSubScene.ITEMBOOK:
                break;
        }
    }

    public void SelectedSettingMenu()
    {
        //初期選択ボタンの初期化
        EventSystem.current.SetSelectedGameObject(null);
        //初期選択ボタンの再指定
        EventSystem.current.SetSelectedGameObject(settingFirstbutton);
    }

    public void SelectedMenu()
    {
        //初期選択ボタンの初期化
        EventSystem.current.SetSelectedGameObject(null);
        //初期選択ボタンの再指定
        EventSystem.current.SetSelectedGameObject(selectFirstbutton);
    }

    public void SelectedEndMenu()
    {
        //初期選択ボタンの初期化
        EventSystem.current.SetSelectedGameObject(null);
        //初期選択ボタンの再指定
        EventSystem.current.SetSelectedGameObject(endFirstbutton);
    }
}
