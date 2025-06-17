using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statuspanel : MonoBehaviour
{
    [Header ("�\�t�r�X�e�[�^�X�̃e�L�X�g")]public Text statusText;
    [Header("�f�o�b�N�e�L�X�gobj")] public GameObject debagTextobj;

    [Header("�f�o�b�N�e�L�X�g")] public Text debagText;

    [Header("�Z���N�g�\�t�r�f�[�^�Q��")] public softVinyl SelectsoftVinyldata;
    
    public string[] themeText;//theme�̕�����z��
    public string[] skillText;//skill�̕�����z��
    public PlayerStatus_Script debagstatus;

    void Start()
    {
        debagText = debagTextobj.GetComponent<Text>();
        themeText = new string[21];
        skillText = new string[5]; 
        themeTextset();
        skillTextset();

        //�q�I�u�W�F�N�g�̃e�L�X�g�R���|�[�l���g���擾
        statusText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        debagstatus = GameObject.Find("lough_model").GetComponent<PlayerStatus_Script>();//  ���ږ��O�������Ă���̂Ńv���C���[obj�̖��O���ς��Ƃ������ύX������

    }

    // Update is called once per frame
    void Update()
    {
        settext();
        setdebagtext();
    }

    //�e�L�X�g���Z�b�g
    void settext()
    {
        statusText.text =
       themeText[(int)SelectsoftVinyldata.theme] + "\n�R�X�g" + SelectsoftVinyldata.cost + "\n"+skillText[(int)SelectsoftVinyldata.skill]
       + "\n"+ SelectsoftVinyldata.ListNumber;

    }
    void setdebagtext()
    {
       
        debagText.text = "�f�o�b�N�p�e�L�X�g\n" +
       "�ǉ��ő�̗�" + debagstatus.add_Player_MaxHealth + "\n"
        +"�ǉ��X�^�~�i" + debagstatus.add_Player_MaxSutamina + "\n"
        + "�ǉ��U����" + debagstatus.add_Player_Attack_Power + "\n"
        + "�ǉ��h���" + debagstatus.add_Player_Defense + "\n"
        + "�ǉ��ړ����x" + debagstatus.add_Player_Speed + "\n"
        + "�ǉ���S��" + debagstatus.add_Player_Critical + "\n"
        + "�ǉ���S�_����" + debagstatus.add_Player_Critical_Damage + "\n";

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
}
