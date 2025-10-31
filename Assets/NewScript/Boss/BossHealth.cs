using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("体力")]
    public float maxHP;
    private float currentHP;
    EnemyStatus_Script enemyStatus_Script;
    BossController bossController;

    [SerializeField, Header("ダメージエフェクト")] GameObject damageEffect;

    // 死亡イベント（他スクリプトと連携できる）
    public event System.Action OnDeath;

    [SerializeField] TreasureChestDropScript dropScript;

    private void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        bossController = GetComponent<BossController>();
    }

    private void Start()
    {
        maxHP = enemyStatus_Script.enemy_MaxHealth;
        currentHP = maxHP;
        damageEffect.SetActive(false);
        Debug.Log(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} は {damage} ダメージを受けた！ 残りHP: {currentHP}");
        damageEffect.SetActive(true);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Debug.Log($"{gameObject.name} は倒された！");
        OnDeath?.Invoke(); // 死亡イベントを発火（スコア加算やエフェクト再生など）

        dropScript.Drop();

        //Destroy(gameObject); // 敵オブジェクトを消去
    }
}
