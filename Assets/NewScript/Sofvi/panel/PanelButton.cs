using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// ソフビ一覧の各ボタン
/// </summary>
public class PanelButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [Header("ソフビ一覧の各ボタンにソフビデータを入れるスクリプト")]

    [Header("比較用テキストウィンドウ")]
    public ComparrisonTextWindow ComTextmgSc;
    public ComparsionText ComTextSc;


    public GameObject SofviDeleteButton;//削除ボタンのオブジェクト
    public Deletbutton DeletbuttonSc;//削除ボタンスクリプト

    public SetSofviManeger SetSofviManegerSc;
    public TextWindow TextWindowManegerSc;//テキストウィンドウクラス

    public Image PanelImage;//パネルイメージ

    public softVinyl SetSofvidata;//設置ソフビデータ

    public softVinyl selectSofviDeta;//選択中のソフビデータ

    public bool selectPanel;//パネルを選択判定 
    public int Number;//ボタン番号
    public ImgStrageScript ImgStrageScriptdata;//イメージ画像データストレージ

    public SelectText SelectTextSc;//セレクトソフビテキストクラス

    public Image frameImage;//アイコンフレームの画像

    public GameObject[] starImages;//レア度表示の星
    void Start()
    {
        selectPanel = false;
        for (int i = 0; i < 3; i++)
        {
            starImages[i].SetActive(false);
        }

    }

    void Update()
    {
        setImage();
        if (selectSofviDeta.SofviData.selectButton != this.gameObject)
        {
            selectPanel = false;
            chengeframecolor(Color.white);
            //outline.enabled = false;
        }
    }
    public void chengeframecolor(Color newcolor)
    {
        frameImage.color = newcolor;

    }

    public void OnPointerEnter(PointerEventData eventData)//マウスが重なったら
    {
        //何もデータがなければ開かない
        if(SetSofvidata.SofviData.buffMainstatus!=SoftVinilData.BUFFSTATUSNUM.NULL)
        {
            TextWindowManegerSc.OnHoverEnter();
            SelectTextSc.setText(SetSofvidata.SofviData);
            if (selectSofviDeta.SofviData.selectCheck)//選択中だったら
            {
                ComTextSc.setText(selectSofviDeta.SofviData);//選択中のステータスを表示
                ComTextmgSc.OnHoverEnter();

            }

        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextWindowManegerSc.OnHoverExit();
        ComTextmgSc.OnHoverExit();

    }
    public void onclickButton()
    {
        //選択されていなくて、自分にデータがセットされてて、セレクトされている設置ソフビがない場合
        if(!selectPanel && SetSofvidata.SofviData.sofvimodel != SoftVinilData.SOFVINUMBER.NULL&&!selectSofviDeta.SofviData.isSelectStandSofvi)
        {

            //選択中じゃなかったら
            if( !selectSofviDeta.SofviData.selectCheck)
            {
                setselectSofviData();
                selectPanel = true;
                chengeframecolor(Color.yellow);
            }
            //選択中だったら
            else
            {
                setselectSofviData();
                selectPanel = true;
                chengeframecolor(Color.yellow);
                DeletbuttonSc.ClosethisButton();

            }
        }   
        //選択したボタンと同じボタンを押した
        else if(selectSofviDeta.SofviData.selectButton == this.gameObject)
        {
            Debug.Log("同じの押した");
            againClick();
        }
        //自分が空ボタンで設置中のソフビを選択している
        else if(SetSofvidata.SofviData.sofvimodel == SoftVinilData.SOFVINUMBER.NULL&& selectSofviDeta.SofviData.isSelectStandSofvi)
        {
            Debug.Log("設置したソフビをせんたくしたまま、空のボタンをクリックした");
            DeletbuttonSc.ClosethisButton();//削除ボタンを閉じる

            if (sofviSotrage.sofviStrageList[Number] == null || sofviSotrage.sofviStrageList[Number].sofvimodel == SoftVinilData.SOFVINUMBER.NULL)
            {
                softVinyl DropSoftViny = selectSofviDeta;

                SoftVinilData SeveStorageSofviData = DropSoftViny.SofviData;
                sofviSotrage.sofviStrageList[Number] = SeveStorageSofviData;
                //リストの何番目かを記録
                sofviSotrage.sofviStrageList[Number].ListNumber = Number;
                sofviSotrage.sofviStrageList[Number].isSelectStandSofvi = false;

                sofviSotrage.ListUpdate = true;
                int resetpotionnum = selectSofviDeta.SofviData.selectButton.GetComponent<Setposition3d>().setpotionNumber;
                Destroy(SetSofviManegerSc.AllSetobject.transform.GetChild(resetpotionnum).gameObject.transform.GetChild(1).gameObject);
                SetSofviManegerSc.setSoftVinylData[resetpotionnum].SofviData = SetSofviManegerSc.setSoftVinylData[resetpotionnum].SofviData.copy();
                SetSofviManegerSc.setSoftVinylData[resetpotionnum].SofviData.ResetParameter();
                SetSofviManegerSc.statusup();

                selectSofviDeta.SofviData = selectSofviDeta.SofviData.copy();
                selectSofviDeta.SofviData.ResetParameter();
                selectPanel = false;
                chengeframecolor(Color.white);

            }

        }
    }
    public void setImage()
    {
        //ソフビデータがなかった場合は×表示
        if (SetSofvidata == null)
        {
            PanelImage.sprite = ImgStrageScriptdata.sprites[0];
        }
        //表示している画像とデータの画像が違う場合に変更
        else if (PanelImage.sprite!= ImgStrageScriptdata.sprites[(int)SetSofvidata.SofviData.sofvimodel])
        {
            PanelImage.sprite = ImgStrageScriptdata.sprites[(int)SetSofvidata.SofviData.sofvimodel];
            for (int i = 0; i < 3; i++)
            {
                starImages[i].SetActive(false);
            }
            for (int i=0;i< (int)SetSofvidata.SofviData.rarity; i++)
            {
                starImages[i].SetActive(true);
            }
        }
    }
   public void againClick()//セレクトデータをリセット
    {
        DeletbuttonSc.ClosethisButton();//削除ボタンを閉じる
         selectSofviDeta.SofviData= selectSofviDeta.SofviData.copy();
        selectSofviDeta.SofviData.ResetParameter();
        selectPanel = false;
        chengeframecolor(Color.white);
    }
    public void setselectSofviData()//選択ソフビデータに自分のデータを渡す。
    {
        selectSofviDeta.SofviData = SetSofvidata.SofviData;

        //selectSofviDeta.SofviData.sofvimodel = SetSofvidata.SofviData.sofvimodel;
        //selectSofviDeta.SofviData.rarity = SetSofvidata.SofviData.rarity;
        //selectSofviDeta.SofviData.buffMainstatus = SetSofvidata.SofviData.buffMainstatus;
        //selectSofviDeta.SofviData.buffSubstatus1 = SetSofvidata.SofviData.buffSubstatus1;
        //selectSofviDeta.SofviData.buffSubstatus2 = SetSofvidata.SofviData.buffSubstatus2;
        //selectSofviDeta.SofviData.buffSubstatus3 = SetSofvidata.SofviData.buffSubstatus3;
        //selectSofviDeta.SofviData.ListNumber = SetSofvidata.SofviData.ListNumber;
        //selectSofviDeta.SofviData.BuffMainParameter = SetSofvidata.SofviData.BuffMainParameter;
        //selectSofviDeta.SofviData.BuffSubParameter1 = SetSofvidata.SofviData.BuffSubParameter1;
        //selectSofviDeta.SofviData.BuffSubParameter2 = SetSofvidata.SofviData.BuffSubParameter2;
        //selectSofviDeta.SofviData.BuffSubParameter3 = SetSofvidata.SofviData.BuffSubParameter3;
        selectSofviDeta.SofviData.selectButton = this.gameObject;
        selectSofviDeta.SofviData.selectCheck = true;
    }
}
