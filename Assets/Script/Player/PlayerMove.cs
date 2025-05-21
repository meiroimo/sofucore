using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerMove : MonoBehaviour
{
    private PlayerStatus_Script _status;
    private Rigidbody2D theRigidbody;
    private Vector2 moveInput;
    [Header("移動速度")]public float speed;

    public Vector2 MoveInput { get => moveInput; set => moveInput = value; }

    private void Awake()
    {
        _status = GetComponent<PlayerStatus_Script>();
        theRigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        speed = _status.player_Speed;
    }

    void Update()
    {
        _Move();
    }

    //通知を受け取るメソッド名は「On + Action名」である必要がある
    public void OnMove(InputAction.CallbackContext context)
    {
        //MoveActionの入力値を取得
        moveInput = context.ReadValue<Vector2>();
    }

    private void _Move()
    {
        theRigidbody.velocity = moveInput * speed;//プレイヤーの速度に移動入力を反映
    }


}
