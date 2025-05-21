using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStatus_Script _status;

    private int num;

    //�v���C���[�̍ő�HP�ƌ��݂�HP
    public int maxHp;
    private float currentHp;

    public float debugRecoveryCount;
    //�X���C�_�[�̎Q��
    public Text hpText;

    public List<Image> hpImage = new List<Image>();
    [HideInInspector] public int testGetHp;
    public List<float> nowalpha = new List<float>();
    [HideInInspector] public float maxalpha;
    [HideInInspector] public int bride;//�ő�HP���ܓ�������ϐ�
    [HideInInspector] public bool avoidFlg;

    public float GetSetCurrentHp { get { return currentHp; } set { currentHp = value; } }

    public int Num { get => num; set => num = value; }

    private void Awake()
    {
        _status = GetComponent<PlayerStatus_Script>();
    }
    void Start()
    {
        maxalpha = 1;
        avoidFlg = false;

        for (int i = 0; i < hpImage.Count;i++)
        {
            if (hpImage[i] != null)
            {
                nowalpha.Add(maxalpha);
                hpImage[i].color = new Color(1, 1, 1, (byte)maxalpha);
            }
        }

        //�����ݒ�
        maxHp = (int)_status.player_MaxHealth;
        currentHp = maxHp; //HP���ő�l�ɐݒ�
        num = 5;
        Debug.Log(num);
    }

    void Update()
    {
        hpText.text = "HP:" + currentHp.ToString("f0") + "/" + maxHp.ToString("f0");
        TestHpBar();
    }

    /// <summary>
    /// �v���C���[�̗̑͂ւ̃_���[�W�v�Z
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (avoidFlg) return;
        damage = (damage * 0.5f) - (_status.player_Defense * 0.25f);//+
        if (damage <= 0) damage = Random.Range(0, 2);
        //HP�����炷����
        currentHp -= damage; 
        if (currentHp < 0) currentHp = 0;
        InitHpImage();

        //HP��0�ɂȂ����Ƃ��̏���
        if (currentHp == 0)
        {
            Debug.Log("�Q�[���I�[�o�[");
        }
    }

    /// <summary>
    /// �v���C���[�̗͉̑�
    /// </summary>
    /// <param name="damage"></param>
    public void RecoveryDamage(float damage)
    {
        //HP�����炷����
        currentHp += damage;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
            nowalpha[hpImage.Count - 1] = maxalpha;
        };
        //if (currentHp == maxHp) return;
        InitHpImage();

        //HP��0�ɂȂ����Ƃ��̏���
        if (currentHp == 0)
        {
            Debug.Log("�Q�[���I�[�o�[");
        }
    }

    private void TestHpBar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TakeDamage(150);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            //Debug.Log(num);
            RecoveryDamage(100);

            //RecoveryDamage(debugRecoveryCount);
        }
    }

    /// <summary>
    /// �ő�HP���ܓ�������
    /// HP��UI���X�V
    /// </summary>
    public void InitHpImage()
    {
        bride = maxHp / hpImage.Count;
        int test = (int)currentHp / bride;
        if (test != 5)
        {
            for (int i = 0; i < hpImage.Count; i++)
            {
                hpImage[i].color = new Color(1, 1, 1, 0);
                nowalpha[i] = 0;
            }

            for (int i = 0; i < test; i++)
            {
                hpImage[i].color = new Color(1, 1, 1, maxalpha);
                nowalpha[i] = maxalpha;
            }
            nowalpha[test] = (currentHp % bride) / bride;
            hpImage[test].color = new Color(1, 1, 1, nowalpha[test]);
        }
        else
        {
            test -= 1;
            for (int i = 0; i < hpImage.Count; i++)
            {
                hpImage[i].color = new Color(1, 1, 1, 0);
                nowalpha[i] = 0;
            }

            for (int i = 0; i < test; i++)
            {
                hpImage[i].color = new Color(1, 1, 1, maxalpha);
                nowalpha[i] = maxalpha;
            }
            nowalpha[test] = (currentHp % bride) / bride;
            hpImage[test].color = new Color(1, 1, 1, nowalpha[test]);
        }

        //HP�����^���ɂȂ�S�\��
        if(currentHp == maxHp)
        {
            for (int i = 0; i < hpImage.Count; i++)
            {
                hpImage[i].color = new Color(1, 1, 1, maxalpha);
                nowalpha[i] = maxalpha;
            }
        }

    }
}
