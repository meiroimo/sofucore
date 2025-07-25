using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [Header("体力")]
    public float maxHP;
    private float currentHP;
    EnemyStatus_Script enemyStatus_Script;

    // 死亡イベント（他スクリプトと連携できる）
    public event System.Action OnDeath;

    [SerializeField] TreasureChestDropScript dropScript;


    //20250621 kome変更点
    sofviStrage sofviStrageScript;//ストレージスクリプト
    public softVinyl softVinyldata;//ドロップするソフビデータ
    private void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
    }

    private void Start()
    {
        sofviStrageScript = GameObject.Find("Storage").gameObject.GetComponent<sofviStrage>();
        softVinyldata = gameObject.transform.GetChild(0).gameObject.GetComponent<softVinyl>();
        maxHP = enemyStatus_Script.enemy_MaxHealth;
        currentHP = maxHP;
        Debug.Log(currentHP);
    }

    public void EnemtTakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} は {damage} ダメージを受けた！ 残りHP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} は倒された！");
        OnDeath?.Invoke(); // 死亡イベントを発火（スコア加算やエフェクト再生など）

        //rena追加
        dropScript.Drop();

        //kome変更点

        sofviStrageScript.addSofvi(softVinyldata);

        Destroy(gameObject); // 敵オブジェクトを消去

    }
}
