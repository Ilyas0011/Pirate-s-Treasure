using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200f;  // ���������������� ����
    [SerializeField] private Transform playerTransform; // ��������� ������
    [SerializeField] private float headTiltAmount = 3f; // ���� ������� ������
    [SerializeField] private float headTiltSpeed = 5f;  // �������� ������� ������
    [SerializeField] private float returnSpeed = 2f;    // �������� ����������� ������ � �������� ���������

    private float rotateX;  // ������������ ���� ������
    private float rotateY;  // �������������� ���� ������
    private float targetTilt = 0f;  // ������� ���� ������� ������
    private float currentTilt = 0f; // ������� ���� ������� ������
    private Vector3 initialPosition;  // ��������� ������� ������
    private float previousRotationY;  // ���������� ���� �������� �� Y

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // ��������� ������
        initialPosition = transform.localPosition;  // ��������� ��������� ������� ������
        previousRotationY = playerTransform.eulerAngles.y;  // ��������� ��������� ���� ��������
    }

    void Update()
    {
        // �������� ���� ���� ��� ��������
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // ������������ �������� ������
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);

        // �������������� �������� ������
        playerTransform.Rotate(Vector3.up * mouseX);

        // ������ ������ ������� �� ����, � ����� ������� ������������ �����
        rotateY = playerTransform.eulerAngles.y;  // �������� ���� �������� ���������

        // ��������� ������� ����� ����� ������� � ���������� ���������
        float deltaRotationY = Mathf.DeltaAngle(previousRotationY, rotateY);

        // ���� �������� ������������ ������ ��� �����, ������ ������ ����������
        if (Mathf.Abs(deltaRotationY) > 0.1f)  // ��������, ���� �� �������� �������
        {
            // ��������� ����������� �������� (������ ��� �����)
            targetTilt = -Mathf.Sign(deltaRotationY) * headTiltAmount; // ������ ���� �������
        }
        else
        {
            // ���� �������� ���, ������ ������ ������������ � ����
            targetTilt = 0f;
        }

        // ������� ����������� �������
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * returnSpeed);

        // ��������� ������ ������
        transform.localRotation = Quaternion.Euler(rotateX, 0f, currentTilt);

        // ��������� ���������� ����
        previousRotationY = rotateY;
    }
}