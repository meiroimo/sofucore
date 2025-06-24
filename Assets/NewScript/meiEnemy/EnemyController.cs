using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    private EnemyState currentState;
    private EnemyStatus_Script enemyStatus;
    private EnemyHealth enemyHealth;

    private float enemy_Power;

    private bool isHit = false;
    public event System.Action OnDeath; // ���S�C�x���g

    // �����`�F�b�N
    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Enemy_Power { get => enemy_Power; set => enemy_Power = value; }

    // �v���C���[��ݒ肷��p�̊֐�
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
        enemyStatus = GetComponent<EnemyStatus_Script>();
        enemy_Power = enemyStatus.enemy_Attack_Power;
        ChangeState(new ChaseState());
    }

    void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public bool IsPlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < 2f;
    }

    public void OnHit(PlayerController _player)
    {
        isHit = true;
        agent.ResetPath();   // �ړ��𑦒�~ ResetPath:��~
        ChangeState(null);   // ��Ԃ���U�����i�������͐�p��HitState�ɐ؂�ւ��j
        enemyHealth.EnemtTakeDamage((int)_player.Attack_Power);

        // ��: ��莞�Ԍ�Ɉړ��ĊJ
        StartCoroutine(RecoverFromHit());
    }

    private IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(1.0f); // 1�b�d��
        isHit = false;
        ChangeState(new ChaseState()); // �d����ɒǐՍĊJ
    }

    public void Die()
    {
        Debug.Log("�G������");

        // �C�x���g�ʒm�F�o�^����Ă���ΌĂяo��
        OnDeath?.Invoke();

        Destroy(gameObject);
    }
}
