using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200f;
    [SerializeField] private Transform playerTransform;

    private float _rotationY;
    private float _rotationX;

    void Start() => Cursor.lockState = CursorLockMode.Locked;
    public void RotateCamera(float mouseX, float mouseY)
    {
        _rotationX = mouseX;
        _rotationY -= mouseY;
        _rotationY = Mathf.Clamp(_rotationY, -90f, 90f);
    }

    void Update()
    {
        playerTransform.Rotate(Vector3.up * _rotationX);

        transform.localRotation = Quaternion.Euler(_rotationY, 0f, 0f);
    }
}