using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setposition : MonoBehaviour
{

    [Header("ソフビデータ")] public softVinyl setSoftVinylData ;
    [Header("選択中ソフビデータ参照")] public softVinyl selectSoftVinylData;
    [Header("プレイヤーステータス参照")] public PlayerStatus_Script PlayerStatus_Script;

    [SerializeField] public GameObject PanelImage;//パネルイメージ
    public sofviStrage sofviStrageOBJ;//ソフビストレージオブジェ
    bool checkSetDeta = false;
    public setWindow setWindowOBJ;
    public SofviVinylList SofviVinylListobj;
    bool checkBuffStatus;//強化ステータスの反映ができているか


    void Start()
    {
        checkBuffStatus = false;
        setSoftVinylData = gameObject.GetComponent<softVinyl>();
        
    }

    void Update()
    {
        if(checkSetDeta)
        {
            PanelImage.GetComponent<Image>().sprite = setSoftVinylData.sofviImage;
            if(!checkBuffStatus)
            {
                statusup();
            }
        }

    }
    //セレクト中のソフビデータを設置ソフビデータにセットする関数
   　public void setpositionsofviDeta()
    {
        if(selectSoftVinylData.selectCheck)
        {
            //setSoftVinylData = selectSoftVinylData;
            setSoftVinylData.skill = selectSoftVinylData.skill;
            setSoftVinylData.sofviImage = selectSoftVinylData.sofviImage;
            setSoftVinylData.theme = selectSoftVinylData.theme;
            setSoftVinylData.cost = selectSoftVinylData.cost;

            setSoftVinylData.buffMainstatus = selectSoftVinylData.buffMainstatus;
            setSoftVinylData.buffSubstatus1 = selectSoftVinylData.buffSubstatus1;
            setSoftVinylData.buffSubstatus2 = selectSoftVinylData.buffSubstatus2;
            setSoftVinylData.buffSubstatus3 = selectSoftVinylData.buffSubstatus3;

            setSoftVinylData.Buffparameter = selectSoftVinylData.Buffparameter;
            setSoftVinylData.Buffparameter1 = selectSoftVinylData.Buffparameter1;
            setSoftVinylData.Buffparameter2 = selectSoftVinylData.Buffparameter2;
            setSoftVinylData.Buffparameter3 = selectSoftVinylData.Buffparameter3;

            setSoftVinylData.buffName = selectSoftVinylData.buffName;
            setSoftVinylData.buffName1 = selectSoftVinylData.buffName1;
            setSoftVinylData.buffName2 = selectSoftVinylData.buffName2;
            setSoftVinylData.buffName3 = selectSoftVinylData.buffName3;
            setSoftVinylData.sofviName = selectSoftVinylData.sofviName;
            //設置されたリストのソフビデータの削除
            sofviStrageOBJ.deletelist(selectSoftVinylData.ListNumber);

            SofviVinylListobj.childrenPanelScript[selectSoftVinylData.ListNumber].selectCheck = false;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].skill = softVinyl.SKILLNUM.NULL;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].theme = softVinyl.themeNuｍ.NULL;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].sofviImage = null;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].cost = 0;

            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffMainstatus = softVinyl.BUFFSTATUSNUM.NULL;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffSubstatus1 = softVinyl.BUFFSTATUSNUM.NULL;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffSubstatus2 = softVinyl.BUFFSTATUSNUM.NULL;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffSubstatus3 = softVinyl.BUFFSTATUSNUM.NULL;

            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].Buffparameter = 0;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].Buffparameter1 = 0;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].Buffparameter2 = 0;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].Buffparameter3 = 0;

            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffName = null;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffName1 = null;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffName2 = null;
            SofviVinylListobj.childrensoftVinyl[selectSoftVinylData.ListNumber].buffName3 = null;


            selectSoftVinylData.skill = softVinyl.SKILLNUM.NULL;
            selectSoftVinylData.sofviImage = null;
            selectSoftVinylData.theme = softVinyl.themeNuｍ.NULL;
            selectSoftVinylData.cost = 0;

            selectSoftVinylData.buffMainstatus = softVinyl.BUFFSTATUSNUM.NULL;
            selectSoftVinylData.buffSubstatus1 = softVinyl.BUFFSTATUSNUM.NULL;
            selectSoftVinylData.buffSubstatus2 = softVinyl.BUFFSTATUSNUM.NULL;
            selectSoftVinylData.buffSubstatus3 = softVinyl.BUFFSTATUSNUM.NULL;

            selectSoftVinylData.Buffparameter = 0;
            selectSoftVinylData.Buffparameter1 = 0;
            selectSoftVinylData.Buffparameter2 = 0;
            selectSoftVinylData.Buffparameter3 = 0;

            selectSoftVinylData.buffName = null;
            selectSoftVinylData.buffName1 = null;
            selectSoftVinylData.buffName2 = null;
            selectSoftVinylData.buffName3 = null;

            selectSoftVinylData.selectCheck = false;
            setWindowOBJ.selectSofvibutton = null;
            checkSetDeta = true;
        }
      

    }


    /// <summary>
    /// ソフビのステータスアップの数値反映
    /// </summary>
    public void statusup()
    {
        //メインステータス反映
        switch (setSoftVinylData.buffMainstatus)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData.Buffparameter;
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                PlayerStatus_Script.add_Player_Defense += setSoftVinylData.Buffparameter;
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                PlayerStatus_Script.add_Player_Speed += setSoftVinylData.Buffparameter;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                PlayerStatus_Script.add_Player_Critical += setSoftVinylData.Buffparameter;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData.Buffparameter;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData.Buffparameter;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData.Buffparameter;
                break;
            default:
                break;

        }
        //サブ１ステータス反映
        switch (setSoftVinylData.buffSubstatus1)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData.Buffparameter1;
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                PlayerStatus_Script.add_Player_Defense += setSoftVinylData.Buffparameter1;
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                PlayerStatus_Script.add_Player_Speed += setSoftVinylData.Buffparameter1;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                PlayerStatus_Script.add_Player_Critical += setSoftVinylData.Buffparameter1;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData.Buffparameter1;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData.Buffparameter1;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData.Buffparameter1;
                break;
            default:
                break;

        }
        //サブ２ステータス反映
        switch (setSoftVinylData.buffSubstatus2)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData.Buffparameter2;
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                PlayerStatus_Script.add_Player_Defense += setSoftVinylData.Buffparameter2;
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                PlayerStatus_Script.add_Player_Speed += setSoftVinylData.Buffparameter2;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                PlayerStatus_Script.add_Player_Critical += setSoftVinylData.Buffparameter2;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData.Buffparameter2;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData.Buffparameter2;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData.Buffparameter2;
                break;
            default:
                break;

        }
        //サブ３ステータス反映
        switch (setSoftVinylData.buffSubstatus3)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                PlayerStatus_Script.add_Player_Attack_Power += setSoftVinylData.Buffparameter3;
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                PlayerStatus_Script.add_Player_Defense += setSoftVinylData.Buffparameter3;
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                PlayerStatus_Script.add_Player_Speed += setSoftVinylData.Buffparameter3;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                PlayerStatus_Script.add_Player_Critical += setSoftVinylData.Buffparameter3;
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                PlayerStatus_Script.add_Player_Critical_Damage += setSoftVinylData.Buffparameter3;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                PlayerStatus_Script.add_Player_MaxHealth += setSoftVinylData.Buffparameter3;
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                PlayerStatus_Script.add_Player_MaxSutamina += setSoftVinylData.Buffparameter3;
                break;
            default:
                break;

        }
        checkBuffStatus = true;

    }
}
