using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp_Script : MonoBehaviour
{
    public EnemySpawner_Script spawner;

    void Start()
    {
        spawner.spawnFlg = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(0, -33, 0);
            spawner.spawnFlg = true;
        }
    }
}
