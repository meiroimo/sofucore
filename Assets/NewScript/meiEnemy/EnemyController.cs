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
    public event System.Action OnDeath; //死亡イベント

    public GameObject attackEffect;


    //距離チェック
    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Enemy_Power { get => enemy_Power; set => enemy_Power = value; }
    public EnemySEBox Enemy_SE { get => enemy_SE; set => enemy_SE = value; }

    //プレイヤーを設定する用の関数
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

        //初期化
        #region
        enemy_Power = enemyStatus.enemy_Attack_Power;
        enemy_Speed = enemyStatus.enemy_Speed;
        agent.speed = enemy_Speed;
        #endregion

        ChangeState(new EnemyChaseState());
        attackEffect.SetActive(false);
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
    /// プレイヤーに攻撃された時の処理
    /// </summary>
    /// <param name="_player"></param>
    public void OnHit(PlayerController _player)
    {
        isHit = true;
        agent.ResetPath();   //移動を即停止 ResetPath:停止
        ChangeState(null);   //状態を一旦解除（もしくは専用のHitStateに切り替え）
        enemyHealth.EnemtTakeDamage((int)_player.Attack_Power);

        //一定時間後に移動再開
        StartCoroutine(RecoverFromHit());
    }

    /// <summary>
    /// 動きを止める処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(0.5f); //硬直
        isHit = false;
        ChangeState(new EnemyChaseState()); //硬直後に追跡再開
    }

    public void StartAttackEffect()
    {
        attackEffect.SetActive(true);

    }

}
