using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    public GameObject clearText;

    private void Start()
    {
        clearText.SetActive(false);
    }

    private void Update()
    {
        if(ResultClear.Instance.isGameClear)
        {
            clearText.SetActive(true);
            if(Input.GetKey(KeyCode.L))
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
