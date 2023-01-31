using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Input
{
    public class Movement : MonoBehaviour
    {
        public bool IsMoving { get; private set; }

        private void Update()
        {
            IsMoving = UnityInput.GetMouseButton(0);
        }
    }
}