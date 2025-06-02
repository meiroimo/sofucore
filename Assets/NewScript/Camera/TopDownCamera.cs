using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [Header("�ǂ�������Ώ�(�v���C���[)")]public Transform target; 
    [Header("�J�����̈ʒu")]public Vector3 cameraPos = new Vector3(0, 10f, -10f);
    [Header("�J�����̒ǂ������鑬�x")]public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + cameraPos;
        //Lerp:�Q�̃x�N�g���̊Ԃ𓙑������^������悤�ȓ����ɂȂ�
        //�Q�l����:https://nekojara.city/unity-vector3-lerp-slerp
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(target); // �v���C���[����ɒ���
    }
}
