using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChangeCharacter))]
public class ChangeCharacterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ChangeCharacter character = (ChangeCharacter)target;

        GUILayout.Space(10);
        GUILayout.Label("Skin Testing", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("◀ Previous"))
        {
            character.PreviousSkin();
            EditorUtility.SetDirty(character);
        }

        if (GUILayout.Button("Next ▶"))
        {
            character.NextSkin();
            EditorUtility.SetDirty(character);
        }

        GUILayout.EndHorizontal();
    }
}
