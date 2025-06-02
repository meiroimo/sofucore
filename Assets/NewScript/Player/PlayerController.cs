using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float rotationSpeed = 10f;

    private FlowerGuard2 inputActions;
    private PlayerState currentState;

    public Vector2 MoveInput { get; private set; }
    public Rigidbody Rigid { get; private set; }
    public Transform trans { get; private set; }

    private void Awake()
    {
        inputActions = new FlowerGuard2();
        Rigid = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();

        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
        inputActions.Player.Avoid.performed += ctx => OnAvoid();
    }

    //Enable : GameObject ���L���ɂȂ����Ƃ�
    //         ���͏����iInput System�j��L���ɂ���
    private void OnEnable() => inputActions.Enable();

    //Disable : GameObject �������ɂȂ����Ƃ�
    //         ���͏����𖳌��ɂ��ă��\�[�X���������
    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        ChangeState(new PlayerIdleState(this));
    }

    private void Update()
    {
        currentState?.Update();
    }

    //��ԕύX�̂��߂̊֐�
    public void ChangeState(PlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void RotateTowards(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return; // ���͂��������Ƃ��͉�]���Ȃ�

        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void MoveInDirection(Vector3 direction, float speed)
    {
        Rigid.velocity = direction.normalized * speed;
    }

    public void MoveInstant(Vector2 velocity)
    {
        Rigid.velocity = velocity;
    }

    public float FacingDirection => transform.localScale.x;

    private bool isInvincible = false;

    public void OnAvoid()
    {
        //if (CanDodge()) // �C�ӁF�N�[���^�C����
        {
            ChangeState(new PlayerAvoidState(this));
        }
    }
}
