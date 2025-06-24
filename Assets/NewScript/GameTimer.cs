using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("���̖ڕW����(�b)")] public float spawnTime = 60;
    private float currentTime = 0f;
    public Text timerText;// �^�C�}�[�\���p

    public event Action OnTimeReached;

    private bool triggered = false;

    private PlayerController playerController;
    bool player_LifeOrdeath;//�v���C���[�������Ă邩
    bool clearFlg;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        float remainingTime = Mathf.Max(0f, spawnTime - currentTime);

        if (timerText != null)
        {
            timerText.text = "Time: " + remainingTime.ToString("F1") + "�b";
        }

        if (!triggered && currentTime >= spawnTime)
        {
            triggered = true;
            OnTimeReached?.Invoke();//�o�^���ꂽ�֐����Ăяo��
        }
    }

    /// <summary>
    /// ���U���g�V�[���ɑJ��
    /// </summary>
    private void GoToResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
