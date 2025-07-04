using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkillSlider : MonoBehaviour
{
    [SerializeField, Header("skill�X���C�_�[")] Slider skillSlider;
    PlayerStatus_Script playerStatus_Script;
    PlayerSEBox seBox;

    float maxSkillPoint;    //���܂�X�L���|�C���g
    float nowSkillPoint;    //���݂̃X�L���|�C���g
    float skillChargePoint; //1�b�Ԃɂ��܂�X�L���|�C���g�̗�

    bool isSkillCharge;//�`���[�W���邩 true:�`���[�W���� false:�`���[�W���Ȃ�

    float nowTime;


    public void Init()
    {
        Application.targetFrameRate = 30;

        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        seBox = GetComponent<PlayerSEBox>();

        maxSkillPoint = playerStatus_Script.D_player_Skill_Point;
        nowSkillPoint = maxSkillPoint;
        skillChargePoint = playerStatus_Script.D_player_Skill_Charge;

        isSkillCharge = false;
        //InvokeRepeating("���\�b�h��", �J�n�܂ł̒x������, �J��Ԃ��Ԋu);
        //InvokeRepeating(nameof(skillPointUICharge), 1.0f, 1.0f);

    }

    void Update()
    {
        if (!isSkillCharge) return;
        skillPointUICharge();
    }

    //�`���[�W����
    void skillPointUICharge()
    {
        nowSkillPoint += skillChargePoint / Application.targetFrameRate;

        skillSet();

        if (isUseSkill())
        {
            isSkillCharge = false;
            seBox.PlayPlayerSE(PlayerSEBox.SENAME.CHARGE);
        }
    }

        //UI�ɔ��f
        void skillSet()
    {
        float nowValue = nowSkillPoint / maxSkillPoint;


        skillSlider.value = nowValue;

    }

    //�X�L�����g���邩
    public bool isUseSkill()
    {
        if (nowSkillPoint >= maxSkillPoint) return true;
        else return false;
    }

    //�g������0������
    public void setNowPoint(float h_nowSkillPoint)
    {
        nowSkillPoint = h_nowSkillPoint;
        if (nowSkillPoint < maxSkillPoint) isSkillCharge = true;
        skillSet();
    }

    //�Q�b�^�[���݂̃|�C���g��Ԃ�
    public float getNowSkillPoint()
    {
        return nowSkillPoint;
    }

}
