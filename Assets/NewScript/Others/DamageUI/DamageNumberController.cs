using System.Collections.Generic;
using UnityEngine;

//ä«óùë§
public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController Instance { get; private set; }

    public DamageNumber prefab;
    public Transform canvasRoot;

    private readonly List<DamageNumber> pool = new();

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnDamage(float damage, Vector3 worldPos, Color color)
    {
        int rounded = Mathf.RoundToInt(damage);

        DamageNumber number = GetFromPool();
        number.transform.position = worldPos;
        number.gameObject.SetActive(true);
        number.Setup(rounded, color);
    }

    private DamageNumber GetFromPool()
    {
        if (pool.Count > 0)
        {
            var n = pool[0];
            pool.RemoveAt(0);
            return n;
        }

        return Instantiate(prefab, canvasRoot);
    }

    public void PlaceInPool(DamageNumber number)
    {
        number.gameObject.SetActive(false);
        pool.Add(number);
    }
}
