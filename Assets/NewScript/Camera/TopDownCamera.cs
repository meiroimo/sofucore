using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;          // �Ǐ]�Ώہi�v���C���[�j
    public Vector3 offset = new Vector3(0, 10f, -10f); // ���Վ��_�̈ʒu
    public float followSpeed = 5f;    // �Ǐ]�̊��炩��

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(target); // �v���C���[����ɒ���
    }
}
