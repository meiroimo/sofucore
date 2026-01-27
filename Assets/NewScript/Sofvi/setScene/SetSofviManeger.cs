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

    //==============================
    // UI / 管理クラス
    //==============================
    public GameObject SofviDeleteButton;
    public Deletbutton DeletbuttonSc;
    public ScreenSwitchManager ScreenSwitchManagerSc;

    [Header("テキストウィンドウクラス")] public TextWindow TextWindowManegerSc;//テキストウィンドウクラス

    [Header("通常テキストウィンドウ")]
    public TextWindow TextWindowManegerSc_copy;

    [Header("比較用テキストウィンドウ")]
    public ComparrisonTextWindow ComTextmgSc;

    [Header("テキスト設定クラス")]
    public SelectText SelectTextSc;
    public ComparsionText ComTextSc;

    //==============================
    // データ関連
    //==============================
    [Header("設置済みソフビ")]
    public List<softVinyl> setSoftVinylData;
    public List<Setposition3d> setposition3Ds;

    [Header("選択中ソフビ")]
    public GameObject selectSofviOBJ;
    public softVinyl selectSofviDeta;

    public PlayerStatus_Script PlayerStatus_Script;
    public PlayerController PlayerControllerSc;

    [Header("設置場所親")]
    public GameObject AllSetobject;

    public Camera cam;

    private const int MAXSETPOSITION = 6;


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
        // マウス位置からレイを飛ばす
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // レイが何かに当たった場合のみ処理
        if (!Physics.Raycast(ray, out hit)) return;

        // SetPositionかどうか
        bool isSetPosition = hit.transform.CompareTag("SetPosition");

        // よく使うコンポーネントを取得
        Setposition3d setPos = isSetPosition ? hit.collider.GetComponent<Setposition3d>() : null;
        softVinyl hitSofvi = hit.collider.GetComponent<softVinyl>();

        // ================================
        // ソフビを「選択中」の場合
        // ================================
        if (selectSofviDeta.SofviData.selectCheck)
        {
            // --- 未設置の設置場所にカーソルが乗っている場合 ---
            bool canPreview =
                isSetPosition &&
                setPos != null &&
                !setPos.checkmodelset &&                          // まだ何も置かれていない
                !hitSofvi.SofviData.checksetpotion &&             // 設置済みソフビではない
                selectSofviDeta.SofviData.selectButton != hit.collider;

            if (canPreview)
            {
                // 半透明モデルがまだなら生成
                if (!setPos.translucentflg)
                {
                    setPos.TranslucentSofviIns();
                }

                // 今レイが当たっている設置場所を true
                setPos.rathit = true;

                // それ以外の設置場所は false
                for (int i = 0; i < MAXSETPOSITION; i++)
                {
                    if (setPos.setpotionNumber == i) continue;
                    setposition3Ds[i].rathit = false;
                }
            }
            // --- ソフビ選択中 ＆ 設置済みの場所にポインタが当たった場合 ---
            else if (
                isSetPosition &&
                hitSofvi.SofviData.checksetpotion &&   // 設置済み
                selectSofviDeta.SofviData.selectCheck  // 何かしらソフビを選択中
                && hitSofvi.gameObject!=selectSofviDeta.SofviData.selectButton
            )
            {
                // 選択中ソフビと設置済みソフビのステータス比較表示
                SelectTextSc.setText(hitSofvi.SofviData);
                TextWindowManegerSc_copy.OnHoverEnter();

                ComTextSc.setText(selectSofviDeta.SofviData);//選択中のステータスを表示
                ComTextmgSc.OnHoverEnter();
            }

            // --- 設置済みソフビ ＆ スタンドソフビ選択中の場合 ---
            else if (
                isSetPosition &&
                hitSofvi.SofviData.checksetpotion &&
                selectSofviDeta.SofviData.isSelectStandSofvi
            )
            {
                // ステータス比較用テキスト表示
                SelectTextSc.setText(hitSofvi.SofviData);
                TextWindowManegerSc_copy.OnHoverEnter();
            }
            // --- どの設置場所にも当たっていない場合 ---
            else
            {
                for (int i = 0; i < MAXSETPOSITION; i++)
                {
                    setposition3Ds[i].rathit = false;
                }

                TextWindowManegerSc_copy.OnHoverExit();
                ComTextmgSc.OnHoverExit();
            }
        }
        // ================================
        // ソフビ未選択 ＆ 設置済みソフビにカーソルが乗った場合
        // ================================
        else if (isSetPosition && hitSofvi.SofviData.checksetpotion)
        {
            SelectTextSc.setText(hitSofvi.SofviData);
            TextWindowManegerSc_copy.OnHoverEnter();
        }
        // ================================
        // それ以外（何にも当たっていない or 表示不要）
        // ================================
        else
        {
            TextWindowManegerSc_copy.OnHoverExit();
            ComTextmgSc.OnHoverExit();
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
           

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "SetPosition" && selectSofviDeta.SofviData.selectButton!=hit.collider.gameObject&& hit.collider.GetComponent<softVinyl>().SofviData.checksetpotion != true)//レイが当たったオブジェクトへアクセスかつ設置場所だったらかつ置かれていなかったら
            {
                hit.collider.GetComponent<Setposition3d>().checkmodelset =true;//設置場所の設置判定をtrue
            }
            else if (selectSofviDeta.SofviData.selectButton==hit.collider.gameObject)
            {
                //Debug.Log("設置したソフビをもう一回押した");
                selectSofviDeta.SofviData = selectSofviDeta.SofviData.copy();
                selectSofviDeta.SofviData.ResetParameter();
                ComTextmgSc.OnHoverExit();

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


            case SoftVinilData.BUFFSTATUSNUM.ATTACK_RANGE:
                PlayerStatus_Script.add_player_Attack_Range += value; break;

            case SoftVinilData.BUFFSTATUSNUM.AVOIDANCE_DISTANCE:
                PlayerStatus_Script.add_player_Avoidance_Distance += value; break;

            case SoftVinilData.BUFFSTATUSNUM.SKILL_POWER_MULTIPLIER:
                PlayerStatus_Script.add_player_Skill_Power_Multiplier += value; break;
            //使ってないステータス
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
        PlayerStatus_Script.add_player_Skill_Power_Multiplier = 0;
        PlayerStatus_Script.add_player_Attack_Range = 0;
        PlayerStatus_Script.add_player_Avoidance_Distance = 0;
        //使ってないステータス
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
        if (selectSofviDeta.SofviData.sofvimodel ==  SoftVinilData.SOFVINUMBER.NULL)
        {
            Debug.LogWarning("選択中のソフビが存在しません");
            return;
        }

        // ソフビ削除
        if(!selectSofviDeta.SofviData.isSelectStandSofvi)
        {
            Debug.Log($"{selectSofviDeta.SofviData.ListNumber} を廃棄しました");
            sofviSotrage.sofviStrageList[selectSofviDeta.SofviData.ListNumber].ResetParameter();
            sofviSotrage.ListUpdate = true;//表示の更新
                                           // データ参照をクリア
            selectSofviDeta.SofviData.ResetParameter();

        }
        else
        {
            int resetpotionnum = selectSofviDeta.SofviData.selectButton.GetComponent<Setposition3d>().setpotionNumber;
            Destroy(AllSetobject.transform.GetChild(resetpotionnum).gameObject.transform.GetChild(1).gameObject);
            setSoftVinylData[resetpotionnum].SofviData.ResetParameter();
            statusup();
        }

    }
}
