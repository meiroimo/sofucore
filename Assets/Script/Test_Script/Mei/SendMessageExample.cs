using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SendMessageExample : MonoBehaviour
{
    private Vector3 _velocity;

    //�ʒm���󂯎�郁�\�b�h���́uOn + Action���v�ł���K�v������
    private void OnMove(InputValue value)
    {
        //MoveAction�̓��͒l���擾
        var axis = value.Get<Vector2>();

        //�ړ����x��ێ�
        _velocity = new Vector3(axis.x, 0, axis.y);
    }

    private void Update()
    {
        //�I�u�W�F�N�g�ړ�
        transform.position += _velocity * Time.deltaTime;
    }
}
