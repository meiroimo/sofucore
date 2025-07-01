using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SlidePanelGeneratorScript))]
public class SlidePanelGeneratorEditorScript : Editor
{
    SerializedProperty panelPrefabProp;
    SerializedProperty panelCountProp;
    SerializedProperty parentProp;

    // OnEnable で初期化（Inspectorを開いた時に呼ばれる）
    void OnEnable()
    {
        panelPrefabProp = serializedObject.FindProperty("panelPrefabOBJ");
        panelCountProp = serializedObject.FindProperty("panelCount");
        parentProp = serializedObject.FindProperty("parent");
    }

    public override void OnInspectorGUI()
    {
        // 最新状態に更新
        serializedObject.Update();

        // 通常のフィールド表示
        EditorGUILayout.PropertyField(panelPrefabProp);
        EditorGUILayout.PropertyField(parentProp);

        // panelCount が変化したかを検出
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(panelCountProp);
        if (EditorGUI.EndChangeCheck())
        {
            // 変更を確定
            serializedObject.ApplyModifiedProperties();

            // 実際にパネルを生成
            SlidePanelGeneratorScript generator = (SlidePanelGeneratorScript)target;
            generator.GeneratePanels();

            // シーンの変更をUnityに通知（保存対象にするため）
            EditorUtility.SetDirty(generator);
        }

        // ボタン：手動で生成
        if (GUILayout.Button("手動で生成"))
        {
            SlidePanelGeneratorScript generator = (SlidePanelGeneratorScript)target;
            generator.GeneratePanels();
        }

        // ボタン：削除
        if (GUILayout.Button("削除"))
        {
            SlidePanelGeneratorScript generator = (SlidePanelGeneratorScript)target;
            generator.ClearPanels();
        }

        // 最終的にすべてのプロパティ変更を確定
        serializedObject.ApplyModifiedProperties();

    }
}
