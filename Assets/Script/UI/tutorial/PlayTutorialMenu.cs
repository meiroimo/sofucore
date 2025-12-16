using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTutorialMenu : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    private bool onTutorial = false;

    public bool OnTutorial { get => onTutorial; set => onTutorial = value; }

    private void Start()
    {
        tutorialPanel.SetActive(false);
    }

    public void OnTutorialLoad()
    {
        onTutorial = true;
        tutorialPanel.SetActive(true);
    }

    public void OffTutorialLoad()
    {
        onTutorial = false;
        tutorialPanel.SetActive(false);
    }

}
