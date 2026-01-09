using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    [Header("体力")]
    public float maxHP;
    private float currentHP;
    EnemyStatus_Script enemyStatus_Script;
    BossController bossController;
    private float flashDuration = 0.2f; // 色が変わる時間


    [SerializeField, Header("ダメージエフェクト")] GameObject damageEffect;

    // 死亡イベント（他スクリプトと連携できる）
    public event System.Action OnDeath;

   // [SerializeField] TreasureChestDropScript dropScript;
    public Slider HPSlider;//HPスライダー
    public Text damageTxt;

    private void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        bossController = GetComponent<BossController>();
    }

    private void Start()
    {
        HPSlider.value = 1;
        maxHP = enemyStatus_Script.enemy_MaxHealth;
        currentHP = maxHP;
        damageEffect.SetActive(false);
        damageTxt.text = "";
        Debug.Log(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} は {damage} ダメージを受けた！ 残りHP: {currentHP}");
        damageEffect.SetActive(true);
        HPSlider.value = currentHP / maxHP;
        StartCoroutine(DrawDamage(damage));

        if (currentHP <= 0)
        {
            if (!bossController.IsDie) return;
            bossController.IsDie = true;
            StartCoroutine(JudgeDeath());
        }
    }

    private void Die()
    {
        //Debug.Log($"{gameObject.name} は倒された！");
        OnDeath?.Invoke(); // 死亡イベントを発火（スコア加算やエフェクト再生など）

       // dropScript.Drop();

        //Destroy(gameObject); // 敵オブジェクトを消去
    }

    IEnumerator DrawDamage(int damage)
    {
        damageTxt.text = "" + damage;
        yield return new WaitForSeconds(flashDuration);

        damageTxt.text = "";

    }

    IEnumerator JudgeDeath()
    {
        yield return new WaitForSeconds(flashDuration);
        Die();
    }

}
