using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TitleController_Script;

public class TitleGameSetting_Script : MonoBehaviour
{
    private TitleController_Script titleController;

    private void Awake()
    {
        titleController = GetComponent<TitleController_Script>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Escape�L�[�������ꂽ���T�u�V�[����J�ڂ���֐�<br/>
    /// SELECT �� SETTING
    /// </summary>
    public void PushSettingKey()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            titleController.subScene = TitleSubScene.SETTING;
            titleController.SelectedSettingMenu();
            titleController.IndicationTitleUI();
        }
    }

    /// <summary>
    /// �ݒ�{�^���������ꂽ���T�u�V�[����J�ڂ���֐�<br/>
    /// SELECT �� SETTING
    /// </summary>
    public void PushSettingButton()
    {
        titleController.subScene = TitleSubScene.SETTING;
        titleController.SelectedSettingMenu();
        titleController.IndicationTitleUI();
    }

    public void PushCloseSettingKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            titleController.subScene = TitleSubScene.SELECT;
            titleController.SelectedMenu();
            titleController.IndicationTitleUI();
        }
    }

    public void PushCloseSettingButton()
    {
        titleController.subScene = TitleSubScene.SELECT;
        titleController.SelectedMenu();
        titleController.IndicationTitleUI();
    }

}
