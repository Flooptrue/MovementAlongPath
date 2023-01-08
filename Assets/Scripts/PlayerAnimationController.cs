using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private WaypointMover _mover;

    private static readonly int _isRunning = Animator.StringToHash("IsRunning");

    private void Update()
    {
        _animator.SetBool(_isRunning, _mover.IsMoving);
    }
}