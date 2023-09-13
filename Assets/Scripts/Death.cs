using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Проверяем, что объект, вошедший в триггер, имеет тег "Player".
            // Перезапускаем текущий уровень.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
