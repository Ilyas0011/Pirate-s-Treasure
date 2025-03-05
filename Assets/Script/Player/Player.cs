using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraHolder _cameraHolder;
    private MovementController _movementController;

    public void Initialize()
    {
        _movementController = GetComponent<MovementController>();

        InputManager.Instance.Move += _movementController.OnMove;
        InputManager.Instance.Jump += _movementController.Jump;
        InputManager.Instance.Look += _cameraHolder.RotateCamera;
    }

    private void OnDisable()
    {
        InputManager.Instance.Move -= _movementController.OnMove;
        InputManager.Instance.Jump -= _movementController.Jump;
        InputManager.Instance.Look -= _cameraHolder.RotateCamera;
    }
}

