using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTarget : MonoBehaviour
{


    public string floorTag = "Floor";
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(floorTag))
        {

            transform.position = teleportPoint.position;
        }
    }
}

