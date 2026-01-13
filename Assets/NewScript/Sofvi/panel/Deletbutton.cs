using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletbutton : MonoBehaviour
{
    public bool is_deleteset = false;//削除の表示判定
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
    public void Closethiswindow()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
