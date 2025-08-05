using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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
                return;
            }
        }
    }
}
