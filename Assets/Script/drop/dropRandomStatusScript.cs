using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static softVinyl;
using static TreasureChestDropScript;

public class dropRandomStatusScript : MonoBehaviour
{
    /*
     Prefabs/drop/sofvi　オブジェクトに貼る
     生成されたタイミングでステータスをランダムで付与する
     対応するレアリティ＆ステータスの追加値を入れる
     */
    softVinyl softVinylStatusScript;
    //追加する値　ステータスの順番は softVinylのBUFFSTATUSNUM enumの順でいれる
    List<List<int>> setRarityStatus = new List<List<int>>()
    {
        //POWER,DEFENSE,SPEED,CRITICAL,CRITICALDAMAGE,MAXHP,MAXSUTAMINA,SUTAMINA_CHARGE_SPEED,SKILL_CHARGE,ATTACKRANGE
        new List<int>(){1,0,2,1,1,10,10,1,1,10},  //Normal
        new List<int>(){3,0,4,2,2,30,30,3,3,30},  //RARE
        new List<int>(){5,0,6,3,3,50,50,5,5,50}   //SUPARRARE
    };

    void Start()
    {
        softVinylStatusScript = GetComponent<softVinyl>();
        
        SetStatusRandom();
    }

    void Update()
    {
        
    }


    void SetStatusRandom()
    {
        //メインステ
        softVinylStatusScript.buffMainstatus = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;
        //サブステ１
        softVinylStatusScript.buffSubstatus1 = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;
        //サブステ2
        softVinylStatusScript.buffSubstatus2 = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;
        //サブステ3
        softVinylStatusScript.buffSubstatus3 = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;

        //メインステ　追加値
        softVinylStatusScript.BuffMainParameter = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffMainstatus -1] + 1;
        //サブステ１　追加値
        softVinylStatusScript.BuffSubparameter1 = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffSubstatus1 -1] + 1;
        //サブステ2 　追加値
        softVinylStatusScript.Buffparameter2 = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffSubstatus2 -1] + 1;
        //サブステ3 　追加値
        softVinylStatusScript.Buffparameter3 = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffSubstatus3 -1] + 1;


    }
}
