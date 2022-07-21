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

        var rule = (Rule)target;
        if (GUILayout.Button("Spawn"))
        {
            var point = rule.FindPoint();
            Instantiate(_sample.objectReferenceValue, point, Quaternion.identity);
        }
    }
}