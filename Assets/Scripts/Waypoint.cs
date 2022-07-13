using UnityEngine;

public class Waypoint : MonoBehaviour
{
    #region Construction

    private void Awake()
    {
        BitOfRoad = transform.GetComponentInParent<BitOfRoad>();
    }

    #endregion

    #region Public API

    public BitOfRoad BitOfRoad { get; private set; }

    public Vector3 Position => transform.position;

    #endregion
}