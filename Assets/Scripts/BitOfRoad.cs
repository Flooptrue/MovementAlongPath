using UnityEngine;

public class BitOfRoad : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Direction _direction;

    #endregion

    #region Direction

    public enum Direction
    {
        Same,
        Reverse
    }

    #endregion
}