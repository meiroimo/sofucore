using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickEx : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("左クリック");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("右クリック");
        }
    }
}
