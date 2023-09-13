using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public float rotationSpeed = 2.0f;
    public float minVerticalAngle = -30.0f; // Минимальный угол обзора вниз
    public float maxVerticalAngle = 60.0f;  // Максимальный угол обзора вверх

    private Vector3 offset;
    private float currentRotationY = 0.0f;
    private float currentRotationX = 0.0f;

    private void Start()
    {
        offset = transform.position - playerTransform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Получаем ввод от мыши
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Обновляем угол поворота по горизонтали
        currentRotationY += mouseX;
        currentRotationY %= 360;

        // Обновляем угол поворота по вертикали и ограничиваем его
        currentRotationX -= mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, minVerticalAngle, maxVerticalAngle);

        // Применяем поворот к камере
        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);

        // Применяем поворот к позиции камеры относительно игрока
        transform.position = playerTransform.position + rotation * offset;

        // Смотрим на игрока
        transform.LookAt(playerTransform.position);
    }
}
