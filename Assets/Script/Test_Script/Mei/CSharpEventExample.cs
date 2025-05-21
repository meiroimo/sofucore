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

        //デリゲート登録
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        if (_playerInput == null) return;

        //デリゲート登録解除
        _playerInput.onActionTriggered -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        //Move以外は処理しない
        if (context.action.name != "Move") return;

        //MoveActionの入力値を取得
        var axis = context.ReadValue<Vector2>();

        //移動速度を保持
        _velocity = new Vector3(axis.x, 0, axis.y);
    }

    private void Update()
    {
        //オブジェクト移動
        transform.position += _velocity * Time.deltaTime;
    }
}
