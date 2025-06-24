using System.IO;
using UnityEngine;

/// <summary>
/// �v���C���[�̃X�e�[�^�X���Ȃǂ� JSON �`���ŕۑ��E�ǂݍ��݂���N���X
/// �Q�[���S�̂�1�������݂���V���O���g���Ƃ��ē��삷��
/// </summary>
public class DataManager : MonoBehaviour
{
    // �f�[�^�}�l�[�W���[�̃C���X�^���X�i�ǂ�����ł��A�N�Z�X�\�Ȃ悤�� static �ɂ���j
    public static DataManager Instance;

    // ���ۂɕۑ��E�ǂݍ��ރf�[�^�\����
    [HideInInspector] public SaveData data = new SaveData();

    // �t�@�C���̃p�X�ƃt�@�C����
    string filepath;
    string fileName = "Data.json";

    void Awake()
    {
        // �V���O���g���̃C���X�^���X��1�����ɕۂ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł����̃I�u�W�F�N�g��j�����Ȃ�
        }
        else
        {
            Destroy(gameObject); // ���łɑ��݂���Ȃ�V�����͍̂폜
            return;
        }

        // �ۑ��t�@�C���̃p�X���쐬
        filepath = Application.dataPath + "/" + fileName;

        // �t�@�C�������݂��Ȃ���ΐV�K�쐬���ĕۑ��i�����f�[�^�������݁j
        if (!File.Exists(filepath))
        {
            Save(data);
        }

        // �t�@�C������ۑ��f�[�^��ǂݍ���
        data = Load(filepath);
    }

    /// <summary>
    /// SaveData �� JSON �ɕϊ����ăt�@�C���ɕۑ�����
    /// </summary>
    void Save(SaveData data)
    {
        if (string.IsNullOrEmpty(filepath))
        {
            Debug.LogWarning("Save skipped: file path is null.");
            return;
        }

        // SaveData �� JSON�i������j�ɕϊ��A���`�t���itrue�j
        string json = JsonUtility.ToJson(data, true);

        // JSON ���t�@�C���ɏ�������
        File.WriteAllText(filepath, json);
    }

    /// <summary>
    /// �w�肳�ꂽ�p�X�� JSON �t�@�C����ǂݍ��݁ASaveData �ɕϊ����ĕԂ�
    /// </summary>
    SaveData Load(string path)
    {
        // �t�@�C���̒��g��S�ĕ�����Ƃ��ēǂݍ���
        string json = File.ReadAllText(path);

        // �ǂݍ��� JSON ���f�o�b�O�\��
        Debug.Log("�ǂݍ���JSON: " + json);

        // JSON �� SaveData �ɕϊ����ĕԂ�
        return JsonUtility.FromJson<SaveData>(json);
    }

    /// <summary>
    /// �Q�[���I������I�u�W�F�N�g���j������鎞�ɁA�f�[�^��ۑ�
    /// </summary>
    private void OnDestroy()
    {
        Save(data);
    }

    public void SaveNow()
    {
        Save(data);
    }
}
