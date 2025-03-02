using UnityEngine;
using UnityEngine.Windows;


public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private Transform _playerCamera;

    private CharacterController _characterController;
    private Vector3 _velocity;


    private Vector3 _movement;
    private Vector3 _moveDirection;

    void Awake() => _characterController = GetComponent<CharacterController>();
    public void OnMove(Vector3 movement) => _movement = movement;

    private void Update()
    {
        _moveDirection = _playerCamera.transform.TransformDirection(_movement);
        _moveDirection.y = 0f;

        if (_characterController.isGrounded)
        {
            if (_velocity.y < 0)
                _velocity.y = -2f;
        }
        else
            _velocity.y -= _gravity * Time.deltaTime;

        _characterController.Move(((_moveDirection * _moveSpeed) + _velocity) * Time.deltaTime);
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
            _velocity.y = Mathf.Sqrt(2f * _gravity * _jumpHeight);
    }
}
