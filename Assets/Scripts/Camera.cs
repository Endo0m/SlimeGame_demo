using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public float rotationSpeed = 2.0f;
    public float minVerticalAngle = -30.0f; // ����������� ���� ������ ����
    public float maxVerticalAngle = 60.0f;  // ������������ ���� ������ �����

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
        // �������� ���� �� ����
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // ��������� ���� �������� �� �����������
        currentRotationY += mouseX;
        currentRotationY %= 360;

        // ��������� ���� �������� �� ��������� � ������������ ���
        currentRotationX -= mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, minVerticalAngle, maxVerticalAngle);

        // ��������� ������� � ������
        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);

        // ��������� ������� � ������� ������ ������������ ������
        transform.position = playerTransform.position + rotation * offset;

        // ������� �� ������
        transform.LookAt(playerTransform.position);
    }
}
