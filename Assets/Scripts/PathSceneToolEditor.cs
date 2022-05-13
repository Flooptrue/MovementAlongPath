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
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            DrawDefaultInspector();

            if (check.changed)
            {
                if (_isSubscribed == false)
                {
                    TryFindPathCreator();
                    Subscribe();
                }

                if (_pathTool.AutoUpdate)
                {
                    TriggerUpdate();
                }
            }
        }

        if (GUILayout.Button("Manual Update"))
        {
            if (TryFindPathCreator())
            {
                TriggerUpdate();
                SceneView.RepaintAll();
            }
        }
    }

    private void TriggerUpdate()
    {
        if (_pathTool.PathCreator != null)
        {
            _pathTool.TriggerUpdate();
        }
    }

    private void OnPathModified()
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

        if (TryFindPathCreator())
        {
            Subscribe();
            TriggerUpdate();
        }
    }

    private void OnToolDestroyed()
    {
        if (_pathTool != null)
        {
            _pathTool.PathCreator.pathUpdated -= OnPathModified;
        }
    }

    private void Subscribe()
    {
        if (_pathTool.PathCreator != null)
        {
            _isSubscribed                     =  true;
            _pathTool.PathCreator.pathUpdated -= OnPathModified;
            _pathTool.PathCreator.pathUpdated += OnPathModified;
        }
    }

    private bool TryFindPathCreator()
    {
        if (_pathTool.PathCreator == null)
        {
            if (_pathTool.GetComponent<PathCreator>() != null)
            {
                _pathTool.PathCreator = _pathTool.GetComponent<PathCreator>();
            }
            else if (FindObjectOfType<PathCreator>())
            {
                _pathTool.PathCreator = FindObjectOfType<PathCreator>();
            }
        }

        return _pathTool.PathCreator != null;
    }
}