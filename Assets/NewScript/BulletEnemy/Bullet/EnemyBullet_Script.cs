using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Script : MonoBehaviour
{
    [Header("弾の速度")]
    public float speed;

    //プレイヤーの方向
    private Vector3 direction;

    /// <summary>
    /// プレイヤーの方向を取得する
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {
        Debug.Log("弾生成完了！");
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
