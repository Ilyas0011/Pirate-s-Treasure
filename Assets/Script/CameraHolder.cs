using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200f;  // Чувствительность мыши
    [SerializeField] private Transform playerTransform; // Трансформ игрока
    [SerializeField] private float headTiltAmount = 3f; // Сила наклона головы
    [SerializeField] private float headTiltSpeed = 5f;  // Скорость наклона головы
    [SerializeField] private float returnSpeed = 2f;    // Скорость возвращения камеры в исходное положение

    private float rotateX;  // Вертикальный угол камеры
    private float rotateY;  // Горизонтальный угол камеры
    private float targetTilt = 0f;  // Целевой угол наклона камеры
    private float currentTilt = 0f; // Текущий угол наклона камеры
    private Vector3 initialPosition;  // Начальная позиция камеры
    private float previousRotationY;  // Предыдущий угол поворота по Y

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Блокируем курсор
        initialPosition = transform.localPosition;  // Сохраняем начальную позицию камеры
        previousRotationY = playerTransform.eulerAngles.y;  // Сохраняем начальный угол поворота
    }

    void Update()
    {
        // Получаем ввод мыши для вращения
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Вертикальное вращение камеры
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);

        // Горизонтальное вращение игрока
        playerTransform.Rotate(Vector3.up * mouseX);

        // Наклон головы зависит от того, в какую сторону поворачивает игрок
        rotateY = playerTransform.eulerAngles.y;  // Получаем угол поворота персонажа

        // Вычисляем разницу углов между текущим и предыдущим поворотом
        float deltaRotationY = Mathf.DeltaAngle(previousRotationY, rotateY);

        // Если персонаж поворачивает вправо или влево, наклон головы изменяется
        if (Mathf.Abs(deltaRotationY) > 0.1f)  // Проверка, есть ли заметный поворот
        {
            // Учитываем направление поворота (вправо или влево)
            targetTilt = -Mathf.Sign(deltaRotationY) * headTiltAmount; // меняем знак наклона
        }
        else
        {
            // Если поворота нет, наклон плавно возвращается в ноль
            targetTilt = 0f;
        }

        // Плавное возвращение наклона
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * returnSpeed);

        // Применяем наклон камеры
        transform.localRotation = Quaternion.Euler(rotateX, 0f, currentTilt);

        // Обновляем предыдущий угол
        previousRotationY = rotateY;
    }
}