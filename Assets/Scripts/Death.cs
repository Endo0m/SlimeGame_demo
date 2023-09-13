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
            // ���������, ��� ������, �������� � �������, ����� ��� "Player".
            // ������������� ������� �������.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
