using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Numerics;

/// <summary>
/// 現在選択中のソフビを廃棄するボタン制御
/// </summary>
public class SofviDeleteButton : MonoBehaviour
{
    [SerializeField] private SetSofviManeger sofviManager;

    public void OnDeleteClick()
    {
        if (sofviManager == null)
        {
            Debug.LogError("SetSofviManegerがアサインされていません");
            return;
        }

        sofviManager.DeleteSelectedSofvi();
    }
}
