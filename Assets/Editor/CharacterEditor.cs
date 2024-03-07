using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterSO))]
public class CharacterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Build"))
        {
            CharacterSO character = (CharacterSO)target;
            character.BuildCharacter();

            SerializedObject serializedObject = new SerializedObject(character);

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(character);

        }

    }
}
