using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathSceneTool))]
public class PathSceneToolEditor : Editor
{
    #region Refs

    private PathSceneTool _pathTool;
    private bool          _isSubscribed;

    #endregion

    #region Unity Methods

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        HandleChange();

        if (GUILayout.Button("Manual Update"))
        {
            UpdateManually();
        }
    }

    private void OnEnable()
    {
        _pathTool           =  (PathSceneTool)target;
        _pathTool.Destroyed += Unsubscribe;

        Subscribe();
        TriggerUpdate();
    }

    #endregion

    #region Logics

    private void HandleChange()
    {
        using var check = new EditorGUI.ChangeCheckScope();

        if (check.changed)
        {
            Subscribe();
            UpdateAutomatically();
        }
    }

    private void UpdateManually()
    {
        if (TriggerUpdate())
        {
            SceneView.RepaintAll();
        }
    }

    private bool TriggerUpdate()
    {
        var canUpdate = _pathTool.PathCreator != null;

        if (canUpdate)
        {
            _pathTool.TriggerUpdate();
        }

        return canUpdate;
    }

    private void UpdateAutomatically()
    {
        if (_pathTool.AutoUpdate)
        {
            TriggerUpdate();
        }
    }

    private void Unsubscribe()
    {
        if (_isSubscribed && _pathTool != null)
        {
            _pathTool.PathCreator.pathUpdated -= UpdateAutomatically;
            _isSubscribed                     =  false;
        }
    }

    private void Subscribe()
    {
        if (_isSubscribed == false && _pathTool.PathCreator != null)
        {
            _isSubscribed                     =  true;
            _pathTool.PathCreator.pathUpdated += UpdateAutomatically;
        }
    }

    #endregion
}