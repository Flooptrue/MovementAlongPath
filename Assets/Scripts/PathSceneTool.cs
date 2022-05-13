using System;
using PathCreation;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(PathCreator))]
public abstract class PathSceneTool : MonoBehaviour
{
    #region PublicAPI

    public event Action Destroyed;

    public void TriggerUpdate()
    {
        PathUpdated();
    }

    #endregion

    #region Construction

    private void Awake()
    {
        PathCreator = GetComponent<PathCreator>();
    }

    #endregion

    #region Logics

    public PathCreator PathCreator;

    public bool AutoUpdate = true;

    protected VertexPath Path => PathCreator.path;

    protected virtual void OnDestroy()
    {
        Destroyed?.Invoke();
    }

    protected abstract void PathUpdated();

    #endregion
}