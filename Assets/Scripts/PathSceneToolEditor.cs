using PathCreation;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathSceneTool))]
public class PathSceneToolEditor : Editor
{
    #region Refs

    private PathSceneTool _pathTool;
    private bool          _isSubscribed;

    #endregion

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        HandleChange();

        if (GUILayout.Button("Manual Update"))
        {
            UpdateManually();
        }
    }

    private void HandleChange()
    {
        using var check = new EditorGUI.ChangeCheckScope();

        if (check.changed == false)
        {
            return;
        }

        if (_isSubscribed == false)
        {
            Subscribe();
        }

        UpdateAutomatically();
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

    private void OnEnable()
    {
        _pathTool           =  (PathSceneTool)target;
        _pathTool.Destroyed += OnToolDestroyed;

        Subscribe();
        TriggerUpdate();
    }

    private void OnToolDestroyed()
    {
        if (_pathTool != null)
        {
            _pathTool.PathCreator.pathUpdated -= UpdateAutomatically;
        }
    }

    private void Subscribe()
    {
        if (_pathTool.PathCreator != null)
        {
            _isSubscribed                     =  true;
            _pathTool.PathCreator.pathUpdated -= UpdateAutomatically;
            _pathTool.PathCreator.pathUpdated += UpdateAutomatically;
        }
    }
}