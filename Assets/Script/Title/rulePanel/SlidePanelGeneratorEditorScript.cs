using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SlidePanelGeneratorScript))]
public class SlidePanelGeneratorEditorScript : Editor
{
    SerializedProperty panelPrefabProp;
    SerializedProperty panelCountProp;
    SerializedProperty parentProp;

    // OnEnable �ŏ������iInspector���J�������ɌĂ΂��j
    void OnEnable()
    {
        panelPrefabProp = serializedObject.FindProperty("panelPrefabOBJ");
        panelCountProp = serializedObject.FindProperty("panelCount");
        parentProp = serializedObject.FindProperty("parent");
    }

    public override void OnInspectorGUI()
    {
        // �ŐV��ԂɍX�V
        serializedObject.Update();

        // �ʏ�̃t�B�[���h�\��
        EditorGUILayout.PropertyField(panelPrefabProp);
        EditorGUILayout.PropertyField(parentProp);

        // panelCount ���ω������������o
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(panelCountProp);
        if (EditorGUI.EndChangeCheck())
        {
            // �ύX���m��
            serializedObject.ApplyModifiedProperties();

            // ���ۂɃp�l���𐶐�
            SlidePanelGeneratorScript generator = (SlidePanelGeneratorScript)target;
            generator.GeneratePanels();

            // �V�[���̕ύX��Unity�ɒʒm�i�ۑ��Ώۂɂ��邽�߁j
            EditorUtility.SetDirty(generator);
        }

        // �{�^���F�蓮�Ő���
        if (GUILayout.Button("�蓮�Ő���"))
        {
            SlidePanelGeneratorScript generator = (SlidePanelGeneratorScript)target;
            generator.GeneratePanels();
        }

        // �{�^���F�폜
        if (GUILayout.Button("�폜"))
        {
            SlidePanelGeneratorScript generator = (SlidePanelGeneratorScript)target;
            generator.ClearPanels();
        }

        // �ŏI�I�ɂ��ׂẴv���p�e�B�ύX���m��
        serializedObject.ApplyModifiedProperties();

    }
}
