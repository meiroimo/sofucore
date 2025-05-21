using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private EnemyStatus_Script _enemy_status;
    private EnemyMovement enemyMovement;
    private PlayerStatus_Script _status;

    public int maxHealth_Enemy;
    private int health_Enemy;
    public bool debugFlg;
    [HideInInspector] public bool criticalFlg;
    private float switchCriticalColors;

    public Slider slider;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _status = player.GetComponent<PlayerStatus_Script>();
        _enemy_status = GetComponent<EnemyStatus_Script>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    private void Start()
    {
        criticalFlg = false;
        health_Enemy = maxHealth_Enemy;
        slider.maxValue = maxHealth_Enemy;
        slider.value = maxHealth_Enemy;
    }

    public void TakeDamage(float damagToTake)
    {
        //「Random.value」意味:0〜1.0までの浮動小数点(float)を得る
        if (Random.value * 100 <= _status.player_Critical)
        {
            criticalFlg = true;
            damagToTake = damagToTake * (1 + (_status.player_Critical_Damage * 0.01f));
        }
        damagToTake = (damagToTake * 0.5f) - (_enemy_status.enemy_Defense * 0.25f);
        if (damagToTake <= 0) damagToTake = Random.Range(1, 2);
        health_Enemy -= (int)damagToTake;
        slider.value = health_Enemy;
        StartCoroutine(DamegeColor());
        if (health_Enemy <= 0)//敵が死んだら
        {
            Debug.Log("キル!");
            if(debugFlg)
            {
                StartCoroutine(DebugRecovery());
            }
            else
            {
                _status.enemyDeathCount++;
                Destroy(gameObject);
            }
        }

        if(criticalFlg)
        {
            switchCriticalColors = 0;
        }
        else
        {
            switchCriticalColors = 1;
        }

        DamageNumberController.instance.SpawnDamage(damagToTake, transform.position, switchCriticalColors);
        criticalFlg = false;
    }

    public void TakeDamageKnockBack(float damageToTake, bool shouldknockBack)
    {
        TakeDamage(damageToTake);

        if (shouldknockBack)
        {
            float knockBackTime = 0.5f;
            enemyMovement.KnockBackCounter = knockBackTime;
        }
    }

    IEnumerator DamegeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().material.color = Color.white;
    }

    IEnumerator DebugRecovery()
    {
        yield return new WaitForSeconds(1);

        while(health_Enemy <= maxHealth_Enemy)
        {
            health_Enemy += 1;
            slider.value = health_Enemy;
            yield return null;
            if (health_Enemy <= maxHealth_Enemy)
            {
                health_Enemy = maxHealth_Enemy;
                slider.value = health_Enemy;
            }
        }
    }
}
