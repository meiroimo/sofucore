using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugtoggle_radio : MonoBehaviour
{
    private Toggle toggle;
    public EnemySpawner EnemySpawnerSc;//ドロップを制御するスクリプト

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(Change);
    }

    /// <summary>
    /// OnValueChangedに追加するメソッド
    /// </summary>
    /// <param name="isOn">Toggleの状態</param>
    public void Change(bool isOn)
    {
        if (isOn)
        {
            //ON
            if(toggle.name== "isNomalDorpOnly")
            {
                EnemySpawnerSc.isNomalDropRate_max = true;
                Debug.Log($"ON: {toggle.name}");
            }
            if (toggle.name == "isRareDorpOnly")
            {
                EnemySpawnerSc.isRareDropRate_max = true;
                Debug.Log($"ON: {toggle.name}");
            }
            if (toggle.name == "isSuperRareDorpOnly")
            {
                EnemySpawnerSc.isSuparRareDropRate_max = true;
                Debug.Log($"ON: {toggle.name}");
            }
            if (toggle.name == "nomaldrop")
            {
                EnemySpawnerSc.isSuparRareDropRate_max = false;
                EnemySpawnerSc.isRareDropRate_max = false;
                EnemySpawnerSc.isNomalDropRate_max = false;
                Debug.Log($"ON: {toggle.name}");
            }


        }
        else
        {
            if (toggle.name == "isNomalDorpOnly")
            {
                EnemySpawnerSc.isNomalDropRate_max = false;
                //OFF
                Debug.Log($"OFF: {toggle.name}");
            }
            if (toggle.name == "isRareDorpOnly")
            {
                EnemySpawnerSc.isRareDropRate_max = false;
                //OFF
                Debug.Log($"OFF: {toggle.name}");
            }
            if (toggle.name == "isSuperRareDorpOnly")
            {
                EnemySpawnerSc.isSuparRareDropRate_max = false;
                //OFF
                Debug.Log($"OFF: {toggle.name}");
            }

        }
    }
}
