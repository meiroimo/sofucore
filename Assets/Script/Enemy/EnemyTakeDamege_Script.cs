using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTakeDamege_Script : MonoBehaviour
{
    private EnemyStatus_Script _enemy_status;

    public float hitWaitTime = 1f;//+攻撃のクールタイム
    private float hitCounter;

    private void Awake()
    {
        _enemy_status = GetComponent<EnemyStatus_Script>();
    }

    private void FixedUpdate()
    {
        if (hitCounter < hitWaitTime)
        {
            hitCounter += Time.deltaTime;
        }
    }

    //public void OnCollisionStay2D(Collision2D collision)
    //{
    //    var player = collision.gameObject.GetComponent<PlayerHealth>();

    //    if (hitCounter > hitWaitTime)
    //    {
    //        if (player)
    //        {
    //            player.EnemtTakeDamage(100);

    //            hitCounter = 0;
    //        }

    //    }

    //    //if (collision.tag == "OutArea")
    //    //{
    //    //    Destroy(gameObject);
    //    //}
    //}

    /// <summary>
    /// 主人公に触れるとダメージを与える
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerHealth>();

        if (hitCounter > hitWaitTime)
        {
            if (player)
            {
                player.TakeDamage((int)_enemy_status.enemy_Attack_Power);

                hitCounter = 0;
            }

        }


    }
}
