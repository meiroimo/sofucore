using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeResultScene_Script : MonoBehaviour
{
    private BossHealth bossHealth;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBossHealth(GameObject boss)
    {
        bossHealth = boss.GetComponent<BossHealth>();
    }
}
