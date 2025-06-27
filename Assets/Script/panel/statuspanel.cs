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
    public PlayerStatus_Script PleyerStatus;

    void Start()
    {
        debagText = debagTextobj.GetComponent<Text>();
        themeText = new string[21];
        skillText = new string[5]; 
        themeTextset();
        skillTextset();

        //�q�I�u�W�F�N�g�̃e�L�X�g�R���|�[�l���g���擾
        statusText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        PleyerStatus = GameObject.Find("stand").GetComponent<PlayerStatus_Script>();//  ���ږ��O�������Ă���̂Ńv���C���[obj�̖��O���ς��Ƃ������ύX������

    }

    // Update is called once per frame
    void Update()
    {
        settext();
     //   setdebagtext();
    }

    //�e�L�X�g���Z�b�g
    void settext()
    {// HP 100     �U���� 100     �X�^�~�i 100   �T�C�Y   ����
      //  �U���͈�  �X�L���|�C���g 100 �X�L���`���[�W100
        statusText.text =
      " HP  " + PleyerStatus.player_MaxHealth+ "    �U����  " + PleyerStatus.player_Attack_Power + "    �X�^�~�i  " + PleyerStatus.player_MaxSutamina + "    �T�C�Y  " + PleyerStatus.player_Size +"\n"+
       "  �U���͈� " + PleyerStatus.D_player_Attack_Range + " �X�L���|�C���g " + PleyerStatus.player_Skill_Point + " �X�L���`���[�W " + PleyerStatus.player_Skill_Charge;

    }
    void setdebagtext()
    {
       
        debagText.text = "�f�o�b�N�p�e�L�X�g\n" +
       "�ǉ��ő�̗�" + PleyerStatus.add_Player_MaxHealth + "\n"
        +"�ǉ��X�^�~�i" + PleyerStatus.add_Player_MaxSutamina + "\n"
        + "�ǉ��U����" + PleyerStatus.add_Player_Attack_Power + "\n"
        //+ "�ǉ��h���" + PleyerStatus.add_Player_Defense + "\n"
        //+
        //"�ǉ��ړ����x" + PleyerStatus.add_Player_Speed + "\n"
        //+ "�ǉ���S��" + PleyerStatus.add_Player_Critical + "\n"
        //+ "�ǉ���S�_����" + PleyerStatus.add_Player_Critical_Damage +
        ;

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
