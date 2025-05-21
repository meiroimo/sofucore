using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class CSharpEventExample : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Vector3 _velocity;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if (_playerInput == null) return;

        //�f���Q�[�g�o�^
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        if (_playerInput == null) return;

        //�f���Q�[�g�o�^����
        _playerInput.onActionTriggered -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        //Move�ȊO�͏������Ȃ�
        if (context.action.name != "Move") return;

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
