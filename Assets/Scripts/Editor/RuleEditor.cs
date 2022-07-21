using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Rule))]
public class RuleEditor : Editor
{
    private SerializedProperty _sample;
    private SerializedProperty _container;

    private void OnEnable()
    {
        _sample    = serializedObject.FindProperty("_sample");
        _container = serializedObject.FindProperty("_container");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var rule = (Rule)target;
        if (GUILayout.Button("Spawn"))
        {
            var point     = rule.FindPoint();
            var container = (Transform)_container.objectReferenceValue;
            Instantiate(_sample.objectReferenceValue, point, Quaternion.identity, container);
        }
    }
}