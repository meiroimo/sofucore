using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [Header("遊び方画面")] public List<GameObject> tutorialPanel = new List<GameObject>();
    public Text pageText;

    [Header("ボタン")]
    public Button left_button;
    public Button right_button;
    private int imgCount;
    private int maxTutorialPanelNum;

    private void Start()
    {
        left_button.onClick.AddListener(ImageMoveLeft);
        right_button.onClick.AddListener(ImageMoveRight);

        imgCount = 0;
        maxTutorialPanelNum = tutorialPanel.Count;
        UpdatePageText();
    }

    private void Update()
    {
    }

    /// <summary>
    /// 右ボタンが押された時に呼び出す関数<br />
    /// 次の画像に入れ替える
    /// </summary>
    public void ImageMoveRight()
    {
        //audioSource.PlayOneShot(bookSE);
        //配列の最後にきたら配列[0]に戻す
        if (imgCount < maxTutorialPanelNum - 1)
        {
            tutorialPanel[imgCount].SetActive(false);
            imgCount += 1;
            tutorialPanel[imgCount].SetActive(true);
            Debug.Log(imgCount);
        }
        else
        {
            tutorialPanel[imgCount].SetActive(false);
            imgCount = 0;
            tutorialPanel[imgCount].SetActive(true);
        }

        UpdatePageText();
    }

    /// <summary>
    /// 左ボタンが押された時に呼び出す関数<br />
    /// 次の画像に入れ替える
    /// </summary>
    public void ImageMoveLeft()
    {
        //audioSource.PlayOneShot(bookSE);
        if (imgCount > 0)
        {
            tutorialPanel[imgCount].SetActive(false);
            imgCount -= 1;
            tutorialPanel[imgCount].SetActive(true);
            Debug.Log(imgCount);
        }
        else
        {
            tutorialPanel[imgCount].SetActive(false);
            imgCount = maxTutorialPanelNum - 1;
            tutorialPanel[imgCount].SetActive(true);
        }

        UpdatePageText();
    }

    private void UpdatePageText()
    {
        pageText.text = $"{imgCount+1}/{maxTutorialPanelNum}";
    }
}
