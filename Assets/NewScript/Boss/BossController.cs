using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    private BossState currentState;
    private EnemyStatus_Script bossStatus;
    private BossHealth bossHealth;
    private BossSEBox boss_SE;

    private float boss_Power;
    private float boss_Speed;

    private bool isHit = false;

    // �����`�F�b�N
    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Boss_Power { get => boss_Power; set => boss_Power = value; }
    public BossSEBox Boss_SE { get => boss_SE; set => boss_SE = value; }

    // �v���C���[��ݒ肷��p�̊֐�
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    private void Awake()
    {
        bossHealth = GetComponent<BossHealth>();
        agent = GetComponent<NavMeshAgent>();
        bossStatus = GetComponent<EnemyStatus_Script>();
        boss_SE = GetComponent<BossSEBox>();
    }

    void Start()
    {
        boss_Power = bossStatus.enemy_Attack_Power;
        boss_Speed = bossStatus.enemy_Speed;
        agent.speed = boss_Speed;
        bossHealth.OnDeath += Die;

        //Debug.Log(agent.speed);
        ChangeState(new BossChaseState());
    }

    void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(BossState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public bool IsPlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < 2f;
    }

    /// <summary>
    /// �v���C���[�ɍU�����ꂽ���̏���
    /// </summary>
    /// <param name="_player"></param>
    public void OnHit(PlayerController _player)
    {
        isHit = true;
        //agent.ResetPath();   // �ړ��𑦒�~ ResetPath:��~
        //ChangeState(null);   // ��Ԃ���U�����i�������͐�p��HitState�ɐ؂�ւ��j
        bossHealth.TakeDamage((int)_player.Attack_Power);

        // ��: ��莞�Ԍ�Ɉړ��ĊJ
        //StartCoroutine(RecoverFromHit());
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} �͓|���ꂽ�I");
        if(!(currentState is BossDefeatedState))
        {
            ChangeState(new BossDefeatedState());
        }
    }

}
