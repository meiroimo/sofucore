using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [Header("�̗�")]
    public float maxHP;
    private float currentHP;
    EnemyStatus_Script enemyStatus_Script;

    public Renderer enemyRenderer; // �G�̌�����
    private Color hitColor = Color.black; // ��e���̐F
    private float flashDuration = 0.2f; // �F���ς�鎞��
    private Color originalColor;
    private Material enemyMaterial;

    // ���S�C�x���g�i���X�N���v�g�ƘA�g�ł���j
    public event System.Action OnDeath;

    [SerializeField] TreasureChestDropScript dropScript;


    //20250621 kome�ύX�_
    sofviStrage sofviStrageScript;//�X�g���[�W�X�N���v�g
    public softVinyl softVinyldata;//�h���b�v����\�t�r�f�[�^
    private void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        if (enemyRenderer != null)
        {
            // �}�e���A�����ʃC���X�^���X��
            enemyMaterial = enemyRenderer.material;
            originalColor = enemyMaterial.color;
        }
    }

    private void Start()
    {
        sofviStrageScript = GameObject.Find("Player_Storage").gameObject.GetComponent<sofviStrage>();
        softVinyldata = gameObject.transform.GetChild(0).gameObject.GetComponent<softVinyl>();
        maxHP = enemyStatus_Script.enemy_MaxHealth + 30;
        currentHP = maxHP;
        //Debug.Log(currentHP);
    }

    public void EnemtTakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} �� {damage} �_���[�W���󂯂��I �c��HP: {currentHP}");
        StartCoroutine(FlashColor());

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} �͓|���ꂽ�I");
        OnDeath?.Invoke(); // ���S�C�x���g�𔭉΁i�X�R�A���Z��G�t�F�N�g�Đ��Ȃǁj

        //rena�ǉ�
        dropScript.Drop();

        //kome�ύX�_

        //sofviStrageScript.addSofvi(softVinyldata);

        Destroy(gameObject); // �G�I�u�W�F�N�g������

    }

    /// <summary>
    /// ��u�����F��ς��Ė߂�
    /// </summary>
    IEnumerator FlashColor()
    {
        enemyMaterial.color = hitColor;
        yield return new WaitForSeconds(flashDuration);
        enemyMaterial.color = originalColor;
    }

}
