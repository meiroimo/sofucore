using System.Collections;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [Header("スポーン設定")]
    public GameObject[] fallingPrefabs;

    [Header("スポーン範囲（画面外）")]
    public float spawnY = 8f;
    public float spawnXMin = -8f;
    public float spawnXMax = 8f;

    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 1.2f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Spawn();

            float wait = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(wait);
        }
    }

    void Spawn()
    {
        if (fallingPrefabs == null || fallingPrefabs.Length == 0) return;

        // ランダムPrefab選択
        GameObject prefab =
            fallingPrefabs[Random.Range(0, fallingPrefabs.Length)];

        Vector3 pos = new Vector3(
            Random.Range(spawnXMin, spawnXMax),
            spawnY,
            Random.Range(-2f, 2f)
        );

        Instantiate(prefab, pos, Random.rotation);
    }
}
