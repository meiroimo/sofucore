using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static softVinyl;

public class PlayerAvoid_Script : MonoBehaviour
{
    private FlowerGuard2 testInputAction;//inputSystem
    private PlayerMove playerMove;
    private Rigidbody2D theRigidbody;
    private PlayerHealth playerHealth;

    public const int maxSt = 5;
    public float currentSt;
    public int bride;//�ő�HP���ܓ�������ϐ�
    public float timer;

    public float recoveryCount_ST;
    public float recoveryMaxCount_ST = 1;

    // �X���C�_�[�̎Q��
    public List<Slider> staminaSlider = new List<Slider>();

    //�X�L���̍Ĕ�������
    public int max1St = 1;
    private float[] current1St = new float[5];

    public float moveDistance = 7f;
    public float moveSpeed = 5f;

    private bool avoidFlg;
    Vector3 targetPos;
    Vector3 startPos;

    void Start()
    {
        testInputAction = new FlowerGuard2();
        testInputAction.Enable();

        playerMove = GetComponent<PlayerMove>();
        theRigidbody = GetComponent<Rigidbody2D>();
        
        playerHealth = GetComponent<PlayerHealth>();

        currentSt = maxSt;
        timer = 0;
        avoidFlg = false;
        // �����ݒ�
        for (int i = 0; i < staminaSlider.Count; i++)
        {
            current1St[i] = max1St; // �X�^�~�i���ő�l�ɐݒ�
            staminaSlider[i].maxValue = max1St; // �X���C�_�[�̍ő�l��ݒ�
            staminaSlider[i].value = current1St[i]; // ���݂̃X�^�~�i�𔽉f
        }

    }

    void Update()
    {
        recoveryCount_ST += Time.deltaTime;
        Avoid();
    }

    public void Avoid()
    {

        if (testInputAction.Player.Avoid.triggered && currentSt >= 1)
        {
            ProcessAvoid();
        }
        if (recoveryCount_ST > recoveryMaxCount_ST)
        {
            RecoveryAvoidSlider();
            recoveryCount_ST = 0;
        }
        if(avoidFlg)
        {
            MoveAvoid();
        }
    }

    public void ProcessAvoid()
    {
        currentSt -= 1;
        startPos = transform.position;
        targetPos = new Vector3(playerMove.MoveInput.x, playerMove.MoveInput.y, 0) * 3;
        StartCoroutine(ChangeColor());
        InitStSlider();
        avoidFlg = true;
    }

    public void MoveAvoid()
    {
        //float distance = Vector3.Distance(targetPos, transform.position);
        timer += Time.deltaTime;
        theRigidbody.velocity = targetPos * 5;//�v���C���[�̑��x�Ɉړ����͂𔽉f
        if (timer >= 0.2f)
        {
            timer = 0;
            avoidFlg = false;
            return;
        }
    }

    IEnumerator ChangeColor()
    {
        playerHealth.avoidFlg = true;
        GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 150);
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        playerHealth.avoidFlg = false;
    }

    public void RecoveryAvoidSlider()
    {
        if (currentSt == maxSt) return;
        currentSt += 0.2f;
        if(currentSt >= maxSt)
        {
            currentSt = maxSt;
        }
        InitStSlider();
    }


    /// <summary>
    /// �ő�ST���ܓ�������
    /// ST��UI���X�V
    /// </summary>
    public void InitStSlider()
    {
        int test = 0;
        bride = maxSt / staminaSlider.Count;
        test = (int)currentSt / bride;
        if(test != 5)
        {
            for (int i = 0; i < staminaSlider.Count; i++)
            {
                current1St[i] = 0;
                staminaSlider[i].value = 0;
            }

            for (int i = 0; i < test; i++)
            {
                current1St[i] = max1St;
                staminaSlider[i].value = max1St;
            }
            current1St[test] = (currentSt % bride) / bride;
            staminaSlider[test].value = current1St[test];
        }
        else
        {
            test -= 1;
            for (int i = 0; i < staminaSlider.Count; i++)
            {
                current1St[i] = 0;
                staminaSlider[i].value = 0;
            }

            for (int i = 0; i < test; i++)
            {
                current1St[i] = max1St;
                staminaSlider[i].value = max1St;
            }
            current1St[test] = 1;
            staminaSlider[test].value = current1St[test];
        }
    }

}
