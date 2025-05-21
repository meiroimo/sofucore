using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampMouseCursor_Script : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector2(
           //�ړ��͈͂𐧌�����
           Mathf.Clamp(transform.position.x, 0, 1280f - 32f),
           Mathf.Clamp(transform.position.y, 0 + 32, 720f)
           );
    }
}
