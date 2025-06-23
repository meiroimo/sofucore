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
    private float enemy_Speed;

    private bool isHit = false;
    public event System.Action OnDeath; // 死亡イベント

    // 距離チェック
    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Enemy_Power { get => enemy_Power; set => enemy_Power = value; }

    // プレイヤーを設定する用の関数
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
        enemy_Speed = enemyStatus.enemy_Speed;
        agent.speed = enemy_Speed;
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
    /// プレイヤーに攻撃された時の処理
    /// </summary>
    /// <param name="_player"></param>
    public void OnHit(PlayerController _player)
    {
        isHit = true;
        agent.ResetPath();   // 移動を即停止 ResetPath:停止
        ChangeState(null);   // 状態を一旦解除（もしくは専用のHitStateに切り替え）
        enemyHealth.TakeDamage((int)_player.Attack_Power);

        // 例: 一定時間後に移動再開
        StartCoroutine(RecoverFromHit());
    }

    /// <summary>
    /// 動きを止める処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(1.0f); // 1秒硬直
        isHit = false;
        ChangeState(new EnemyChaseState()); // 硬直後に追跡再開
    }

    //public void Die()
    //{
    //    Debug.Log("敵が死んだ");

    //    // イベント通知：登録されていれば呼び出す
    //    OnDeath?.Invoke();

    //    Destroy(gameObject);
    //}
}
