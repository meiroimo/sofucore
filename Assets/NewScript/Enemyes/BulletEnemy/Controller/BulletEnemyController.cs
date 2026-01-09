using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletEnemyController : MonoBehaviour
{
    [HideInInspector] public Transform player;
    private NavMeshAgent agent;

    [Header("発射したい弾のオブジェクト")] public GameObject bullet;
    [Header("弾を生成する位置")] public Transform generatePoint;

    private BulletEnemyState currentState;
    private EnemyStatus_Script enemyStatus;
    private EnemyHealthScript enemyHealth;
    private EnemySEBox enemy_SE;

    private float enemy_Power;
    private float enemy_Speed;

    private bool isHit = false;
    [SerializeField] private float attackInterval;

    public float DistanceToPlayer => Vector3.Distance(transform.position, player.position);

    public bool IsHit { get => isHit; set => isHit = value; }
    public float AttackInterval { get => attackInterval; set => attackInterval = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Enemy_Power { get => enemy_Power; set => enemy_Power = value; }

    //プレイヤーを設定する用の関数
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }


    // Start is called before the first frame update
    void Start()
    {
        //GetComponent
        #region
        enemyHealth = GetComponent<EnemyHealthScript>();
        agent = GetComponent<NavMeshAgent>();
        enemyStatus = GetComponent<EnemyStatus_Script>();
        enemy_SE = GetComponent<EnemySEBox>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        #endregion

        //初期化
        #region
        enemy_Power = enemyStatus.enemy_Attack_Power;
        enemy_Speed = enemyStatus.enemy_Speed - 2;
        agent.speed = enemy_Speed;
        #endregion

        ChangeState(new BulletEnemyChaseState());

    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.Update(this);
        }
    }

    public void ChangeState(BulletEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit(this);
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.Enter(this);
        }
    }

    
    public void InitBullet()
    {
        if(!player) return;

        //プレイヤーの方向を計算
        Vector3 dir = (player.position - generatePoint.position).normalized;

        dir.y = 0;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //弾の生成
        GameObject enemy_Bullet = Instantiate(bullet, generatePoint.position, lookRotation);

        //弾に進行方向を伝える
        enemy_Bullet.GetComponent<EnemyBullet_Script>().SetDirection(dir);
        enemy_Bullet.GetComponent<EnemyBullet_Script>().SetBulletEnemy(this);

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
        ChangeState(new BulletEnemyChaseState()); //硬直後に追跡再開
    }



}
