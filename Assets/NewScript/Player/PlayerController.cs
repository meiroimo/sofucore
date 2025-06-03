using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float rotationSpeed = 10f;

    public Camera mainCamera;
    public LayerMask enemyLayer;
    public float attackRange = 100f;

    private FlowerGuard2 inputActions;
    private PlayerState currentState;

    public Vector2 MoveInput { get; private set; }
    public Rigidbody Rigid { get; private set; }

    private void Awake()
    {
        inputActions = new FlowerGuard2();
        Rigid = GetComponent<Rigidbody>();

        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
        inputActions.Player.Avoid.performed += ctx => OnAvoid();
        inputActions.Player.NomalAttack.performed += cxt => OnLightAttack();
    }

    //Enable : GameObject が有効になったとき
    //         入力処理（Input System）を有効にする
    private void OnEnable() => inputActions.Enable();

    //Disable : GameObject が無効になったとき
    //         入力処理を無効にしてリソースを解放する
    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        ChangeState(new PlayerIdleState(this));
    }

    private void Update()
    {
        currentState?.Update();
    }

    //状態変更のための関数
    public void ChangeState(PlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void RotateTowards(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return; // 入力が小さいときは回転しない

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
        //if (CanDodge()) // 任意：クールタイム等
        {
            ChangeState(new PlayerAvoidState(this));
        }
    }

    public void OnLightAttack()
    {
        ChangeState(new PlayerLightAttackState(this));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f); // 半径に合わせて調整

        Vector3 left = Quaternion.Euler(0, -30f, 0) * transform.forward;
        Vector3 right = Quaternion.Euler(0, 30f, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, left * 5f);
        Gizmos.DrawRay(transform.position, right * 5f);
    }
}
