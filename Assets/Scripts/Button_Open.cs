using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Open : MonoBehaviour
{

    public GameObject uiElement; // ������ �� UI �������.
    public float raiseSpeed = 1f; // �������� �������� �������.

    private bool isPlayerInRange = false;
    private bool isOpening = false;
    private float initialYPosition;
    private float targetYPosition;

    private void Start()
    {
        uiElement.SetActive(false); // �������� UI ������� ��� ������.
        initialYPosition = transform.position.y;
        targetYPosition = initialYPosition + 4f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            uiElement.SetActive(true); // ���������� UI ������� ��� ����� � �������.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            uiElement.SetActive(false); // �������� UI ������� ��� ������ �� ��������.
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isOpening)
        {
            isOpening = true;
        }

        if (isOpening)
        {
            // ��������� ������ �� ��� Y � ����������� ���������.
            float newYPosition = Mathf.MoveTowards(transform.position.y, targetYPosition, raiseSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            if (transform.position.y >= targetYPosition)
            {
                isOpening = false;
            }
        }
    }
}

