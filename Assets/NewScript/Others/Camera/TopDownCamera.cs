using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [Header("追いかける対象(プレイヤー)")]public Transform target; 
    [Header("カメラの位置")]public Vector3 cameraPos = new Vector3(0, 10f, -10f);
    [Header("カメラの追いかける速度")]public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + cameraPos;
        //Lerp:２つのベクトルの間を等速直線運動するような動きになる
        //参考資料:https://nekojara.city/unity-vector3-lerp-slerp
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(target); // プレイヤーを常に注視
    }
}
