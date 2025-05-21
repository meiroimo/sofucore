using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
#endif
    }
}
