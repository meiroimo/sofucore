using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public GameObject Canvas;
    public GameObject Camera;

    public enemyMotionScript EnemyMotionScript;

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

        if (enemyHealth != null)
        {
            enemyHealth.OnDeath += HandleDeath;
        }
        //Camera = GameObject.Find("Main Camera");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        //NavMesh 上に乗るまで待つ
        //yield return new WaitUntil(() => agent.isOnNavMesh);

        ChangeState(new EnemyChaseState());
        attackEffect.SetActive(false);

        if (transform.localScale.x > 1.0f) Canvas.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        if (1.0f > transform.localScale.x) Canvas.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

    }

    void Update()
    {
        Canvas.transform.LookAt(Camera.transform);
        currentState?.Update(this);
        //JudgementDrop();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    //接触ダメージ用
    private int contactDamage = 2;
    private float contactDamageInterval = 0.1f;
    private bool isTouchingPlayer = false;
    private Coroutine contactDamageCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isTouchingPlayer) return;

        isTouchingPlayer = true;

        //触れた瞬間のダメージ
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(contactDamage);
        }

        //継続ダメージ開始
        contactDamageCoroutine = StartCoroutine(ContactDamageLoop(player));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        isTouchingPlayer = false;

        if (contactDamageCoroutine != null)
        {
            StopCoroutine(contactDamageCoroutine);
            contactDamageCoroutine = null;
        }
    }

    private IEnumerator ContactDamageLoop(PlayerController player)
    {
        while (isTouchingPlayer)
        {
            yield return new WaitForSeconds(contactDamageInterval);

            if (player != null)
            {
                player.TakeDamage(contactDamage);
            }
        }
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
        Knockback(player.transform.position);
        agent.ResetPath();   //移動を即停止 ResetPath:停止
        ChangeState(null);   //状態を一旦解除（もしくは専用のHitStateに切り替え）
        enemyHealth.EnemtTakeDamage((int)_player.Attack_Power);
        Debug.Log((int)_player.Attack_Power);

        //一定時間後に移動再開
        StartCoroutine(RecoverFromHit());
    }

    private float knockbackDistance = 0.5f;
    private float knockbackTime = 0.1f;

    public void Knockback(Vector3 fromPosition)
    {
        if (agent == null) return;

        // ノックバック方向（プレイヤー → 敵）
        Vector3 dir = (transform.position - fromPosition).normalized;
        dir.y = 0;

        Vector3 targetPos = transform.position + dir * knockbackDistance;

        StartCoroutine(KnockbackRoutine(targetPos));
    }

    private IEnumerator KnockbackRoutine(Vector3 targetPos)
    {
        agent.isStopped = true;

        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < knockbackTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / knockbackTime;

            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        agent.isStopped = false;
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

    private void HandleDeath()
    {
        // EnemyHealthが死を検知 → Spawnerへ伝える
        OnDeath?.Invoke();
    }


}
