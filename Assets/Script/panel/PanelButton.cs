using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    [SerializeField] private GameObject PanelImage;//�p�l���C���[�WOBJ
    [SerializeField] private GameObject PanelUI;//�p�l���E�B���h�EUI
    [SerializeField] public softVinyl SetSofvidata;//�ݒu�\�t�r�f�[�^

    public GameObject selectSofviOBJ;//�I�𒆂̃\�t�r�f�[�^�I�u�W�F
    public softVinyl selectSofviDeta;//�I�𒆂̃\�t�r�f�[�^�I�u�W�F
    private Outline outline;

    bool selectPanel;//�p�l����I�𔻒�
    public bool selectCheck;
    public GameObject PoptextWindowObj;//�|�b�v�A�b�v�E�B���h�E�I�u�W�F
    public Text PopTextSelect;//�|�b�v�A�b�v�e�L�X�g�Z���N�g�\�t�r
    public Text PopTextonpointar;//�|�b�v�A�b�v�e�L�X�g�d�Ȃ����\�t�r
    public string[] themeText;//theme�̕�����z��
    public string[] skillText;//skill�̕�����z��
    public string[] nameText;//name�̕�����z��
    public int Number;//�{�^���ԍ�
    public GameObject ImgStrage;//�C���[�W�摜�X�g���[�W�X�N���v�g
    ImgStrageScript ImgStrageScriptdata;//�C���[�W�摜�f�[�^�X�g���[�W
    // Start is called before the first frame update
    void Start()
    {
        ImgStrage = GameObject.Find("ImgStrage");
        ImgStrageScriptdata = ImgStrage.GetComponent<ImgStrageScript>();

        selectPanel = false;
        PanelImage = gameObject.transform.GetChild(0).gameObject;
        SetSofvidata = this.gameObject.GetComponent<softVinyl>();//���g�̃\�t�r�X�N���v�g��͂�
        //Debug.Log(SetSofvidata);
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();

        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
  //      PopTextSelect =PoptextWindowObj.transform.GetChild(0).gameObject.GetComponent<Text>();
       // PopTextonpointar = PoptextWindowObj.transform.GetChild(1).gameObject.GetComponent<Text>();
        themeText = new string[21];
        skillText = new string[5];
        nameText = new string[102];
        themeTextset();
        skillTextset();
        nameTextset();
    }

    // Update is called once per frame
    void Update()
    {
        
        setImage();

        if (selectSofviDeta.selectButton != this.gameObject)
        {
            selectPanel = false;
            outline.enabled = false;

        }
    }
    public void onclickButton()
    {

        if(!selectPanel && SetSofvidata.sofvimodel!= softVinyl.SOFVINUMBER.NULL)
        {
            setselectSofviData();
            selectPanel = true;
            outline.enabled = true;
       //     PoptextWindowObj.SetActive(false);
        }
        else
        {

            if (selectSofviDeta.selectButton==this.gameObject)
            {
                againClick();
                Debug.Log("�����{�^�������ꂽ");

                //    PoptextWindowObj.SetActive(false);
            }
        }

        Debug.Log("�����ꂽ");
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if (selectSofviDeta.selectButton != this.gameObject&& selectSofviDeta.selectCheck)
    //    {
    //        setTextPopTextWindow();

    //        PoptextWindowObj.SetActive(true);
    //    }
    //    else
    //    {
    //        PoptextWindowObj.SetActive(false);
    //    }


    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    PoptextWindowObj.SetActive(false);
    //}

    void setImage()
    {



        PanelImage.GetComponent<Image>().sprite = ImgStrageScriptdata.sprites[(int)SetSofvidata.sofvimodel];


    }
    void againClick()//�Z���N�g�f�[�^�����Z�b�g
    {
        selectSofviDeta.cost = 0;
        selectSofviDeta.skill = softVinyl.SKILLNUM.NULL;
        selectSofviDeta.theme =softVinyl.themeNu��.NULL;
        selectSofviDeta.ListNumber = 0;
        selectSofviDeta.buffMainstatus = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.buffSubstatus1 = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.buffSubstatus2 = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.buffSubstatus3 = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.Buffparameter = 0;
        selectSofviDeta.Buffparameter1 = 0;
        selectSofviDeta.Buffparameter2 = 0;
        selectSofviDeta.Buffparameter3 = 0;
        selectSofviDeta.buffName = null;
        selectSofviDeta.buffName1 = null;
        selectSofviDeta.buffName2 = null;
        selectSofviDeta.buffName3 = null;
        selectSofviDeta.selectButton = null;
        selectSofviDeta.selectCheck = false;
        selectPanel = false;
        outline.enabled = false;

    }
    private void setselectSofviData()
    {


        // selectSofviDeta = SetSofvidata;
        

        selectSofviDeta.sofvimodel = SetSofvidata.sofvimodel;


        selectSofviDeta.cost = SetSofvidata.cost;
        selectSofviDeta.skill = SetSofvidata.skill;
        selectSofviDeta.theme = SetSofvidata.theme;
        selectSofviDeta.ListNumber = SetSofvidata.ListNumber;
        selectSofviDeta.buffMainstatus = SetSofvidata.buffMainstatus;
        selectSofviDeta.buffSubstatus1 = SetSofvidata.buffSubstatus1;
        selectSofviDeta.buffSubstatus2 = SetSofvidata.buffSubstatus2;
        selectSofviDeta.buffSubstatus3 = SetSofvidata.buffSubstatus3;
        selectSofviDeta.Buffparameter = SetSofvidata.Buffparameter;
        selectSofviDeta.Buffparameter1 = SetSofvidata.Buffparameter1;
        selectSofviDeta.Buffparameter2 = SetSofvidata.Buffparameter2;
        selectSofviDeta.Buffparameter3 = SetSofvidata.Buffparameter3;
        selectSofviDeta.buffName = SetSofvidata.buffName;
        selectSofviDeta.buffName1 = SetSofvidata.buffName1;
        selectSofviDeta.buffName2 = SetSofvidata.buffName2;
        selectSofviDeta.buffName3 = SetSofvidata.buffName3;
        selectSofviDeta.selectButton = this.gameObject;
        selectSofviDeta.selectCheck =true;
       // Debug.Log(selectSofviDeta.Buffparameter);

    }
    void setTextPopTextWindow()//�|�b�v�A�b�v�E�B���h�E�̃e�L�X�g���Z�b�g
    {

        PopTextSelect.text = "�I�𒆁F"+ nameText[(int)selectSofviDeta.sofvimodel] + "\n" + themeText[(int)selectSofviDeta.theme] + "\n" + skillText[(int)selectSofviDeta.skill] + "\n" + "�R�X�g" +selectSofviDeta.cost ;
        PopTextonpointar.text = "��r���F" + nameText[(int)SetSofvidata.sofvimodel] + "\n" + themeText[(int)SetSofvidata.theme] + "\n" + skillText[(int)SetSofvidata.skill] + "\n" + "�R�X�g" + SetSofvidata.cost;

    }

    void themeTextset()//�e�[�}�e�L�X�g���Z�b�g
    {
        themeText[1] = "�e�[�}�P";
        themeText[2] = "�e�[�}�Q";
        themeText[3] = "�e�[�}�R";
        themeText[4] = "�e�[�}�S";
        themeText[5] = "�e�[�}�T";
        themeText[6] = "�e�[�}�U";
        themeText[7] = "�e�[�}�V";
        themeText[8] = "�e�[�}�W";
        themeText[9] = "�e�[�}�X";
        themeText[10] = "�e�[�}�P�O";
        themeText[11] = "�e�[�}�P�P";
        themeText[12] = "�e�[�}�P�Q";
        themeText[13] = "�e�[�}�P�R";
        themeText[14] = "�e�[�}�P�S";
        themeText[15] = "�e�[�}�P�T";
        themeText[16] = "�e�[�}�P�U";
        themeText[17] = "�e�[�}�P�V";
        themeText[18] = "�e�[�}�P�W";
        themeText[19] = "�e�[�}�P�X";
        themeText[20] = "�e�[�}�Q�O";

    }
    void skillTextset()//�X�L���e�L�X�g�̃Z�b�g
    {

        skillText[1] = "�X�L���P";
        skillText[2] = "�X�L���Q";
        skillText[3] = "�X�L���R";
        skillText[4] = "�X�L���S";

    }

    void nameTextset()//�X�L���e�L�X�g�̃Z�b�g
    {
        for(int i=1;i<(int)softVinyl.SOFVINUMBER.MAX;i++)
        {
            nameText[i] = "���O"+i;

        }

        
    }
}
