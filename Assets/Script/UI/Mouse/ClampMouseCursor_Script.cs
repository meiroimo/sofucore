using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampMouseCursor_Script : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector2(
           //移動範囲を制限する
           Mathf.Clamp(transform.position.x, 0, 1280f - 32f),
           Mathf.Clamp(transform.position.y, 0 + 32, 720f)
           );
    }
}
