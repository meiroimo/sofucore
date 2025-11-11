using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchScript : MonoBehaviour
{
    /*
     プレイヤーに貼り付ける
    　落ちたソフビ・宝箱を回収スクリプト

    回収したソフビ、宝箱はcatchSofvi、catchTreasureChestにレアリティごとにカウント
    要素数:
    0:SR 
    1:R
    2:N
     */
    //回収したソフビの数
    public int[] catchSofvi;
    //回収した宝箱の数
    public int[] catchTreasureChest;
    string[] rarityTagName = { "superRare", "Rare", "Normal" };
    void Start()
    {
        catchSofvi = new int[3];
        catchTreasureChest = new int[3];
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        string objTagName = other.tag;
        //回収対象ではなければreturn
        if (!objTagName.Contains("box") && !objTagName.Contains("sofvi")) return;

        for (int i = 0; i < rarityTagName.Length; i++)
        {
            if (!objTagName.Contains(rarityTagName[i])) continue;//レアリティが違うとcontinue

            //それぞれ対象の物をカウント
            if (objTagName.Contains("box"))
            {

                catchTreasureChest[i]++;
            }
            else
            {
                if(other.GetComponent<softVinyl>() != null)
                {
                    //リストの何番目かを記録
                    other.GetComponent<softVinyl>().ListNumber = sofviStrage.sofviStrageList.Count ;
                    //ストレージリストに追加
                    sofviStrage.sofviStrageList.Add(other.GetComponent<softVinyl>());
                   
                }
                catchSofvi[i]++;
                PlayerStatusCache.SaveCatchSofviCount();
            }

            //カウントしたら消す
            Destroy(other.gameObject);
        }

    }
}
