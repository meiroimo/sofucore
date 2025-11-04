using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Script : MonoBehaviour
{
    [Header("弾の速度")]
    public float speed;

    //プレイヤーの方向

    private Vector3 direction;

    BulletEnemyController bulletEnemy;

    /// プレイヤーの方向を取得する
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    public void SetBulletEnemy(BulletEnemyController bulletEnemyCon)
    {
        bulletEnemy = bulletEnemyCon.GetComponent<BulletEnemyController>();
    }

    private void Start()
    {
        Debug.Log("弾生成完了！");
        //Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.gameObject.GetComponentInChildren<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage((int)bulletEnemy.Enemy_Power);
            }

            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        //    if(playerController != null)
        //    {
        //        playerController.TakeDamage((int)bulletEnemy.Enemy_Power);
        //    }

        //    Destroy(this.gameObject);
        //}
    }
}
