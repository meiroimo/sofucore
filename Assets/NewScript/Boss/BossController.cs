using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Transform player;
    private PlayerStatus_Script playerstatus;
    private NavMeshAgent agent;

    private BossState currentState;
    private EnemyStatus_Script bossStatus;
    private BossHealth bossHealth;
    private BossSEBox boss_SE;

    private float boss_Power;
    private float boss_Speed;

    private bool isHit = false;

    public GameObject attackEffect;


    // 距離チェック
    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Boss_Power { get => boss_Power; set => boss_Power = value; }
    public BossSEBox Boss_SE { get => boss_SE; set => boss_SE = value; }
    public PlayerStatus_Script Playerstatus { get => playerstatus; set => playerstatus = value; }

    // プレイヤーを設定する用の関数
    public void SetPlayer(Transform playerTransform, PlayerStatus_Script playerStatus)
    {
        player = playerTransform;
        playerstatus = playerStatus.GetComponent<PlayerStatus_Script>();
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
        attackEffect.SetActive(false);

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
    /// プレイヤーに攻撃された時の処理
    /// </summary>
    /// <param name="_player"></param>
    public void OnHit(PlayerController _player)
    {
        isHit = true;
        //agent.ResetPath();   // 移動を即停止 ResetPath:停止
        //ChangeState(null);   // 状態を一旦解除（もしくは専用のHitStateに切り替え）
        bossHealth.TakeDamage((int)_player.Attack_Power);

        // 例: 一定時間後に移動再開
        //StartCoroutine(RecoverFromHit());
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} は倒された！");
        if(!(currentState is BossDefeatedState))
        {
            ChangeState(new BossDefeatedState());
        }
    }
    public void StartAttackEffect()
    {
        attackEffect.SetActive(true);

    }

}
