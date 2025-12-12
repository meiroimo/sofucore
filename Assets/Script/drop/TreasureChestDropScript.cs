using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static SoftVinilData;
public class TreasureChestDropScript : MonoBehaviour
{
    /*
     敵に張り付けるスクリプト
     死ぬときに確率でソフビ・宝箱を落とす
     落ちたらそこから確率でレアリティ付ける
     */
    [SerializeField, Header("ドロップするオブジェクト-dropOBJ<レアリティ<レアリティ内のOBJ>>-")]
    List<RarityOBJ> dropOBJ;

    [System.Serializable]
    public class RarityOBJ
    {
        public List<GameObject> objType;
    }

    [SerializeField, Header("ドロップする確率 %で入力"), Range(0, 100)]
    int dropRate;

    [SerializeField, Header("レアリティ割合 %で入力　レアリティ高い順で入れる")]
    int[] rarityRate;


    //追加する値　ステータスの順番は softVinylのBUFFSTATUSNUM enumの順でいれる
    List<List<int>> setRarityStatus = new List<List<int>>()
    {
        //POWER,MAXHP,SKILL_CHARGE,SUTAMINA_RECHARGE_SPEED,MAXSUTAMINA,
        new List<int>(){1,10,1,1,10},  //Normal
        new List<int>(){3,30,3,3,30},  //RARE
        new List<int>(){5,50,5,5,50}   //SUPARRARE
    };

   // SoftVinilData sofviData;


    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Drop()
    {
        int tmp = Random.Range(0, 100);

        if (dropRate < tmp) return;//落ちるか判定

        tmp = Random.Range(0, 100);

        for (int i = 0; i < rarityRate.Length; i++)
        {
            if (tmp < rarityRate[i])//落ちるレアリティ判定
            {
                GameObject tmpOBJ = dropOBJ[i].objType[0];  //一旦0で決め打ち
                Vector3 dropPosition = transform.root.position; // 敵の親のワールド座標を取得
                GameObject droppedItem = Instantiate(tmpOBJ, dropPosition, Quaternion.identity); // ここで位置を指定して生成
                if (droppedItem.GetComponent<softVinyl>().SofviData==null)
                {
                    droppedItem.GetComponent<softVinyl>().SofviData = new SoftVinilData();
                }
                droppedItem.GetComponent<softVinyl>().SofviData.rarity = (SoftVinilData.Raritynum)(i+1);//自分のレア度を記憶
                SetStatusRandom(droppedItem.GetComponent<softVinyl>().SofviData);
                Debug.Log((SoftVinilData.Raritynum)(i + 1));
                Debug.Log(tmp);
                Debug.Log(i);

                droppedItem.GetComponent<softVinyl>().SofviData.sofvimodel = (SoftVinilData.SOFVINUMBER)(i + 1);

                return;
            }
        }
    }

    void SetStatusRandom(SoftVinilData sofviData)
    {
        InitStatus(sofviData);//ステータス初期化

        //メインステ
        sofviData.buffMainstatus = (SoftVinilData.BUFFSTATUSNUM)Random.Range((float)SoftVinilData.BUFFSTATUSNUM.POWER, (float)SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA);
        //メインステ　追加値
        sofviData.BuffMainParameter = setRarityStatus[(int)sofviData.rarity - 1][(int)sofviData.buffMainstatus - 1];

        //サブステ１
        sofviData.buffSubstatus1 = (SoftVinilData.BUFFSTATUSNUM)Random.Range((float)SoftVinilData.BUFFSTATUSNUM.POWER, (float)SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA);
        //サブステ１　追加値
        sofviData.BuffSubParameter1 = setRarityStatus[(int)sofviData.rarity - 1][(int)sofviData.buffSubstatus1 - 1];

        if ((int)sofviData.rarity == 1) return; //Normalならサブステ1個

        //サブステ2
        sofviData.buffSubstatus2 = (SoftVinilData.BUFFSTATUSNUM)Random.Range((float)SoftVinilData.BUFFSTATUSNUM.POWER, (float)SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA);
        //サブステ2 　追加値
        sofviData.BuffSubParameter2 = setRarityStatus[(int)sofviData.rarity - 1][(int)sofviData.buffSubstatus2 - 1];

        if ((int)sofviData.rarity == 2) return; //レアならサブステ2個

        //サブステ3
        sofviData.buffSubstatus3 = (SoftVinilData.BUFFSTATUSNUM)Random.Range((float)SoftVinilData.BUFFSTATUSNUM.POWER, (float)SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA);
        //サブステ3 　追加値
        sofviData.BuffSubParameter3 = setRarityStatus[(int)sofviData.rarity - 1][(int)sofviData.buffSubstatus3 - 1];

        //スーパーレアならサブステ3個
    }

    //ステータス初期化
    void InitStatus(SoftVinilData sofviData)
    {
        sofviData.buffMainstatus = SoftVinilData.BUFFSTATUSNUM.NULL;
        sofviData.buffSubstatus1 = SoftVinilData.BUFFSTATUSNUM.NULL;
        sofviData.buffSubstatus2 = SoftVinilData.BUFFSTATUSNUM.NULL;
        sofviData.buffSubstatus3 = SoftVinilData.BUFFSTATUSNUM.NULL;

        sofviData.BuffMainParameter = 0;
        sofviData.BuffSubParameter1 = 0;
        sofviData.BuffSubParameter2 = 0;
        sofviData.BuffSubParameter3 = 0;
    }

}
