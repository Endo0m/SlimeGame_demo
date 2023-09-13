using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Open : MonoBehaviour
{

    public GameObject uiElement; // Ссылка на UI элемент.
    public float raiseSpeed = 1f; // Скорость поднятия объекта.

    private bool isPlayerInRange = false;
    private bool isOpening = false;
    private float initialYPosition;
    private float targetYPosition;

    private void Start()
    {
        uiElement.SetActive(false); // Скрываем UI элемент при старте.
        initialYPosition = transform.position.y;
        targetYPosition = initialYPosition + 4f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            uiElement.SetActive(true); // Показываем UI элемент при входе в триггер.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            uiElement.SetActive(false); // Скрываем UI элемент при выходе из триггера.
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
            // Поднимаем объект по оси Y с постепенным открытием.
            float newYPosition = Mathf.MoveTowards(transform.position.y, targetYPosition, raiseSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            if (transform.position.y >= targetYPosition)
            {
                isOpening = false;
            }
        }
    }
}

