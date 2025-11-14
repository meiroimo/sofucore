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
                if (other.GetComponent<softVinyl>() != null)
                {
                    //ストレージリストに追加
                    for (int j = 0; j < sofviStrage.MAXSofviCount; j++)//nullの場合データを挿入
                    {
                        if (sofviStrage.sofviStrageList[j] == null)
                        {
                            GameObject enpty = new GameObject();
                            enpty.AddComponent<softVinyl>();
                             softVinyl softVinylSc = other.GetComponent<softVinyl>();
                            softVinyl softVinylSdata = enpty.GetComponent<softVinyl>();
                            softVinylSdata.sofvimodel = softVinylSc.sofvimodel;
                            softVinylSdata.skill = softVinylSc.skill;
                            softVinylSdata.theme = softVinylSc.theme;
                            softVinylSdata.ListNumber = softVinylSc.ListNumber;
                            softVinylSdata.buffSubstatus1 = softVinylSc.buffSubstatus1;
                            softVinylSdata.buffSubstatus2 = softVinylSc.buffSubstatus2;
                            softVinylSdata.buffSubstatus3 = softVinylSc.buffSubstatus3;
                            softVinylSdata.Buffparameter = softVinylSc.Buffparameter;
                            softVinylSdata.Buffparameter1 = softVinylSc.Buffparameter1;
                            softVinylSdata.Buffparameter2 = softVinylSc.Buffparameter2;
                            softVinylSdata.Buffparameter3 = softVinylSc.Buffparameter3;
                                
                            //リストの何番目かを記録
                            softVinylSdata.ListNumber = j;
                            Debug.Log(j);
                            Debug.Log(softVinylSdata);
                            sofviStrage.sofviStrageList[j] = softVinylSdata;
                            Debug.Log(sofviStrage.sofviStrageList[j]);
                            break;
                        }
                    }
                    // sofviStrage.sofviStrageList.Add(other.GetComponent<softVinyl>());

                }
                catchSofvi[i]++;
                PlayerStatusCache.SaveCatchSofviCount();
            }

            //カウントしたら消す
            Destroy(other.gameObject);
        }

    }
}
