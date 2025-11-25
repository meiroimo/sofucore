using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ソフビ1体のパラメータデータを保持（モデル、スキル、テーマ、バフ値など）。
/// UIボタンや設置場所オブジェクトにも付与されている。
/// </summary>
public class softVinyl : MonoBehaviour
{
   // [Header("ソフビデータ")] public SofviDataScriptable SofviDataScriptable;
    [Header("ソフビデータ")] public SoftVinilData SofviData;



    //[Header("ソフビ種類")] public SOFVINUMBER sofvimodel;//このソフビの３ｄモデルプレハブ
    //[Header("テーマ")] public themeNuｍ theme;//このソフビのテーマ
    //[Header("スキル")] public SKILLNUM skill;//このソフビのスキル
    //[Header("レア度")] public Raritynum rarity;//このソフビのレア度

    //[Header("コスト")] public int cost;//このソフビのコスト
    //[Header("ナンバー")] public int ListNumber;//このソフビの番号


    //[Header("バフメインステータス")] public BUFFSTATUSNUM buffMainstatus;//メインステ
    //[Header("バフサブステータス１")] public BUFFSTATUSNUM buffSubstatus1;//サブステ１
    //[Header("バフサブステータス２")] public BUFFSTATUSNUM buffSubstatus2;//サブステ２
    //[Header("バフサブステータス３")] public BUFFSTATUSNUM buffSubstatus3;//サブステ３

    //[Header("バフメインステータスパラメーター")] public int Buffparameter;//メインステ
    //[Header("バフサブステータスパラメーター１")] public int Buffparameter1;//サブステ１
    //[Header("バフサブステータスパラメーター２")] public int Buffparameter2;//サブステ２
    //[Header("バフサブステータスパラメーター３")] public int Buffparameter3;//サブステ３


    ///// <summary>
    /////設置ポジション用ソフビが置かれていたら判定 
    ///// </summary>
    //public bool checksetpotion = false;
    //public bool selectCheck;
    //public GameObject selectButton;//セレクト中のボタン




    /// <summary>
    /// テーマのイーナム
    /// </summary>
    //public enum themeNuｍ
    //{
    //    NULL = 0,
    //    theme1,
    //    theme2,
    //    theme3,
    //    theme4,
    //    theme5,
    //    theme6,
    //    theme7,
    //    theme8,
    //    theme9,
    //    theme10,
    //    theme11,
    //    theme12,
    //    theme13,
    //    theme14,
    //    theme15,
    //    theme16,
    //    theme17,
    //    theme18,
    //    theme19,
    //    theme20,
    //    MAX,
    //}
    ///// <summary>
    ///// スキルのイーナム
    ///// </summary>
    //public enum SKILLNUM
    //{
    //    NULL = 0,
    //    SKILL1,
    //    SKILL2,
    //    SKILL3,
    //    SKILL4,
    //    MAX,
    //}
    //public enum SOFVINUMBER
    //{
    //    NULL = 0,
    //    MODEL1,
    //    MODEL2,
    //    MODEL3,
    //    MODEL4,
    //    MAX,
    //}



    //public enum BUFFSTATUSNUM
    //{
    //    NULL=0,
    //    POWER,
    //    MAXHP,
    //    SKILL_CHARGE,
    //    SUTAMINA_RECHARGE_SPEED,
    //    MAXSUTAMINA,
    //}

    /// <summary>
    /// テーマのイーナム
    /// </summary>



    void Start()
    {
      //if(SofviDataScriptable==null)
      //  {
      //      SofviDataScriptable = new SofviDataScriptable();

      //  }
        if (SofviData == null)
        {
            SofviData = new SoftVinilData();

        }

    }

    void Update()
    {
        
    }
  
}
