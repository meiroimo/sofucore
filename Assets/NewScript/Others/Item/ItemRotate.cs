using UnityEngine;

/// <summary>
/// アイテムを回転させるスクリプト
/// </summary>
public class ItemRotate : MonoBehaviour
{
    [Header("回転速度（度/秒）")]
    [SerializeField] private float rotateSpeed = 90f;

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}
