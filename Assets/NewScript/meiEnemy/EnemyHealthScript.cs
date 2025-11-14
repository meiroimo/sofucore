using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    [Header("体力")]
    public float maxHP;
    private float currentHP;
    EnemyStatus_Script enemyStatus_Script;
    EnemyHitReaction hitReaction;

    public Renderer enemyRenderer; // 敵の見た目
    private Color hitColor = Color.black; // 被弾時の色
    private float flashDuration = 0.2f; // 色が変わる時間
    private Color originalColor;
    private Material enemyMaterial;

    // 死亡イベント（他スクリプトと連携できる）
    public event System.Action OnDeath;

    [SerializeField] TreasureChestDropScript dropScript;

    [SerializeField, Header("ダメージエフェクト")] GameObject damageEffect;
    public Slider HPSlider;//HPスライダー
    public Text damageTxt;


    //20250621 kome変更点
    sofviStrage sofviStrageScript;//ストレージスクリプト
    public softVinyl softVinyldata;//ドロップするソフビデータ
    private void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        hitReaction = GetComponent<EnemyHitReaction>();
        if (enemyRenderer != null)
        {
            // マテリアルを個別インスタンスに
            enemyMaterial = enemyRenderer.material;
            originalColor = enemyMaterial.color;
        }
        
    }

    private void Start()
    {
        sofviStrageScript = GameObject.Find("Player_Storage").gameObject.GetComponent<sofviStrage>();
        softVinyldata = gameObject.transform.GetChild(0).gameObject.GetComponent<softVinyl>();
        maxHP = enemyStatus_Script.enemy_MaxHealth + 10;
        currentHP = maxHP;
        damageEffect.SetActive(false);
        //Debug.Log(currentHP);
        HPSlider.value = 1;
        damageTxt.text = "";
    }

    public void EnemtTakeDamage(int damage)
    {
        
        currentHP -= damage;

        damageEffect.SetActive(true);
        Debug.Log($"{gameObject.name} は {damage} ダメージを受けた！ 残りHP: {currentHP}");
        HPSlider.value = currentHP / maxHP;
        StartCoroutine(DrawDamage(damage));
        //hitReaction.PlayHitReaction();
        StartCoroutine(FlashColor());

        if (currentHP <= 0)
        {
            StartCoroutine(JudgeDeath());
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} は倒された！");
        OnDeath?.Invoke(); // 死亡イベントを発火（スコア加算やエフェクト再生など）

        //rena追加
        dropScript.Drop();

        //kome変更点

        //sofviStrageScript.addSofvi(softVinyldata);

        Destroy(gameObject); // 敵オブジェクトを消去

    }

    /// <summary>
    /// 一瞬だけ色を変えて戻す
    /// </summary>
    IEnumerator FlashColor()
    {
        enemyMaterial.color = hitColor;
        yield return new WaitForSeconds(flashDuration);
        enemyMaterial.color = originalColor;

    }

    IEnumerator　DrawDamage(int damage)
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
