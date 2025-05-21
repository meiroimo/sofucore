using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    private void Awake()
    {
        instance = this;
    }

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamageNumber> numberPool = new List<DamageNumber>();

    public void SpawnDamage(float damageAmonut, Vector3 location, float cr)
    {
        int rounded = Mathf.RoundToInt(damageAmonut);

        //DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);

        DamageNumber newDamage = GetFromPool();

        newDamage.SetUp(rounded, cr); 
        newDamage.gameObject.SetActive(true);

        newDamage.transform.position = location;
    }

    //敵に与えたダメージ表記
    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutput = null;

        if (numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }
        else
        {
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }

        return numberToOutput;
    }


    //与えたダメージ表記
    public void PlaceInPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);
        //criticalFlg = false;
        numberPool.Add(numberToPlace);
    }


}
