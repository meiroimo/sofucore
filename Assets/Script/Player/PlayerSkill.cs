using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    private FlowerGuard2 testInputAction;//inputSystem
    private SkillFactory.SkillKind selectedSkillKind_test;
    public SkillBox skillBox;

    //�X�L���̍Ĕ�������
    public int[] maxSkill = new int[3];
    private float[] currentSkill = new float[3];

    // �X���C�_�[�̎Q��
    public Slider[] skillSlider = new Slider[3];

    AbstractSkill[] skill = new AbstractSkill[3];

    SkillBox.Skills[] skills = new SkillBox.Skills[3];

    void Start()
    {
        testInputAction = new FlowerGuard2();
        testInputAction.Enable();

        // �����ݒ�
        for(int i = 0;i < skillSlider.Length;i++)
        {
            currentSkill[i] = maxSkill[i]; // Skill���ő�l�ɐݒ�
            skillSlider[i].maxValue = maxSkill[i]; // �X���C�_�[�̍ő�l��ݒ�
            skillSlider[i].value = currentSkill[i]; // ���݂�Skill�𔽉f
        }
    }

    void Update()
    {
        SkillSelect();
        for(int i = 0;i < maxSkill.Length;i++)
        {
            SkillCoolDown(i);
        }
    }

    /// <summary>
    /// �{�^���������ꂽ���̊֐�
    /// </summary>
    public void SkillSelect()
    {
        if (testInputAction.Player.Skill1.triggered && currentSkill[0] == maxSkill[0])
        {
            skills[0] = SkillBox.Skills.Heal;
            skillBox.SkillSelect(skills[0]);
            //var skillFactory = new SkillFactory();
            //skill[0] = skillFactory.Create(this.selectedSkillKind_test);
            //if (skill[0] != null) skill[0].Play();
            currentSkill[0] = 0;
            skillSlider[0].value = currentSkill[0]; // ���݂�Skill�𔽉f
        }
        if (testInputAction.Player.Skill2.triggered && currentSkill[1] == maxSkill[1])
        {
            skills[1] = SkillBox.Skills.RotateSlash;
            skillBox.SkillSelect(skills[1]);
            currentSkill[1] = 0;
            skillSlider[1].value = currentSkill[1]; // ���݂�Skill�𔽉f
        }
        if (testInputAction.Player.Skill3.triggered && currentSkill[2] == maxSkill[2])
        {
            currentSkill[2] = 0;
            skillSlider[2].value = currentSkill[2]; // ���݂�Skill�𔽉f
        }

        //�X�L���؂�ւ��e�X�g
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("�X�L��1���uRotateSlash�v�ɕύX���܂����B");
            this.selectedSkillKind_test = SkillFactory.SkillKind.RotateSlash;
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("�X�L��1���uHeal�v�ɕύX���܂����B");
            this.selectedSkillKind_test = SkillFactory.SkillKind.Heal;
        }
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    var skillFactory = new SkillFactory();
        //    var skill = skillFactory.Create(this.selectedSkillKind_test);
        //    skill.Play();
        //}
    }

    /// <summary>
    /// �X�L���̃N�[���_�E��
    /// </summary>
    public void SkillCoolDown(int skillNum)
    {
        if (currentSkill[skillNum] < maxSkill[skillNum])
        {
            currentSkill[skillNum] += 1 * Time.deltaTime;
            skillSlider[skillNum].value = currentSkill[skillNum]; // ���݂�Skill�𔽉f
        }
        else if (currentSkill[skillNum] >= maxSkill[skillNum])
        {
            currentSkill[skillNum] = maxSkill[skillNum]; // Skill���ő�l�ɐݒ�
            skillSlider[skillNum].value = currentSkill[skillNum]; // ���݂�Skill�𔽉f
        }
    }

}
