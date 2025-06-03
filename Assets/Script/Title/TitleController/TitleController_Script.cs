using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �^�C�g���V�[���̏����S�ʂ��s���X�N���v�g
/// </summary>
public class TitleController_Script : MonoBehaviour
{
    //�e�T�u�V�[����UI�p�l����͂�
    public GameObject[] titleUiPanel = new GameObject[5];
    public GameObject settingFirstbutton;
    public GameObject selectFirstbutton;
    public GameObject endFirstbutton;

    //�^�C�g���V�[���̏���
    public enum TitleSubScene
    {
        START,//�X�^�[�g���
        SELECT,//�Z���N�g���
        SETTING,//�ݒ���
        ACHIEVEMENTS,//���щ��
        ITEMBOOK,//�}�Ӊ��
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
    /// �T�u�V�[���ɂ���ĕ\������UI��ς���֐�
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
    /// switch���ŃT�u�V�[�����Ƃɏ����𕪂��Ď��s����֐�<br/>
    /// �e�T�u�V�[���̏����͂��ꂼ��Ⴄ�X�N���v�g�ɋL�q
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
        //�����I���{�^���̏�����
        EventSystem.current.SetSelectedGameObject(null);
        //�����I���{�^���̍Ďw��
        EventSystem.current.SetSelectedGameObject(settingFirstbutton);
    }

    public void SelectedMenu()
    {
        //�����I���{�^���̏�����
        EventSystem.current.SetSelectedGameObject(null);
        //�����I���{�^���̍Ďw��
        EventSystem.current.SetSelectedGameObject(selectFirstbutton);
    }

    public void SelectedEndMenu()
    {
        //�����I���{�^���̏�����
        EventSystem.current.SetSelectedGameObject(null);
        //�����I���{�^���̍Ďw��
        EventSystem.current.SetSelectedGameObject(endFirstbutton);
    }
}
