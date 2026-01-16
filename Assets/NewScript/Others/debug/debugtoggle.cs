using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugtoggle : MonoBehaviour
{
    // Start is called before the first frame update
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
            EnemySpawnerSc.isDropRate_max=true;
            Debug.Log($"ドロップ率最大ON");
        }
        else
        {
            EnemySpawnerSc.isDropRate_max = false;
            Debug.Log($"ドロップ率最大OFF");
        }
    }
}
