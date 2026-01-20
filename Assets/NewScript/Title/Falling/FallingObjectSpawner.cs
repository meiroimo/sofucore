using System.Collections;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [Header("スポーン設定")]
    public GameObject fallingPrefab;

    public float spawnInterval = 1.0f;

    [Header("スポーン範囲（画面外）")]
    public float spawnY = 6f;
    public float spawnXMin = -4f;
    public float spawnXMax = 4f;

    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 1.5f;

    IEnumerator Start()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(
                Random.Range(spawnIntervalMin, spawnIntervalMax)
            );
        }
    }
    void Spawn()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnXMin, spawnXMax),
            spawnY,
            0f
        );

        Instantiate(fallingPrefab, spawnPos, Random.rotation);
    }
}
