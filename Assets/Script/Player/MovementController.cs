using UnityEngine;


public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _jumpHeight = 2f;

    [SerializeField] private Transform _playerCamera;

    private CharacterController _characterController;

    private Vector3 _velocity;
    private Vector3 _movement;

    void Awake() => _characterController = GetComponent<CharacterController>();
    public void OnMove(float inputX, float inputY) => _movement = transform.right * inputX + transform.forward * inputY;

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            if (_velocity.y < 0)
                _velocity.y = -2f;
        }
        else _velocity.y -= _gravity * Time.deltaTime;

        _characterController.Move(((_movement + _velocity) * _moveSpeed * Time.deltaTime));
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
            _velocity.y = _jumpHeight;
    }
}
