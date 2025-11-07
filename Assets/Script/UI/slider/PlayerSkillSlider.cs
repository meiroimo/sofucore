using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkillSlider : MonoBehaviour
{
    [SerializeField, Header("skillスライダー")] Slider skillSlider;
    PlayerStatus_Script playerStatus_Script;
    PlayerSEBox seBox;

    float maxSkillPoint;    //たまるスキルポイント
    float nowSkillPoint;    //現在のスキルポイント
    float skillChargePoint; //1秒間にたまるスキルポイントの量

    bool isSkillCharge;//チャージするか true:チャージする false:チャージしない

    float nowTime;


    public void Init()
    {
        Application.targetFrameRate = 30;

        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        seBox = GetComponent<PlayerSEBox>();

        maxSkillPoint = playerStatus_Script.D_player_Skill_Point;
        nowSkillPoint = maxSkillPoint;
        skillChargePoint = playerStatus_Script.D_player_Skill_Charge;

        isSkillCharge = false;
        setNowPoint(1);
        //InvokeRepeating("メソッド名", 開始までの遅延時間, 繰り返し間隔);
        //InvokeRepeating(nameof(skillPointUICharge), 1.0f, 1.0f);

    }

    void Update()
    {
        if (!isSkillCharge) return;
        skillPointUICharge();
    }

    //チャージする
    void skillPointUICharge()
    {
        nowSkillPoint += skillChargePoint / Application.targetFrameRate;

        skillSet();

        if (isUseSkill())
        {
            isSkillCharge = false;
            seBox.PlayPlayerSE(PlayerSEBox.SENAME.CHARGE);
        }
    }

        //UIに反映
    void skillSet()
    {
        float nowValue = 1 - (nowSkillPoint / maxSkillPoint);

        skillSlider.value = nowValue;
    }

    //スキルを使えるか
    public bool isUseSkill()
    {
        if (nowSkillPoint >= maxSkillPoint) return true;
        else return false;
    }

    //使ったら1を入れる
    public void setNowPoint(float h_nowSkillPoint)
    {
        nowSkillPoint = h_nowSkillPoint;
        if (nowSkillPoint < maxSkillPoint) isSkillCharge = true;
        skillSet();
    }

    //ゲッター現在のポイントを返す
    public float getNowSkillPoint()
    {
        return nowSkillPoint;
    }

}
