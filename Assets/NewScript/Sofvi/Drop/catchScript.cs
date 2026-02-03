using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoftVinilData;
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
    string[] rarityTagName = {"null", "sofvi/Normal", "sofvi/Rare", "sofvi/superRare" };
    public PlayerSEBox PlayerSEBoxCrass;//SEボックス
    public PlayerController playerController;
    void Start()
    {
        catchSofvi = new int[4];
        catchTreasureChest = new int[4];
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        softVinyl sofvi = other.GetComponent<softVinyl>();
        if (sofvi != null && sofvi.isCaught) return;

        string objTagName = other.tag;
        //回収対象ではなければreturn
        if (!objTagName.Contains("box") && !objTagName.Contains("sofvi") && !objTagName.Contains("item")) return;

        if (objTagName.Contains("item"))
        {
            healItemScript itemScript = other.GetComponent<healItemScript>();
            playerController.HealHP(itemScript.heal);//一旦決め打ち
        }

        for (int i = 1; i < rarityTagName.Length; i++)
        {
            if (objTagName != rarityTagName[i]) continue;//レアリティが違うとcontinue
            //それぞれ対象の物をカウント
            if (objTagName.Contains("box"))
            {

                catchTreasureChest[i]++;
            }
            else
            {
                if (other.GetComponent<softVinyl>() != null)
                {
                    //拾うSEの再生
                    PlayerSEBoxCrass.PlayPlayerSE(PlayerSEBox.SENAME.ITEMGET);
                   
                    //ストレージリストに追加
                    for (int j = 0; j < sofviSotrage.MAXSofviCount; j++)//nullの場合データを挿入
                    {
                        if (sofviSotrage.sofviStrageList[j]==null || sofviSotrage.sofviStrageList[j].sofvimodel == SoftVinilData.SOFVINUMBER.NULL)
                        {
                            softVinyl DropSoftViny = other.GetComponent<softVinyl>();
                            DropSoftViny.isCaught = true;

                            SoftVinilData SeveStorageSofviData = DropSoftViny.SofviData;
                            sofviSotrage.sofviStrageList[j] = SeveStorageSofviData;
                            //リストの何番目かを記録
                            sofviSotrage.sofviStrageList[j].ListNumber = j;

                            catchSofvi[i]++;
                            PlayerStatusCache.SaveCatchSofviCount();

                            //カウントしたら消す
                            Destroy(other.gameObject);

                            break;
                        }
                    }
                }
                
            }

        }

    }

}
