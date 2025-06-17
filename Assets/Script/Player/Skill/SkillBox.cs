using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBox : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerAttack_Script playerAttack;

    public enum Skills
    {
        Heal,
        RotateSlash,
    }

    Skills skills;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAttack = player.GetComponent<PlayerAttack_Script>();
    }

    void Update()
    {

    }

    public void SkillSelect(Skills skills)
    {
        switch(skills)
        {
            case Skills.RotateSlash:
                RotateSlashSkill();
                break;
            case Skills.Heal:
                HealSkill();
                break;
        }
    }

    public void RotateSlashSkill()
    {
        float circleRadius = 3;    // �~�̔��a

        // �P��̃R���C�_�[�����o
        // �͈͓��̂��ׂẴR���C�_�[�����o
        Collider2D[] hits = Physics2D.OverlapCircleAll(playerAttack.transform.position, circleRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit != null)
            {
                //�q�b�g�����ΏۂɃ_���[�W��^����
                //�q�b�g�����I�u�W�F�N�g���G�̏ꍇ�A����̃X�N���v�g�������Ă���ƃ_���[�W��^����
                EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    //enemy.TakeDamageKnockBack(playerAttack.normalDamage, playerAttack.shouldknockBackFlf);
                }
            }
        }
    }

    public void HealSkill()
    {
        playerHealth.RecoveryDamage(100);
    }
}
