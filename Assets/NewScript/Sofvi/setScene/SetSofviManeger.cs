using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling.Memory.Experimental;
using static softVinyl;
using static UnityEngine.Mesh;

/// <summary>
/// ソフビを「設置位置」に配置・プレビュー・確定する
/// </summary>
public class SetSofviManeger : MonoBehaviour
{
    public GameObject SofviDeleteButton;//削除ボタンのオブジェクト
    public Deletbutton DeletbuttonSc;//削除ボタンスクリプト

    public ScreenSwitchManager ScreenSwitchManagerSc;//設置UI開いているかチェック
    [Header("テキストウィンドウクラス")] public TextWindow TextWindowManegerSc;//テキストウィンドウクラス
    [Header("テキストウィンドウクラス")] public TextWindow TextWindowManegerSc_copy;//テキストウィンドウクラス


    [Header("セレクトテキストクラス")] public SelectText SelectTextSc;//セレクトソフビテキストクラス


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
    public PlayerController PlayerControllerSc;//プレイヤーコントローラーのスクリプト
    void Start()
    {
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();
        setpotionDataSet();
        PlayerStatus_Script= GameObject.Find("Player").GetComponent<PlayerStatus_Script>();//  直接名前検索しているのでプレイヤーobjの名前が変わるとここも変更させる
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//左クリックされたら
        {
            setSofuvi();
        }
        if(Input.GetMouseButtonDown(1))//右クリックなら
        {


            if (ScreenSwitchManagerSc.SetFlg && !selectSofviDeta.SofviData.selectCheck)//選択中じゃなくて設置しているものをクリック
            {
                selectsetpotion_rightclick();//設置したソフビを選択する

            }
        }
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
           
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);//レイを飛ばす
            RaycastHit hit;//レイに当たったまたオブジェクトのデータの保存先

        if (Physics.Raycast(ray, out hit))//レイに当たっている時
        {
            if (selectSofviDeta.SofviData.selectCheck)//ソフビがセレクトされていたら
            {

                if (hit.transform.tag == "SetPosition" && hit.collider.GetComponent<Setposition3d>().checkmodelset == false && hit.collider.GetComponent<softVinyl>().SofviData.checksetpotion == false&& selectSofviDeta.SofviData.selectButton!= hit.collider)//セットポジションに当たっているかつ何も置かれていない場合
                {
                    if (hit.collider.GetComponent<Setposition3d>().translucentflg == false)//もし半透明表示がされていなけらば半透明ソフビを生成
                    {
                        hit.collider.GetComponent<Setposition3d>().TranslucentSofviIns();//半透明モデルのインスタンス関数をよびだし
                    }

                    hit.collider.GetComponent<Setposition3d>().rathit = true;//レイが当たってる判定をtrue
                    for (int i = 0; i < MAXSETPOSITION; i++)//レイの当たっていない場所の判定をfalseに
                    {
                        if (hit.collider.GetComponent<Setposition3d>().setpotionNumber == i) continue;
                        setposition3Ds[i].rathit = false;
                    }

                }
                else if(hit.transform.tag == "SetPosition"&& hit.collider.GetComponent<softVinyl>().SofviData.checksetpotion == true&&selectSofviDeta.SofviData.isSelectStandSofvi)
                {
                    SelectTextSc.setText(hit.collider.GetComponent<softVinyl>().SofviData);
                    TextWindowManegerSc_copy.OnHoverEnter();

                }
                else  //レイがどこの設置場所にもあたっていない場合はすべでのレイの当たった判定をfalse
                {
                    for (int i = 0; i < MAXSETPOSITION; i++)
                    {
                        setposition3Ds[i].rathit = false;
                        TextWindowManegerSc_copy.OnHoverExit();

                    }
                }
            }
            else if (hit.transform.tag == "SetPosition" && hit.collider.GetComponent<softVinyl>().SofviData.checksetpotion == true)//何も選択していない状態で設置されたソフビに重なっていたら
            {
                SelectTextSc.setText(hit.collider.GetComponent<softVinyl>().SofviData);
                TextWindowManegerSc_copy.OnHoverEnter();
            }
            else
            {
                TextWindowManegerSc_copy.OnHoverExit();
            }
        }
        
    }
    void selectsetpotion()//設置したソフビを選択する
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);//レイ飛ばす
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && selectSofviDeta.SofviData.selectButton != hit.collider.gameObject && hit.collider.gameObject.tag == "SetPosition" && hit.collider.GetComponent<softVinyl>().SofviData.checksetpotion == true)//レイが当たったオブジェクトへアクセスかつ設置場所だったら
        {
            Debug.Log("設置されたのが押されました");
            selectSofviDeta.SofviData = hit.collider.GetComponent<softVinyl>().SofviData;
            selectSofviDeta.SofviData.selectButton = hit.collider.gameObject;
            selectSofviDeta.SofviData.selectCheck = true;
            selectSofviDeta.SofviData.isSelectStandSofvi = true;
        }
    }

    void selectsetpotion_rightclick()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);//レイ飛ばす
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && selectSofviDeta.SofviData.selectButton != hit.collider.gameObject && hit.collider.gameObject.tag == "SetPosition" && hit.collider.GetComponent<softVinyl>().SofviData.checksetpotion == true)//レイが当たったオブジェクトへアクセスかつ設置場所だったら
        {
            Debug.Log("設置されたのが押されました");
            selectSofviDeta.SofviData = hit.collider.GetComponent<softVinyl>().SofviData;
            selectSofviDeta.SofviData.selectButton = hit.collider.gameObject;
            selectSofviDeta.SofviData.selectCheck = true;
            selectSofviDeta.SofviData.isSelectStandSofvi = true;
            DeletbuttonSc.OpenButton();//削除ボタンを開く
            TextWindowManegerSc.deleteButton_potion_set();//削除ボタンをマウスの位置に変更

        }



    }

    void setSofuvi()

    {
        if(selectSofviDeta.SofviData.selectCheck)//ソフビ選択されてたら
        {
           
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);//レイ飛ばす
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "SetPosition" && selectSofviDeta.SofviData.selectButton!=hit.collider.gameObject)//レイが当たったオブジェクトへアクセスかつ設置場所だったら
            {
                hit.collider.GetComponent<Setposition3d>().checkmodelset =true;//設置場所の設置判定をtrue
            }
            else if(selectSofviDeta.SofviData.selectButton==hit.collider.gameObject)
            {
                //Debug.Log("設置したソフビをもう一回押した");
                selectSofviDeta.SofviData = selectSofviDeta.SofviData.copy();
                selectSofviDeta.SofviData.ResetParameter();

            }
        }
        else if(ScreenSwitchManagerSc.SetFlg)//選択中じゃなくて設置しているものをクリック
        {
            selectsetpotion();
        }
    }
    // ---------------------------------------------
    // ステータス追加関数（switch を1箇所に集約）
    // ---------------------------------------------
    private void AddStatusValue(SoftVinilData.BUFFSTATUSNUM type, int value)
    {
        switch (type)
        {
            case SoftVinilData.BUFFSTATUSNUM.POWER:
                PlayerStatus_Script.add_Player_Attack_Power += value; break;

            case SoftVinilData.BUFFSTATUSNUM.MAXHP:
                PlayerStatus_Script.add_Player_MaxHealth += value; break;

            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
                PlayerStatus_Script.add_Player_Skill_Charge += value; break;

            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                PlayerStatus_Script.add_player_stamina_recovery_speed += value; break;
            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
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
            if (!setSoftVinylData[i].SofviData.checksetpotion)
            {
              // Debug.Log("設置されているデータがない" + i + "番目");
                continue;
            }

            SoftVinilData data = setSoftVinylData[i].SofviData;

            // ---- メイン ----
            AddStatusValue(data.buffMainstatus, data.BuffMainParameter);

            // ---- サブをまとめて処理（配列化）----
            SoftVinilData.BUFFSTATUSNUM[] subStatusArray = new SoftVinilData.BUFFSTATUSNUM[3]
            {
            data.buffSubstatus1,
            data.buffSubstatus2,
            data.buffSubstatus3
            };
            int[] subValueArray = new int[3]
            {
            data.BuffSubParameter1,
            data.BuffSubParameter2,
            data.BuffSubParameter3
            };

            for (int j = 0; j < 3; j++)
            {
                AddStatusValue(subStatusArray[j], subValueArray[j]);
            }
        }
        PlayerStatus_Script.StatusUp();
        //コントローラースクリプトのの値を更新

        PlayerControllerSc.statusupdate();
    }


  
    /// <summary>
    /// 現在選択中のソフビを破棄
    /// </summary>
    public void DeleteSelectedSofvi()
    {
        if (selectSoftVinylData.SofviData.sofvimodel ==  SoftVinilData.SOFVINUMBER.NULL)
        {
            Debug.LogWarning("選択中のソフビが存在しません");
            return;
        }

        // ソフビ削除
        if(!selectSoftVinylData.SofviData.isSelectStandSofvi)
        {
            Debug.Log($"{selectSoftVinylData.SofviData.ListNumber} を廃棄しました");
            sofviSotrage.sofviStrageList[selectSoftVinylData.SofviData.ListNumber].ResetParameter();
            sofviSotrage.ListUpdate = true;//表示の更新
                                           // データ参照をクリア
            selectSofviDeta.SofviData.ResetParameter();

        }
        else
        {
            int resetpotionnum = selectSoftVinylData.SofviData.selectButton.GetComponent<Setposition3d>().setpotionNumber;
            Destroy(AllSetobject.transform.GetChild(resetpotionnum).gameObject.transform.GetChild(1).gameObject);
            setSoftVinylData[resetpotionnum].SofviData.ResetParameter();
            statusup();
        }

    }
}
