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
    private EnemyHealthScript enemyHealth;
    private EnemySEBox enemy_SE;

    private float enemy_Power;
    private float enemy_Speed;

    private bool isHit = false;
    public event System.Action OnDeath; //���S�C�x���g

    //�����`�F�b�N
    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Enemy_Power { get => enemy_Power; set => enemy_Power = value; }
    public EnemySEBox Enemy_SE { get => enemy_SE; set => enemy_SE = value; }

    //�v���C���[��ݒ肷��p�̊֐�
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    void Start()
    {
        //GetComponent
        #region
        enemyHealth = GetComponent<EnemyHealthScript>();
        agent = GetComponent<NavMeshAgent>();
        enemyStatus = GetComponent<EnemyStatus_Script>();
        enemy_SE = GetComponent<EnemySEBox>();
        #endregion

        //������
        #region
        enemy_Power = enemyStatus.enemy_Attack_Power;
        enemy_Speed = enemyStatus.enemy_Speed;
        agent.speed = enemy_Speed;
        #endregion

        ChangeState(new EnemyChaseState());
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

    /// <summary>
    /// �v���C���[�ɍU�����ꂽ���̏���
    /// </summary>
    /// <param name="_player"></param>
    public void OnHit(PlayerController _player)
    {
        isHit = true;
        agent.ResetPath();   //�ړ��𑦒�~ ResetPath:��~
        ChangeState(null);   //��Ԃ���U�����i�������͐�p��HitState�ɐ؂�ւ��j
        enemyHealth.EnemtTakeDamage((int)_player.Attack_Power);

        //��莞�Ԍ�Ɉړ��ĊJ
        StartCoroutine(RecoverFromHit());
    }

    /// <summary>
    /// �������~�߂鏈��
    /// </summary>
    /// <returns></returns>
    private IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(0.5f); //�d��
        isHit = false;
        ChangeState(new EnemyChaseState()); //�d����ɒǐՍĊJ
    }

}
