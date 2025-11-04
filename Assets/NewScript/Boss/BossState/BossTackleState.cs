using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossTackleState : BossState
{
    //突進の状態管理
    private enum BOSSTACKLESTATUS
    {
        CHARGEPOWER = 0,
        TACKLE,
    };
    //突進までの時間
    float chargeTime;
    //突進の強さ
    float TacklePwer;
    //突進する時間
    float Tackletime;
    //攻撃判定
    bool atackkBool;

    private BossController bosscon;
    private BOSSTACKLESTATUS TACKLESTATS;
    public override void Enter(BossController boss)
    {
        Debug.Log("tackle");
        TACKLESTATS = BOSSTACKLESTATUS.CHARGEPOWER;
        //チャージ時間の設定
        chargeTime = 3.0f;
        //強さの設定
        TacklePwer = 1000.0f;
        //突進する時間設定
        Tackletime = 0.5f;
        //攻撃判定リセット
        atackkBool = false;
        if (bosscon==null)
        {
            bosscon = boss;
        }

    }
    //攻撃範囲に入ったら、突進攻撃ステートに移動、
    //その場で止まって、構える、方向はずっとプレイヤーを狙う、
    //一定時間貯めると走り出す、走り出したら、方向は変えない
    //突進する時間を決めて、その時間走るまで止まらない、
    //吹き飛ばしたいな

    
    public override void Update(BossController boss)
    {
        switch (TACKLESTATS)
        {
            case BOSSTACKLESTATUS.CHARGEPOWER:
                boss.Agent.ResetPath();  // 攻撃中は移動停止

                // プレイヤーの方向を向く
                Vector3 direction = (boss.player.position - boss.transform.position).normalized;
                direction.y = 0;
                if (direction != Vector3.zero)
                {
                    boss.transform.rotation = Quaternion.LookRotation(direction);
                }
                //カウントダウン
                chargeTime -= Time.deltaTime;
                if (chargeTime<=0)//突進へgo
                {
                    TACKLESTATS= BOSSTACKLESTATUS.TACKLE;
                    chargeTime = 3.0f;
                }
                break;
            case BOSSTACKLESTATUS.TACKLE:
                //正面方向に力を加えて、突進
                if (Tackletime == 0.5f)
                {
                    boss.GetComponent<Rigidbody>().AddForce(boss.transform.forward * TacklePwer);
                }
                // 攻撃判定
                if (boss.DistanceToPlayer <=2.5f&& !atackkBool)
                {
                    //ノックバックさせたい
                    //Vector3 NOCKBACKdirection = (boss.player.transform.position - boss.transform.position).normalized;
                    //boss.player.parent.GetComponent<Rigidbody>().AddForce(NOCKBACKdirection* TacklePwer);

                    // ここでプレイヤーのダメージ処理を呼び出せる
                    Debug.Log("Hit player!"); 
                    boss.Boss_SE.PlayBossSE(BossSEBox.SENAME.HIT);
                    boss.player.GetComponent<PlayerController>()?.TakeDamage((int)boss.Boss_Power);
                    atackkBool = true;
                }
                //突進カウントダウン
                Tackletime -= Time.deltaTime;
                if (Tackletime<=0)//突進を止める
                {
                    boss.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    boss.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    boss.ChangeState(new BossChaseState());//追跡に戻る
                }
                break;
            default:
                break;

        }
   
    }

    public override void Exit(BossController boss) { }
}
