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

    public SetSofviManeger SetSofviManegerSc;
    public TextWindow TextWindowManegerSc;//テキストウィンドウクラス

    public Image PanelImage;//パネルイメージ

    public softVinyl SetSofvidata;//設置ソフビデータ

    public softVinyl selectSofviDeta;//選択中のソフビデータ

    private bool selectPanel;//パネルを選択判定 
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
        SelectTextSc.setText(SetSofvidata.SofviData);
        TextWindowManegerSc.OnHoverEnter();

        if (!selectSofviDeta.SofviData.isSelectStandSofvi/*&& selectSofviDeta.SofviData.sofvimodel!=SoftVinilData.SOFVINUMBER.NULL*/)
        {

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextWindowManegerSc.OnHoverExit();
    }
    public void onclickButton()
    {
        if(!selectPanel && SetSofvidata.SofviData.sofvimodel != SoftVinilData.SOFVINUMBER.NULL&&!selectSofviDeta.SofviData.isSelectStandSofvi)
        {
            setselectSofviData();
            selectPanel = true;
            chengeframecolor(Color.yellow);
        }
        else if(selectSofviDeta.SofviData.selectButton == this.gameObject)
        {
            {
                Debug.Log("同じの押した");
                againClick();
            }
        }
        else if(SetSofvidata.SofviData.sofvimodel == SoftVinilData.SOFVINUMBER.NULL&& selectSofviDeta.SofviData.isSelectStandSofvi)
        {
           // Debug.Log("設置したソフビをせんたくしたまま、空のボタンをクリックした");
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
    void againClick()//セレクトデータをリセット
    {
         selectSofviDeta.SofviData= selectSofviDeta.SofviData.copy();
        selectSofviDeta.SofviData.ResetParameter();
        selectPanel = false;
        chengeframecolor(Color.white);
    }
    private void setselectSofviData()//選択ソフビデータに自分のデータを渡す。
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
