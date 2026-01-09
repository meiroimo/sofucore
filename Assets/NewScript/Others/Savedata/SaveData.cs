
/// <summary>
/// Jsonを使用したデータ保持
/// </summary>
[System.Serializable]
public class SaveData
{
    //プレイヤーの最終ステータス
    #region
    public float maxHealth;             //最大HP(ソフビによる変動あり)
    public float currentHealth;         //現在HP
    public float attackPower;           //攻撃力(ソフビによる変動あり)
    public float player_Speed;          //移動速度
    public float maxStamina;            //最大スタミナ(ソフビによる変動あり)
    public float currentStamina;        //現在スタミナ
    public float staminaRecoverySpeed;  //スタミナ回復速度(ソフビによる変動あり)
    public float attackRange;           //攻撃範囲(ソフビによる変動あり)
    public float maxSkillPoint;         //最大スキルポイント
    public float skillRecoverySpeed;    //スキルチャージ(ソフビによる変動あり)
    #endregion
    //プレイヤーの最終ステータス

    //初期ステータス(プレイヤー)
    #region
    public float base_maxHealth;             //最大HP(ソフビによる変動あり)
    public float base_currentHealth;         //現在HP
    public float base_attackPower;           //攻撃力(ソフビによる変動あり)
    public float base_player_Speed;          //移動速度
    public float base_maxStamina;            //最大スタミナ(ソフビによる変動あり)
    public float base_currentStamina;        //現在スタミナ
    public float base_staminaRecoverySpeed;  //スタミナ回復速度(ソフビによる変動あり)
    public float base_attackRange;           //攻撃範囲(ソフビによる変動あり)
    public float base_maxSkillPoint;         //最大スキルポイント
    public float base_skillRecoverySpeed;    //スキルチャージ(ソフビによる変動あり)
    #endregion
    //初期ステータス(プレイヤー)

}