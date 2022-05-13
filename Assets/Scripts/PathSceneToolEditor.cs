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
            if (_pathTool.PathCreator != null)
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

        if (_pathTool.PathCreator != null)
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
}