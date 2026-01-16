using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickEx : MonoBehaviour, IPointerClickHandler
{
    public TextWindow TextWindowSc;//テキストマネージャーのスクリプト
    public GameObject SofviDeleteButton;//削除ボタンオブジェクト
    public Deletbutton DeletbuttonSc;//削除ボタンスクリプト
    public PanelButton PanelButtonSc;
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("左クリック");
            PanelButtonSc.onclickButton();
        }
        //右クリック、空ボタンはクリック判定は取らない

        else if (!DeletbuttonSc.is_deleteset && eventData.button == PointerEventData.InputButton.Right && PanelButtonSc.SetSofvidata.SofviData.buffMainstatus != SoftVinilData.BUFFSTATUSNUM.NULL)
        {
            if (PanelButtonSc.selectSofviDeta.SofviData.selectCheck)//選択中だった場合
            {
                PanelButtonSc.againClick();//まず選択中だったものをリセットし右クリックした物を選択した状態にする
                PanelButtonSc.setselectSofviData();
                PanelButtonSc.selectPanel = true;
                PanelButtonSc.chengeframecolor(Color.yellow);
                Debug.Log("右クリック");
                SetdeleteButton();//削除ボタンを表示
            }
            else//選択中ではなかった場合
            {
                //右クリックしたボタンを選択中にする
                PanelButtonSc.setselectSofviData();
                PanelButtonSc.selectPanel = true;
                PanelButtonSc.chengeframecolor(Color.yellow);
                SetdeleteButton();//削除ボタンを表示

            }


        }
        else if (eventData.button == PointerEventData.InputButton.Right && DeletbuttonSc.is_deleteset)
        {
            DeletbuttonSc.ClosethisButton();//削除ボタンを閉じる        
        }
    }
    //削除ボタンを表示
    public void SetdeleteButton()
    {
        TextWindowSc.deleteButton_potion_set();//削除ボタンを位置調整
        DeletbuttonSc.OpenButton();//削除ボタンを開く        

    }
}
