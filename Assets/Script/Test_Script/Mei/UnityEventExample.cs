using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityEventExample : MonoBehaviour
{
    private Vector3 _velocity;

    //���\�b�h���͉��ł�OK
    //public�ɂ���K�v������
    public void OnMove(InputAction.CallbackContext context)
    {
        //MoveAction�̓��͒l���擾
        var axis = context.ReadValue<Vector2>();

        //�ړ����x��ێ�
        _velocity = new Vector3(axis.x, 0, axis.y);
    }

    private void Update()
    {
        //�I�u�W�F�N�g�ړ�
        transform.position += _velocity * Time.deltaTime;
    }
}
