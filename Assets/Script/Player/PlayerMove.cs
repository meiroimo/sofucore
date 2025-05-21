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
    [Header("�ړ����x")]public float speed;

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

    //�ʒm���󂯎�郁�\�b�h���́uOn + Action���v�ł���K�v������
    public void OnMove(InputAction.CallbackContext context)
    {
        //MoveAction�̓��͒l���擾
        moveInput = context.ReadValue<Vector2>();
    }

    private void _Move()
    {
        theRigidbody.velocity = moveInput * speed;//�v���C���[�̑��x�Ɉړ����͂𔽉f
    }


}
