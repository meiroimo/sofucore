using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
//using UnityEngine.WSA;

public class PlayerAttack_Script : MonoBehaviour
{
    // 入力を受け取る対象のAction
    private FlowerGuard2 testInputAction;//inputSystem
    public new Camera camera;//メインカメラ
    public RectTransform cursor; // カーソルを表すUIのImage
    private PlayerStatus_Script _status;
    public Vector3 dir;//マウスとプレイヤーのベクトル
    public float angle_m;//マウスとプレイヤーの角度
    public GameObject slashObj;

    [Header("ノックバック")] public bool shouldknockBackFlf;//ノックバック用
    [Header("近接攻撃の攻撃速度")] private float timeBetweenSpawnNormalAttack;//攻撃速度
    [Header("弾の攻撃速度")] private float timeBetweenSpawnBaretta;//攻撃速度
    private float spawnCounterNormalAttack = 1;
    private float spawnCounterBaretta = 1;

    [Header("攻撃の当たる距離")] public float meleeRange = 2f; // 近接攻撃の範囲
    [Header("弱攻撃のダメージ")] public int normalDamage = 4;  // 弱攻撃のダメージ量
    [Header("弱攻撃範囲")] public float l_fSightAngle = 90f;

    private void Awake()
    {
        _status = GetComponent<PlayerStatus_Script>();
    }

    void Start()
    {
        testInputAction = new FlowerGuard2();
        // performedコールバックのみを受け取る
        // 長押し判定になったらこのコールバックが呼ばれる
        testInputAction.Enable();
        PowerLoading();
    }

    void Update()
    {
        Player_Attack_Process();
    }

    public void PowerLoading()
    {
        normalDamage = (int)_status.player_Attack_Power;
    }

    /// <summary>
    /// プレイヤーの通常攻撃<br/>
    /// 左クリック：近接攻撃
    /// 右クリック：遠距離攻撃
    /// </summary>
    /// <param name="mouseVect"></param>
    public void Player_Attack_Process()
    {
        // 長押しの進捗を取得
        var progress_BarettaAttack = testInputAction.Player.BarettaAttack.GetTimeoutCompletionPercentage();
        var progress_NormalAttack = testInputAction.Player.NomalAttack.GetTimeoutCompletionPercentage();

        // 進捗をログ出力
        //Debug.Log($"Progress : {progress_NormalAttack * 100}%");
        //クールタイム
        timeBetweenSpawnNormalAttack -= Time.deltaTime;
        timeBetweenSpawnBaretta -= Time.deltaTime;

        if (progress_BarettaAttack > 0 && timeBetweenSpawnBaretta <= 0)
        {
            Debug.Log("遠距離攻撃！");
            bulletShooterAttack();
            timeBetweenSpawnBaretta = spawnCounterBaretta;
        }

        if (progress_NormalAttack > 0 && timeBetweenSpawnNormalAttack <= 0)
        {
            //Debug.Log("近接攻撃！");
            //Debug.Log(cursor.transform.position);
            PerformMeleeAttack();
            //PerformMeleeAttack2();
            timeBetweenSpawnNormalAttack = spawnCounterNormalAttack;
        }

    }

    /// <summary>
    /// キーボード操作用
    /// 弱攻撃(左クリック)
    /// 攻撃範囲に敵がいるとダメージを与える
    /// 攻撃範囲はm_fSightAngleの値を変える
    /// </summary>
    public void PerformMeleeAttack()
    {
        getAngle();
        // マウス位置を取得し、ワールド座標に変換
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2Dの場合はz座標を0に設定

        // 武器の位置からマウス方向へのベクトルを計算
        Vector3 direction = (mousePosition - transform.position).normalized;

        // 攻撃範囲内の全オブジェクトを取得（円形の範囲内）
        //「OverlapCircleAll」意味：指定された位置と半径内にあるすべてのコライダーを検出し、
        //                          それらを配列で返す
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, meleeRange);

        foreach(Collider2D hit in hits)
        {
            if(hit != null)
            {
                // ヒット対象の方向ベクトルを取得
                Vector3 targetDir = (hit.transform.position - transform.position).normalized;

                // ベクトル間の角度を計算
                //Vector3.Angleの解説:https://www.youtube.com/watch?v=7oTErexCuwk
                float angle = Vector3.Angle(direction, targetDir);

                //Vector3 effectPosition = (dir.normalized) * 2f + transform.position;
                //GameObject clone = Instantiate(slashObj, effectPosition, Quaternion.AngleAxis(angle_m + 90, Vector3.forward));
                //clone.GetComponent<Animator>().SetInteger("ElementState", (int)elementManager.currentElement);

                // 指定角度内にいる場合、ダメージを適用
                if (angle <= l_fSightAngle / 2)
                {
                    //ヒットした対象にダメージを与える
                    //ヒットしたオブジェクトが敵の場合、特定のスクリプトを持っているとダメージを与える
                    EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
                    if(enemy != null)
                    {
                        enemy.TakeDamageKnockBack(normalDamage, shouldknockBackFlf);
                    }
                }
            }
        }
    }

    /// <summary>
    /// コントローラー操作用
    /// 弱攻撃(左クリック)
    /// 攻撃範囲に敵がいるとダメージを与える
    /// 攻撃範囲はm_fSightAngleの値を変える
    /// </summary>
    public void PerformMeleeAttack2()
    {
        // Canvas内のカーソル位置（スクリーン座標）
        Vector3 cursorPosition_s = cursor.position;

        Vector3 cursorPosition_w = Camera.main.ScreenToWorldPoint(cursorPosition_s);
        cursorPosition_w.z = 0f;

        // 武器の位置からマウス方向へのベクトルを計算
        Vector3 direction = (cursorPosition_w - transform.position).normalized;

        // 攻撃範囲内の全オブジェクトを取得（円形の範囲内）
        //「OverlapCircleAll」意味：指定された位置と半径内にあるすべてのコライダーを検出し、
        //                          それらを配列で返す
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, meleeRange);

        foreach (Collider2D hit in hits)
        {
            if (hit != null)
            {
                // ヒット対象の方向ベクトルを取得
                Vector3 targetDir = (hit.transform.position - transform.position).normalized;

                // ベクトル間の角度を計算
                float angle = Vector3.Angle(direction, targetDir);

                // 指定角度内にいる場合、ダメージを適用
                if (angle <= l_fSightAngle / 2)
                {
                    //ヒットした対象にダメージを与える
                    //ヒットしたオブジェクトが敵の場合、特定のスクリプトを持っているとダメージを与える
                    EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
                    if (enemy != null)
                    {
                        enemy.TakeDamageKnockBack(normalDamage, shouldknockBackFlf);
                    }
                }
            }
        }
    }

    /// <summary>
    /// このオブジェクトとマウス間のベクトルのなす角度の取得、右が０度
    /// </summary>
    void getAngle()
    {
        Vector3 mouseViewPortPoint = camera.ScreenToViewportPoint(Input.mousePosition);//マウスのビューポート座標
        Vector3 wouldPoint = camera.ViewportToWorldPoint(mouseViewPortPoint);//マウスのビューポート座標をワールド座標に変換
        wouldPoint.z = 0;//なんかｚ座標が－８になるので０でリセット


        dir = wouldPoint - transform.position;//このオブジェクトとマウス間のベクトル取得
        var axis = Vector3.Cross(this.transform.position, dir);//左右の判別

        angle_m = Vector3.Angle(this.transform.position, dir) * (axis.z < 0 ? -1 : 1);//このオブジェクトとマウス間のベクトルのなす角度の取

    }

    /// 遠距離攻撃用の関数
    /// </summary>
    public void bulletShooterAttack()
    {

        // 弾（ゲームオブジェクト）の生成
        GameObject clone = Instantiate(slashObj, transform.position, Quaternion.AngleAxis(angle_m, Vector3.forward));

        // クリックした座標の取得（スクリーン座標からワールド座標に変換）
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 向きの生成（Z成分の除去と正規化）
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        clone.transform.rotation = Quaternion.Euler(shotForward);
        // 弾に速度を与える
        clone.GetComponent<Rigidbody2D>().velocity = shotForward * 3;

    }

    /// <summary>
    /// 攻撃範囲を表示する
    /// デバック用に使う
    /// </summary>
    void OnDrawGizmosSelected()
    {
        // Canvas内のカーソル位置（スクリーン座標）
        //Vector3 cursorPosition_s = cursor.position;

        //Vector3 cursorPosition_w = Camera.main.ScreenToWorldPoint(cursorPosition_s);
        //cursorPosition_w.z = 0f;

        //cursor.transform.position = cursorPosition_w;

        // シーンビューに攻撃範囲と角度を視覚的に表示
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = (mousePosition - transform.position).normalized;
        //Vector3 direction2 = (cursorPosition_w - transform.position).normalized;

        Gizmos.color = UnityEngine.Color.green;
        // 扇形の範囲を描画
        Quaternion leftRayRotation = Quaternion.AngleAxis(-l_fSightAngle / 2, Vector3.forward);
        Quaternion rightRayRotation = Quaternion.AngleAxis(l_fSightAngle / 2, Vector3.forward);

        Vector3 leftRayDirection = leftRayRotation * direction * meleeRange;
        Vector3 rightRayDirection = rightRayRotation * direction * meleeRange;

        Gizmos.DrawRay(transform.position, leftRayDirection);
        Gizmos.DrawRay(transform.position, rightRayDirection);

        //Quaternion RayRotation = Quaternion.AngleAxis(l_fSightAngle, Vector3.forward);
        //Vector3 RayDirection = RayRotation * direction2 * meleeRange;

        //Gizmos.DrawRay(transform.position, RayDirection);

        //Gizmos.color = Color.yellow;
        //Quaternion r_leftRayRotation = Quaternion.AngleAxis(-r_fSightAngle / 2, Vector3.forward);
        //Quaternion r_rightRayRotation = Quaternion.AngleAxis(r_fSightAngle / 2, Vector3.forward);

        //Vector3 r_leftRayDirection = r_leftRayRotation * direction * meleeRange;
        //Vector3 r_rightRayDirection = r_rightRayRotation * direction * meleeRange;

        //Gizmos.DrawRay(holder.position, r_leftRayDirection);
        //Gizmos.DrawRay(holder.position, r_rightRayDirection);

    }


}
