using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickEx : MonoBehaviour, IPointerClickHandler
{
    public GameObject SofviDeleteButton;
    public PanelButton PanelButtonSc;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("左クリック");
            PanelButtonSc.onclickButton();
        }
        //右クリック、空ボタンはクリック判定は取らない
        else if (eventData.button == PointerEventData.InputButton.Right&& PanelButtonSc.SetSofvidata.SofviData.buffMainstatus != SoftVinilData.BUFFSTATUSNUM.NULL)
        {
            if(PanelButtonSc.selectSofviDeta.SofviData.selectCheck)//選択中だった場合
            {
                SofviDeleteButton.SetActive(false);//削除ボタンを非表示
                PanelButtonSc.againClick();//まず選択中だったものをリセットし右クリックした物を選択した状態にする
                PanelButtonSc.setselectSofviData();
                PanelButtonSc.selectPanel = true;
                PanelButtonSc.chengeframecolor(Color.yellow);
                Debug.Log("右クリック");
                SofviDeleteButton.SetActive(true);//削除ボタンを表示


            }
            else//選択中ではなかった場合
            {
                //右クリックしたボタンを選択中にする
                PanelButtonSc.setselectSofviData();
                PanelButtonSc.selectPanel = true;
                PanelButtonSc.chengeframecolor(Color.yellow);
                SofviDeleteButton.SetActive(true);//削除ボタンを表示


            }


        }
    }
}
