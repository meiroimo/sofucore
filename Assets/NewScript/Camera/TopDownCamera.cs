using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;          // 追従対象（プレイヤー）
    public Vector3 offset = new Vector3(0, 10f, -10f); // 俯瞰視点の位置
    public float followSpeed = 5f;    // 追従の滑らかさ

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(target); // プレイヤーを常に注視
    }
}
