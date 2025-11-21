using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static softVinyl;
using static UnityEngine.Mesh;

/// <summary>
/// ソフビを「設置位置」に配置・プレビュー・確定する
/// </summary>
public class SetSofviManeger : MonoBehaviour
{
    
    [Header("設置場所のソフビデータ")]      public List<softVinyl>   setSoftVinylData;
    [Header("設置場所のスクリプト")]        public List<Setposition3d> setposition3Ds;

    [Header("選択中ソフビデータ参照")]      public softVinyl selectSoftVinylData;
    [Header("プレイヤーステータス参照")]    public PlayerStatus_Script PlayerStatus_Script;
    [Header("全ての設置場所の親オブジェ")]  public GameObject AllSetobject;
    [Header("設置シーンカメラ（自動で設定されます）")]
    public Camera cam;


    public GameObject selectSofviOBJ;//選択中のソフビデータオブジェ
    public softVinyl selectSofviDeta;//選択中のソフビデータ
    private int MAXSETPOSITION = 6;
    public Ray ray;//カメラから飛ばすレイ
    void Start()
    {
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();
        setpotionDataSet();
        PlayerStatus_Script= GameObject.Find("Player").GetComponent<PlayerStatus_Script>();//  直接名前検索しているのでプレイヤーobjの名前が変わるとここも変更させる
    }
    // Update is called once per frame
    void Update()
    {
        setSofuvi();
        SofviPreview();
    }

    public void addSetPotiionSofviData(softVinyl softVinyldata,Setposition3d setposition3D)
    {
        setSoftVinylData.Add(softVinyldata);
        setposition3Ds.Add(setposition3D);
    }

    void setpotionDataSet()
    {
        setSoftVinylData.Clear();
        setposition3Ds.Clear();

        for (int i = 0; i < AllSetobject.transform.childCount; i++)
        {
            GameObject child = AllSetobject.transform.GetChild(i).gameObject;
            softVinyl softvinyl = child.GetComponent<softVinyl>();
            Setposition3d setpos = child.GetComponent<Setposition3d>();

            if (softvinyl != null && setpos != null)
            {
                setpos.setpotionNumber = i;
                addSetPotiionSofviData(softvinyl, setpos);
            }
        }
    }
    void SofviPreview()
    {
        if (selectSofviDeta.selectCheck)//ソフビがセレクトされていたら
        {
           
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);//レイを飛ばす
            RaycastHit hit;//レイに当たったまたオブジェクトのデータの保存先

            if (Physics.Raycast(ray, out hit))//レイに当たっている時
            {
                if (hit.transform.tag == "SetPosition" && hit.collider.GetComponent<Setposition3d>().checkmodelset == false)//セットポジションに当たっているかつ何も置かれていない場合
                {
                    if (hit.collider.GetComponent<Setposition3d>().translucentflg == false)//もし半透明表示がされていなけらば半透明ソフビを生成
                    {
                        softVinyl softVinylTest;
                        softVinylTest = hit.collider.GetComponent<softVinyl>();
                        softVinylTest = selectSofviDeta;//セレクト中のソフビデータを設置場所に渡す。表示モデルのデータが入っているため。
                        hit.collider.GetComponent<Setposition3d>().TranslucentSofviIns();//半透明モデルのインスタンス関数をよびだし
                    }

                    hit.collider.GetComponent<Setposition3d>().rathit = true;//レイが当たってる判定をtrue
                    for (int i = 0; i < MAXSETPOSITION; i++)//レイの当たっていない場所の判定をfalseに
                    {
                        if (hit.collider.GetComponent<Setposition3d>().setpotionNumber == i) continue;
                        setposition3Ds[i].rathit = false;

                    }

                }
                else//レイがどこの設置場所にもあたっていない場合はすべでのレイの当たった判定をfalse
                {
                    for(int i=0;i< MAXSETPOSITION;i++)
                    {

                        setposition3Ds[i].rathit = false;

                    }
                }

            }
        }

    }
   
    void setSofuvi()

    {
        if(selectSofviDeta.selectCheck&& Input.GetMouseButtonDown(0))//ソフビ選択されてたらかつ左クリック時
        {
           
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);//レイ飛ばす
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "SetPosition")//レイが当たったオブジェクトへアクセスかつ設置場所だったら
            {
                hit.collider.GetComponent<Setposition3d>().checkmodelset =true;//設置場所の設置判定をtrue
            }
  
        }
    }
    // ---------------------------------------------
    // ステータス追加関数（switch を1箇所に集約）
    // ---------------------------------------------
    private void AddStatusValue(softVinyl.BUFFSTATUSNUM type, int value)
    {
        switch (type)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                PlayerStatus_Script.add_Player_Attack_Power += value; break;

            case softVinyl.BUFFSTATUSNUM.MAXHP:
                PlayerStatus_Script.add_Player_MaxHealth += value; break;

            case softVinyl.BUFFSTATUSNUM.SKILL_CHARGE:
                PlayerStatus_Script.add_Player_Skill_Charge += value; break;

            case softVinyl.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                PlayerStatus_Script.add_player_stamina_recovery_speed += value; break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                PlayerStatus_Script.add_Player_MaxSutamina += value; break;

        }
    }

   
    public void statusup()
    {
        // ステータスをリセット
        PlayerStatus_Script.add_Player_Attack_Power = 0;
        PlayerStatus_Script.add_Player_MaxHealth = 0;
        PlayerStatus_Script.add_player_stamina_recovery_speed = 0;
        PlayerStatus_Script.add_Player_MaxSutamina = 0;
        PlayerStatus_Script.add_Player_Skill_Charge = 0;

        for (int i = 0; i < MAXSETPOSITION; i++)
        {
            if (!setSoftVinylData[i].checksetpotion) continue;

            softVinyl data = setSoftVinylData[i];

            // ---- メイン ----
            AddStatusValue(data.buffMainstatus, data.BuffMainParameter);

            // ---- サブをまとめて処理（配列化）----
            softVinyl.BUFFSTATUSNUM[] subStatusArray = new softVinyl.BUFFSTATUSNUM[3]
            {
            data.buffSubstatus1,
            data.buffSubstatus2,
            data.buffSubstatus3
            };

            int[] subValueArray = new int[3]
            {
            data.BuffSubparameter1,
            data.Buffparameter2,
            data.Buffparameter3
            };

            for (int j = 0; j < 3; j++)
            {
                AddStatusValue(subStatusArray[j], subValueArray[j]);
            }
        }
    }


  
    /// <summary>
    /// 現在選択中のソフビを破棄
    /// </summary>
    public void DeleteSelectedSofvi()
    {
        if (selectSoftVinylData.sofvimodel == SOFVINUMBER.NULL)
        {
            Debug.LogWarning("選択中のソフビが存在しません");
            return;
        }

        // ソフビ削除
        Debug.Log($"{selectSoftVinylData.ListNumber} を廃棄しました");
        sofviStrage.sofviStrageList[selectSoftVinylData.ListNumber].ResetParameter();
        sofviStrage.ListUpdate = true;//表示の更新
        // データ参照をクリア
        selectSofviDeta.ResetParameter();

    }
}
