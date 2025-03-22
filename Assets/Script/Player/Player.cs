using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraHolder _cameraHolder;

    private MovementController _movementController;
    private AttackController _attackController;
    private InputManager _inputManager;
    
    public void Start()
    {
        _movementController = GetComponent<MovementController>();
        _inputManager = ServiceLocator.Get<InputManager>();
        _attackController = GetComponent<AttackController>();

        _inputManager.Move += _movementController.OnMove;
        _inputManager.Jump += _movementController.Jump;
        _inputManager.Look += _cameraHolder.RotateCamera;
        _inputManager.Slash += _attackController.SwordSlash;
    }

    private void OnDisable()
    {
        _inputManager.Move -= _movementController.OnMove;
        _inputManager.Jump -= _movementController.Jump;
        _inputManager.Look -= _cameraHolder.RotateCamera;
        _inputManager.Slash -= _attackController.SwordSlash;
    }
}

