using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStatus_Script _enemy_status;

    public Rigidbody2D theRigidbody;
    private float moveSpeed;
    private float saveSpeed;
    private float knockBackCounter;
    private Transform target;

    public float KnockBackCounter { get => knockBackCounter; set => knockBackCounter = value; }

    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
        _enemy_status = GetComponent<EnemyStatus_Script>();

        //敵のスピード
        moveSpeed = Random.Range(_enemy_status.enemy_Speed * 0.7f, _enemy_status.enemy_Speed * 1.4f);
        saveSpeed = moveSpeed;
    }

    void Update()
    {
        EnemyMove();
        knockBack();
    }

    void EnemyMove()
    {
        //プレイヤーとのベクトルを求めてその方向に移動する
        theRigidbody.velocity = (target.position - transform.position).normalized * moveSpeed;
    }

    public void knockBack()
    {
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if (moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 0.5f;
            }

            if (knockBackCounter <= 0)
            {
                GetComponent<Renderer>().material.color = Color.white;
                moveSpeed = saveSpeed;
            }
        }
    }

}
