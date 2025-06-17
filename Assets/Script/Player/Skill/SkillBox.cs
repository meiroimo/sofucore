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
        float circleRadius = 3;    // 円の半径

        // 単一のコライダーを検出
        // 範囲内のすべてのコライダーを検出
        Collider2D[] hits = Physics2D.OverlapCircleAll(playerAttack.transform.position, circleRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit != null)
            {
                //ヒットした対象にダメージを与える
                //ヒットしたオブジェクトが敵の場合、特定のスクリプトを持っているとダメージを与える
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
