using System.IO;
using UnityEngine;

/// <summary>
/// プレイヤーのステータス情報などを JSON 形式で保存・読み込みするクラス
/// ゲーム全体で1つだけ存在するシングルトンとして動作する
/// </summary>
public class DataManager : MonoBehaviour
{
    // データマネージャーのインスタンス（どこからでもアクセス可能なように static にする）
    public static DataManager Instance;

    // 実際に保存・読み込むデータ構造体
    [HideInInspector] public SaveData data = new SaveData();

    // ファイルのパスとファイル名
    string filepath;
    string fileName = "Data.json";

    void Awake()
    {
        // シングルトンのインスタンスを1つだけに保つ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでもこのオブジェクトを破棄しない
        }
        else
        {
            Destroy(gameObject); // すでに存在するなら新しいのは削除
            return;
        }

        // 保存ファイルのパスを作成
        filepath = Application.dataPath + "/" + fileName;

        // ファイルが存在しなければ新規作成して保存（初期データ書き込み）
        if (!File.Exists(filepath))
        {
            Save(data);
        }

        // ファイルから保存データを読み込む
        data = Load(filepath);
    }

    /// <summary>
    /// SaveData を JSON に変換してファイルに保存する
    /// </summary>
    void Save(SaveData data)
    {
        if (string.IsNullOrEmpty(filepath))
        {
            Debug.LogWarning("Save skipped: file path is null.");
            return;
        }

        // SaveData → JSON（文字列）に変換、整形付き（true）
        string json = JsonUtility.ToJson(data, true);

        // JSON をファイルに書き込む
        File.WriteAllText(filepath, json);
    }

    /// <summary>
    /// 指定されたパスの JSON ファイルを読み込み、SaveData に変換して返す
    /// </summary>
    SaveData Load(string path)
    {
        // ファイルの中身を全て文字列として読み込む
        string json = File.ReadAllText(path);

        // 読み込んだ JSON をデバッグ表示
        Debug.Log("読み込んだJSON: " + json);

        // JSON → SaveData に変換して返す
        return JsonUtility.FromJson<SaveData>(json);
    }

    /// <summary>
    /// ゲーム終了時やオブジェクトが破棄される時に、データを保存
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
