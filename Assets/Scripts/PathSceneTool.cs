using System;
using PathCreation;
using UnityEngine;

[ExecuteInEditMode]
public abstract class PathSceneTool : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] protected PathCreator _pathCreator;
    [SerializeField] protected bool        _autoUpdate = true;

    #endregion
    
    #region PublicAPI

    public event Action Destroyed;
    
    public void TriggerUpdate()
    {
        PathUpdated();
    }

    #endregion

    #region Logics

    protected VertexPath path => _pathCreator.path;
    
    protected virtual void OnDestroy()
    {
        if (Destroyed != null)
        {
            Destroyed();
        }
    }

    protected abstract void PathUpdated();

    #endregion
}