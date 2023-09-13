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
            // ���������, ��� ������, �������� � �������, ����� ��� "Player".

            // �������� ���������� � ������� ������.
            Scene currentScene = SceneManager.GetActiveScene();

            // ���� ��������� ������� �� ��� ��������.
            string nextLevelName = "Level " + (int.Parse(currentScene.name.Split(' ')[1]) + 1);

            // ��������� ��������� �������.
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
