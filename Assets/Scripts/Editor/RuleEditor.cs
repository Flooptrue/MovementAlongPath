using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Rule))]
public class RuleEditor : Editor
{
    private SerializedProperty _sample;

    private void OnEnable()
    {
        _sample = serializedObject.FindProperty("_sample");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Spawn"))
        {
            Debug.Log("Spawn");
        }
    }
}