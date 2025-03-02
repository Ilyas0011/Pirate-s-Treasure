using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MovementController _movementController;

    public void Initialize()
    {
        _movementController = GetComponent<MovementController>();

      //  InputManager.Instance.Look += _movementController.OnMove;
        InputManager.Instance.Move += _movementController.OnMove;
        InputManager.Instance.Jump += _movementController.Jump;
    }
}

