using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Mesh;


public class SetSofviManeger : MonoBehaviour
{

    [Header("�ݒu�ꏊ�̃\�t�r�f�[�^")]      public List<softVinyl>   setSoftVinylData;
    [Header("�ݒu�ꏊ�̃X�N���v�g")]        public List<Setposition3d> setposition3Ds;

    [Header("�I�𒆃\�t�r�f�[�^�Q��")]      public softVinyl selectSoftVinylData;
    [Header("�v���C���[�X�e�[�^�X�Q��")]    public PlayerStatus_Script PlayerStatus_Script;
    [Header("�S�Ă̐ݒu�ꏊ�̐e�I�u�W�F")]  public GameObject AllSetobject;
   
    bool checkBuffStatus;//�����X�e�[�^�X�̔��f���ł��Ă��邩

    public GameObject selectSofviOBJ;//�I�𒆂̃\�t�r�f�[�^�I�u�W�F
    public softVinyl selectSofviDeta;//�I�𒆂̃\�t�r�f�[�^
    private int MAXSETPOSITION = 6;
    public Ray ray;//�J���������΂����C
    void Start()
    {
        checkBuffStatus = false;
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();
        setpotionDataSet();
        PlayerStatus_Script= GameObject.Find("Player_stand").GetComponent<PlayerStatus_Script>();//  ���ږ��O�������Ă���̂Ńv���C���[obj�̖��O���ς��Ƃ������ύX������
    }

    // Update is called once per frame
    void Update()
    {
        setSofuvi();
        SofviPreview();
    }

    public void addSetPotiionSofviData(softVinyl softVinyldata,Setposition3d setposition3D)
    {
        setSoftVinylData.Add(softVinyldata);
        setposition3Ds.Add(setposition3D);
    }

    void setpotionDataSet()
    {
        for (int i = 0; i < AllSetobject.gameObject.transform.childCount; i++)
        {
            AllSetobject.gameObject.transform.GetChild(i).gameObject.GetComponent<Setposition3d>().setpotionNumber = (i);
            addSetPotiionSofviData(AllSetobject.gameObject.transform.GetChild(i).gameObject.GetComponent<softVinyl>(), AllSetobject.gameObject.transform.GetChild(i).gameObject.GetComponent<Setposition3d>());
        }


    }
    void SofviPreview()
    {
        if (selectSofviDeta.selectCheck)//�\�t�r���Z���N�g����Ă�����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//���C���΂�
            RaycastHit hit;//���C�ɓ��������܂��I�u�W�F�N�g�̃f�[�^�̕ۑ���

            if (Physics.Raycast(ray, out hit))//���C�ɓ������Ă��鎞
            {
                if (hit.transform.tag == "SetPosition" && hit.collider.GetComponent<Setposition3d>().checkmodelset == false)//�Z�b�g�|�W�V�����ɓ������Ă��邩�����u����Ă��Ȃ��ꍇ
                {
                    if (hit.collider.GetComponent<Setposition3d>().translucentflg == false)//�����������\��������Ă��Ȃ���Δ������\�t�r�𐶐�
                    {
                        softVinyl softVinylTest;
                        softVinylTest = hit.collider.GetComponent<softVinyl>();
                        softVinylTest = selectSofviDeta;//�Z���N�g���̃\�t�r�f�[�^��ݒu�ꏊ�ɓn���B�\�����f���̃f�[�^�������Ă��邽�߁B
                        hit.collider.GetComponent<Setposition3d>().TranslucentSofviIns();//���������f���̃C���X�^���X�֐�����т���
                    }

                    hit.collider.GetComponent<Setposition3d>().rathit = true;//���C���������Ă锻���true
                    for (int i = 0; i < MAXSETPOSITION; i++)//���C�̓������Ă��Ȃ��ꏊ�̔����false��
                    {
                        if (hit.collider.GetComponent<Setposition3d>().setpotionNumber == i) continue;
                        setposition3Ds[i].rathit = false;

                    }

                }
                else//���C���ǂ��̐ݒu�ꏊ�ɂ��������Ă��Ȃ��ꍇ�͂��ׂł̃��C�̓������������false
                {
                    for(int i=0;i< MAXSETPOSITION;i++)
                    {

                        setposition3Ds[i].rathit = false;

                    }
                }

            }
        }

    }
   
    void setSofuvi()

    {
        if(selectSofviDeta.selectCheck&& Input.GetMouseButtonDown(0))//�\�t�r�I������Ă��炩���N���b�N��
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//���C��΂�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "SetPosition")//���C�����������I�u�W�F�N�g�փA�N�Z�X���ݒu�ꏊ��������
            {
                hit.collider.GetComponent<Setposition3d>().checkmodelset =true;//�ݒu�ꏊ�̐ݒu�����true
            }
  
        }
    }
    //���̊֐��̓Z�b�g�|�W�V�����ł悭�ˁH
    //�Z���N�g���̃\�t�r�f�[�^��ݒu�\�t�r�f�[�^�ɃZ�b�g����֐�
    public void setpositionsofviDeta(softVinyl setPositionSoftVinylData)
    {
        if (selectSoftVinylData.selectCheck)
        {
            setPositionSoftVinylData.skill = selectSoftVinylData.skill;
            setPositionSoftVinylData.theme = selectSoftVinylData.theme;
            setPositionSoftVinylData.cost = selectSoftVinylData.cost;
            setPositionSoftVinylData.ListNumber = selectSoftVinylData.ListNumber;
            setPositionSoftVinylData.buffMainstatus = selectSoftVinylData.buffMainstatus;
            setPositionSoftVinylData.buffSubstatus1 = selectSoftVinylData.buffSubstatus1;
            setPositionSoftVinylData.buffSubstatus2 = selectSoftVinylData.buffSubstatus2;
            setPositionSoftVinylData.buffSubstatus3 = selectSoftVinylData.buffSubstatus3;
            setPositionSoftVinylData.Buffparameter = selectSoftVinylData.Buffparameter;
            setPositionSoftVinylData.Buffparameter1 = selectSoftVinylData.Buffparameter1;
            setPositionSoftVinylData.Buffparameter2 = selectSoftVinylData.Buffparameter2;
            setPositionSoftVinylData.Buffparameter3 = selectSoftVinylData.Buffparameter3;
        }
    }

    /// <summary>
    /// 6�̐ݒu�ꏊ�̒u����Ă���ꏊ�̃\�t�r�̃X�e�[�^�X�����ׂăv���C���[�ɔ��f
    /// </summary>
    public void statusup()
    {
        //�X�e�[�^�X���f�O�ɐ��l��������
        
            PlayerStatus_Script.add_Player_Attack_Power=0;
        PlayerStatus_Script.add_Player_Defense = 0;
        PlayerStatus_Script.add_Player_Speed = 0;
        PlayerStatus_Script.add_Player_Critical = 0; 
        PlayerStatus_Script.add_Player_Critical_Damage = 0;
        PlayerStatus_Script.add_Player_MaxHealth = 0;
        PlayerStatus_Script.add_Player_MaxSutamina = 0;


            for (int i=1;i<= MAXSETPOSITION;i++)
        {
            //�ݒu����Ă��Ȃ��|�W�V�����Ȃ�X�L�b�v
            if (setSoftVinylData[i].checksetpotion == false) continue;
            //���C���X�e�[�^�X���f
           // Debug.Log(setSoftVinylData[i].Buffparameter);
            switch (setSoftVinylData[i].buffMainstatus)
            {
                case softVinyl.BUFFSTATUSNUM.POWER:
                    PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData[i].Buffparameter;
                    break;
                case softVinyl.BUFFSTATUSNUM.DEFENSE:
                    PlayerStatus_Script.add_Player_Defense += setSoftVinylData[i].Buffparameter;
                    break;
                case softVinyl.BUFFSTATUSNUM.SPEED:
                    PlayerStatus_Script.add_Player_Speed += setSoftVinylData[i].Buffparameter;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICAL:
                    PlayerStatus_Script.add_Player_Critical += setSoftVinylData[i].Buffparameter;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                    PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData[i].Buffparameter;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXHP:
                    PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData[i].Buffparameter;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                    PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData[i].Buffparameter;
                    break;
                default:
                    break;

            }
            //�T�u�P�X�e�[�^�X���f
            switch (setSoftVinylData[i].buffSubstatus1)
            {
                case softVinyl.BUFFSTATUSNUM.POWER:
                    PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData[i].Buffparameter1;
                    break;
                case softVinyl.BUFFSTATUSNUM.DEFENSE:
                    PlayerStatus_Script.add_Player_Defense += setSoftVinylData[i].Buffparameter1;
                    break;
                case softVinyl.BUFFSTATUSNUM.SPEED:
                    PlayerStatus_Script.add_Player_Speed += setSoftVinylData[i].Buffparameter1;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICAL:
                    PlayerStatus_Script.add_Player_Critical += setSoftVinylData[i].Buffparameter1;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                    PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData[i].Buffparameter1;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXHP:
                    PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData[i].Buffparameter1;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                    PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData[i].Buffparameter1;
                    break;
                default:
                    break;

            }
            //�T�u�Q�X�e�[�^�X���f
            switch (setSoftVinylData[i].buffSubstatus2)
            {
                case softVinyl.BUFFSTATUSNUM.POWER:
                    PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData[i].Buffparameter2;
                    break;
                case softVinyl.BUFFSTATUSNUM.DEFENSE:
                    PlayerStatus_Script.add_Player_Defense += setSoftVinylData[i].Buffparameter2;
                    break;
                case softVinyl.BUFFSTATUSNUM.SPEED:
                    PlayerStatus_Script.add_Player_Speed += setSoftVinylData[i].Buffparameter2;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICAL:
                    PlayerStatus_Script.add_Player_Critical += setSoftVinylData[i].Buffparameter2;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                    PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData[i].Buffparameter2;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXHP:
                    PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData[i].Buffparameter2;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                    PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData[i].Buffparameter2;
                    break;
                default:
                    break;

            }
            //�T�u�R�X�e�[�^�X���f
            switch (setSoftVinylData[i].buffSubstatus3)
            {
                case softVinyl.BUFFSTATUSNUM.POWER:
                    PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData[i].Buffparameter3;
                    break;
                case softVinyl.BUFFSTATUSNUM.DEFENSE:
                    PlayerStatus_Script.add_Player_Defense += setSoftVinylData[i].Buffparameter3;
                    break;
                case softVinyl.BUFFSTATUSNUM.SPEED:
                    PlayerStatus_Script.add_Player_Speed += setSoftVinylData[i].Buffparameter3;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICAL:
                    PlayerStatus_Script.add_Player_Critical += setSoftVinylData[i].Buffparameter3;
                    break;
                case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                    PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData[i].Buffparameter3;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXHP:
                    PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData[i].Buffparameter3;
                    break;
                case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                    PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData[i].Buffparameter3;
                    break;
                default:
                    break;
            }
        }
    }
}
