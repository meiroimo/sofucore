using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using static playerEffectScript;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度")]
    public float moveForce = 10f;//移動速度
    public float rotationSpeed = 10f;

    private float comboInputWindow = 0.6f; //次の攻撃を受け付ける猶予時間
    private bool receivedNextAttack = false;
    private Vector3 fixedAttackDirection; //攻撃中の向き（マウス）
    private Vector2 attackStickInput;//攻撃の向き（コントローラー用）
    private bool isAttack = false;
    private bool isRunning = false;

    private float attack_Power;
    private float attackRadius = 5f;
    private float attackAngle = 60f;

    public Camera mainCamera;
    public LayerMask enemyLayer;
    public float attackRange = 100f;
    public GameObject effectOBJ;
    public playerEffectScript playerEffect;

    private FlowerGuard2 inputActions;
    private PlayerState currentState;
    private PlayerStatus_Script playerStatus_Script;
    private HPSliderScript hpSliderScript;
    private StaminaSliderScript staminaSliderScript;
    private PlayerSkillSlider[] playerSkillSlider;
    public FilledAttackCone attackCone;
    public playerEffectScript PlayerEffectScript;
    public Animator animator;
    private PlayerSEBox _seBox;
    public playerMotionScript PlayerMotionScript;

    //コントローラー関係
    #region 
    private enum InputDeviceType 
    { 
        Mouse, 
        Gamepad 
    }

    private InputDeviceType lastUsedDevice = InputDeviceType.Mouse;

    private Vector2 lastMousePosition;
    #endregion
    //コントローラー関係

    /// <summary>
    /// 必殺技 = 0,
    /// スキル1 = 1,
    /// スキル2 = 2
    /// </summary>
    enum SkillName
    {
        SPECIAL = 0,
        SKILL_1,
        SKILL_2
    }

    //ゲッター・セッター
    #region
    public Vector2 MoveInput { get; private set; }
    public Rigidbody Rigid { get; private set; }
    public float ComboInputWindow { get => comboInputWindow; set => comboInputWindow = value; }
    public bool ReceivedNextAttack { get => receivedNextAttack; set => receivedNextAttack = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public Vector3 FixedAttackDirection { get => fixedAttackDirection; set => fixedAttackDirection = value; }
    public float Attack_Power { get => attack_Power; set => attack_Power = value; }
    public PlayerSEBox SeBox { get => _seBox; set => _seBox = value; }
    public Vector2 AttackStickInput { get => attackStickInput; set => attackStickInput = value; }
    public bool IsRunning { get => isRunning; }
    #endregion
    //ゲッター・セッター

    private void Awake()
    {
        //GetComponent
        #region
        inputActions = new FlowerGuard2();
        Rigid = gameObject.GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        hpSliderScript = GetComponent<HPSliderScript>();
        staminaSliderScript = GetComponent<StaminaSliderScript>();
        playerSkillSlider = GetComponents<PlayerSkillSlider>(); //同一コンポーネントを複数Getするときは[GetComponents]でｓ付ける
        PlayerEffectScript = effectOBJ.GetComponent<playerEffectScript>();
        _seBox = GetComponent<PlayerSEBox>();
        #endregion
        //GetComponent

        //初期化
        #region
        playerStatus_Script.Init();
        hpSliderScript.Init();
        staminaSliderScript.Init();
        for(int i = 0;i < playerSkillSlider.Length; i++) {
            playerSkillSlider[i].Init();
        }
        #endregion
        //初期化

        //InputSystem
        #region
        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
        inputActions.Player.AttackDirection.performed += ctx => AttackStickInput = ctx.ReadValue<Vector2>();
        inputActions.Player.AttackDirection.canceled += ctx => AttackStickInput = Vector2.zero;
        inputActions.Player.Avoid.performed += ctx => OnAvoid();
        //inputActions.Player.NomalAttack.performed += cxt => OnLightAttack();
        inputActions.Player.NomalAttack.performed += ctx =>
        {
            if (ctx.control is ButtonControl btn && btn.wasPressedThisFrame)
            {
                OnLightAttack();
            }
        };
        inputActions.Player.BarettaAttack.performed += cxt => OnSkillAttack();
        inputActions.Player.Run.performed += ctx => isRunning = true;
        inputActions.Player.Run.canceled += ctx => isRunning = false;
        #endregion
        //InputSystem

    }

    //Enable : GameObject が有効になったとき
    //         入力処理（Input System）を有効にする
    private void OnEnable() => inputActions.Enable();

    //Disable : GameObject が無効になったとき
    //         入力処理を無効にしてリソースを解放する
    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        moveForce = playerStatus_Script.D_player_Speed;
        attack_Power = playerStatus_Script.D_player_Attack_Power;

        ChangeState(new PlayerIdleState(this));
    }

    private void Update()
    {
        currentState?.Update();
        UpdateLastUsedInputDevice();
        PlayerCurrentDirection();

        if (hpSliderScript.GetNowHealth() <= 0)
        {
            PlayerMotionScript.dethMotion(true);
        }
    }

    //状態変更のための関数
    public void ChangeState(PlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    /// <summary>
    /// プレイヤーの回転処理
    /// </summary>
    /// <param name="direction"></param>
    public void RotateTowards(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return; // 入力が小さいときは回転しない
        if (isAttack)
        {
            direction = fixedAttackDirection.normalized;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 指定された方向に指定速度で移動させる関数
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="speed"></param>
    public void MoveCharacter(Vector3 direction, float speed)
    {
        //sqrMagnitude:ベクトルの長さ（magnitude）の2乗を表す
        if (direction.sqrMagnitude < 0.01f)
        {
            // 入力が無いとき、横移動速度だけ止める
            Rigid.velocity = new Vector3(0, Rigid.velocity.y, 0);
            return;
        }
        Vector3 moveVelocity = direction.normalized * speed;
        Rigid.velocity = new Vector3(moveVelocity.x, Rigid.velocity.y, moveVelocity.z);
        RotateTowards(direction);
    }

    /// <summary>
    /// 通常移動用の関数
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="speed"></param>
    public void MoveInDirection(Vector3 direction, float speed)
    {
        Rigid.velocity = direction.normalized * speed;
    }

    /// <summary>
    /// 回避用の移動処理
    /// </summary>
    /// <param name="velocity"></param>
    public void MoveInstant(Vector2 velocity)
    {
        Rigid.velocity = velocity;
    }

    /// <summary>
    /// プレイヤーの攻撃関数
    /// </summary>
    public void PlayerLAttack()
    {
        PlayerCurrentDirection();

        Vector3 origin = transform.position;
        Vector3 forward = transform.forward;

        Collider[] hits = Physics.OverlapSphere(origin, attackRadius, enemyLayer);

        _seBox.PlayPlayerSE(PlayerSEBox.SENAME.ATTACK);

        foreach (Collider col in hits)
        {
            Vector3 dirToTarget = (col.transform.position - origin).normalized;
            dirToTarget.y = 0; // 水平のみで比較

            float angle = Vector3.Angle(forward, dirToTarget);
            if (angle < attackAngle / 2f)
            {
                EnemyController enemy = col.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    _seBox.PlayPlayerSE(PlayerSEBox.SENAME.HIT);
                    enemy.OnHit(this);
                }

                BulletEnemyController bulletenemy = col.GetComponent<BulletEnemyController>();
                if (bulletenemy != null)
                {
                    //Debug.Log($"{col.name} に攻撃が命中しました！");
                    _seBox.PlayPlayerSE(PlayerSEBox.SENAME.HIT);
                    bulletenemy.OnHit(this);
                }

                BossController boss = col.GetComponent<BossController>();
                if(boss != null)
                {
                    _seBox.PlayPlayerSE(PlayerSEBox.SENAME.HIT);
                    boss.OnHit(this);
                }
            }
        }
    }

    /// <summary>
    /// マウスの位置にプレイヤーを向ける関数
    /// </summary>
    private void PlayerCurrentDirection()
    {
        if (lastUsedDevice == InputDeviceType.Gamepad && AttackStickInput.sqrMagnitude > 0.1f) // 右スティック入力がある
        {
            Vector3 stickDir = new Vector3(AttackStickInput.x, 0, AttackStickInput.y);
            transform.rotation = Quaternion.LookRotation(stickDir);
        }
        else
        {
            //マウス位置へのRayを取得
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //プレイヤーの高さに水平な仮想平面を作成
            Plane groundPlane = new Plane(Vector3.up, transform.position);
            if (groundPlane.Raycast(ray, out float distance))
            {
                Vector3 lookPoint = ray.GetPoint(distance);
                //プレイヤーがマウス位置の方向を向く
                Vector3 targetDirection = lookPoint - transform.position;
                targetDirection.y = 0f;//水平のみ回転
                if (targetDirection != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(targetDirection);
                }
            }
        }
    }

    /// <summary>
    /// 攻撃のダメージ判定関数
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        float currentHP = hpSliderScript.GetNowHealth();
        currentHP -= damage;
        hpSliderScript.SetNowHealth(currentHP);
        Debug.Log($"Player に {damage}ダメージ！. 現在HP: {currentHP}");
        playerEffect.PlayEffect((int)EffectName.DAMAGE);

        if (currentHP <= 0)
        {
            PlayerStatusCache.LastStatusSave(playerStatus_Script);
            SceneManager.LoadScene("ResultScene");
            Debug.Log("Player died");
            // 死亡処理
        }

    }

    /// <summary>
    /// スタミナを減少させる
    /// ：回避を使用した際に呼ばれる
    /// </summary>
    /// <param name="stamina"></param>
    public void TakeAvoid(float stamina)
    {
        float currentStamina = staminaSliderScript.GetNowStamina();
        if (currentStamina <= stamina) return;
        currentStamina -= stamina;
        staminaSliderScript.SetNowStamina(currentStamina);
    }

    //public float FacingDirection => transform.localScale.x;

    //private bool isInvincible = false;

    /// <summary>
    /// 回避ステート呼び出し
    /// </summary>
    public void OnAvoid()
    {
        //if (CanDodge()) // 任意：クールタイム等
        {
            ChangeState(new PlayerAvoidState(this));
        }
    }

    /// <summary>
    /// 攻撃ステート呼び出し
    /// </summary>
    public void OnLightAttack()
    {
        // Idle中又はMoveならAttackOneへ
        if (currentState is PlayerIdleState)
        {
            ChangeState(new AttackOneState(this));
        }
        else if (currentState is PlayerMoveState)
        {
            ChangeState(new AttackOneState(this));
        }
        else
        {
            // 攻撃中なら次の攻撃フラグを立てる
            receivedNextAttack = true;
        }
    }

    /// <summary>
    /// スキルステート呼び出し
    /// </summary>
    public void OnSkillAttack()
    {
        //必要なスキルポイントがあるかの判定を作る
        if (playerSkillSlider[(int)SkillName.SPECIAL].isUseSkill())  //一旦0番目の必殺ゲージにしてある
        {
            playerSkillSlider[(int)SkillName.SPECIAL].setNowPoint(1);
            ChangeState(new PlayerSkillAttackState(this));
        }
    }

    /// <summary>
    /// デバイス判定用
    /// </summary>
    private void UpdateLastUsedInputDevice()
    {
        // コントローラーの右スティックを監視
        if (AttackStickInput.sqrMagnitude > 0.1f)
        {
            lastUsedDevice = InputDeviceType.Gamepad;
            return;
        }

        // マウス位置が変化したかを監視
        //[?]: Mouse.currentがnullかをチェックする
        Vector2 currentMousePos = Mouse.current?.position.ReadValue() ?? Vector2.zero;
        if (currentMousePos != lastMousePosition)
        {
            lastMousePosition = currentMousePos;
            lastUsedDevice = InputDeviceType.Mouse;
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 5f); // 半径に合わせて調整

    //    Vector3 left = Quaternion.Euler(0, -30f, 0) * transform.forward;
    //    Vector3 right = Quaternion.Euler(0, 30f, 0) * transform.forward;

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawRay(transform.position, left * 5f);
    //    Gizmos.DrawRay(transform.position, right * 5f);

    //    Vector3 left2 = Quaternion.Euler(0, -25f, 0) * transform.forward;
    //    Vector3 right2 = Quaternion.Euler(0, 25f, 0) * transform.forward;

    //    Gizmos.color = Color.black;
    //    Gizmos.DrawRay(transform.position, left2 * 5f);
    //    Gizmos.DrawRay(transform.position, right2 * 5f);

    //}
}
