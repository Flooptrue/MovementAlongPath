using UnityEditor;

[CustomEditor(typeof(Rule))]
public class RuleEditor : Editor
{
    private SerializedProperty _sample;

    private void OnEnable()
    {
        _sample = serializedObject.FindProperty("_sample");
    }
}