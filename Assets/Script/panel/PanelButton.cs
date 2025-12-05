using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private GameObject TextWindowManegerObj;//パネルイメージOBJ
    [SerializeField] private TextWindow TextWindowManegerSc;//パネルイメージ

    [SerializeField] private GameObject PanelImageobj;//パネルイメージOBJ
    [SerializeField] private Image PanelImage;//パネルイメージ

    public softVinyl SetSofvidata;//設置ソフビデータ

    [SerializeField] private GameObject selectSofviOBJ;//選択中のソフビデータオブジェ
    [SerializeField] private softVinyl selectSofviDeta;//選択中のソフビデータ
    private Outline outline;

    private bool selectPanel;//パネルを選択判定 
    public int Number;//ボタン番号
    [SerializeField] private GameObject ImgStrage;//イメージ画像ストレージスクリプト
    private ImgStrageScript ImgStrageScriptdata;//イメージ画像データストレージ

    [SerializeField] private GameObject SelectTextObj;//セレクトソフビのテキストオブジェクト
    [SerializeField] private SelectText SelectTextSc;//セレクトソフビのクラス

    void Start()
    {
        SelectTextObj = GameObject.Find("SelectStetasText");
        SelectTextSc = SelectTextObj.GetComponent<SelectText>();
        TextWindowManegerObj = GameObject.Find("TextWindowManeger");
        TextWindowManegerSc = TextWindowManegerObj.GetComponent<TextWindow>();
        ImgStrage = GameObject.Find("ImgStrage");
        ImgStrageScriptdata = ImgStrage.GetComponent<ImgStrageScript>();
        selectSofviOBJ = GameObject.Find("selectSofvi");
        PanelImageobj = gameObject.transform.GetChild(0).gameObject;
        PanelImage = PanelImageobj.GetComponent<Image>();
        SetSofvidata = this.gameObject.GetComponent<softVinyl>();
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
        selectPanel = false;

    }

    void Update()
    {
        setImage();
        if (selectSofviDeta.SofviData.selectButton != this.gameObject)
        {
            selectPanel = false;
            outline.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)//マウスが重なったら
    {
        SelectTextSc.setText(SetSofvidata.SofviData);
        TextWindowManegerSc.OnHoverEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextWindowManegerSc.OnHoverExit();
    }
    public void onclickButton()
    {
        if(!selectPanel && SetSofvidata.SofviData.sofvimodel != SoftVinilData.SOFVINUMBER.NULL)
        {
            setselectSofviData();
            selectPanel = true;
            outline.enabled = true;
        }
        else
        {
            if (selectSofviDeta.SofviData.selectButton==this.gameObject)
            {
                Debug.Log("同じの押した");
                againClick();
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
        }
    }
    void againClick()//セレクトデータをリセット
    {
        //SoftVinilData nulldata = new SoftVinilData();
        //nulldata.ResetParameter();
        //selectSofviDeta.SofviData = nulldata;
         selectSofviDeta.SofviData= selectSofviDeta.SofviData.copy();
        selectSofviDeta.SofviData.ResetParameter();
        selectPanel = false;
        outline.enabled = false;
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
