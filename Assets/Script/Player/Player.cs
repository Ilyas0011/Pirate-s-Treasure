using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraHolder _cameraHolder;

    private MovementController _movementController;
    private InputManager _inputManager;

    public void Start()
    {
        _movementController = GetComponent<MovementController>();
        _inputManager = ServiceLocator.Get<InputManager>();

        _inputManager.Move += _movementController.OnMove;
        _inputManager.Jump += _movementController.Jump;
        _inputManager.Look += _cameraHolder.RotateCamera;
    }

    private void OnDisable()
    {
        _inputManager.Move -= _movementController.OnMove;
        _inputManager.Jump -= _movementController.Jump;
        _inputManager.Look -= _cameraHolder.RotateCamera;
    }
}

