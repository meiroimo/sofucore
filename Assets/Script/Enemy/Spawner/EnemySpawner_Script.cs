using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Script : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpown;
    private float spownCounter;

    public Transform minSpawn, maxSpawn;

    private Transform target;

    private GameObject player;

    private float despawnDistance;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public int checkPerFrame;
    private int enemyToCheck;

    public bool spawnFlg;

    void Start()
    {
        spownCounter = timeToSpown;

        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            target = player.GetComponent<Transform>();
        }

        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;

    }

    void Update()
    {
        EnemySpown();
        transform.position = target.position;

        int checkTarget = enemyToCheck + checkPerFrame;

        while(enemyToCheck < checkTarget)
        {
            if(enemyToCheck < spawnedEnemies.Count)
            {
                if (spawnedEnemies[enemyToCheck] != null)
                {
                    if(Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance)
                    {
                        Destroy(spawnedEnemies[enemyToCheck]);

                        spawnedEnemies.RemoveAt(enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }

    public void EnemySpown()
    {
        spownCounter -= Time.deltaTime;
        if (spownCounter <= 0 && spawnFlg)
        {
            spownCounter = timeToSpown;

            GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);

            spawnedEnemies.Add(newEnemy);
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if(Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if(Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = maxSpawn.position.y;
            }
        }

        return spawnPoint;
    }
}
