using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Проверяем, что объект, вошедший в триггер, имеет тег "Player".

            // Получаем информацию о текущем уровне.
            Scene currentScene = SceneManager.GetActiveScene();

            // Ищем следующий уровень по его названию.
            string nextLevelName = "Level " + (int.Parse(currentScene.name.Split(' ')[1]) + 1);

            // Загружаем следующий уровень.
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
