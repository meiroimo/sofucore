using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultClear : MonoBehaviour
{
    public static ResultClear Instance;

    public bool isGameClear = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
