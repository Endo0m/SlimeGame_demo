using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public float speed = 5f;
    private bool forward = true;
    public float rotationSpeed = 2.0f;

    private void Start()
    {

        if (waypoints.Length > 0)
        {

            transform.position = waypoints[0].position;
        }
    }

    private void Update()
    {
        if (forward)
        {

            MoveToNextWaypoint();
        }
        else
        {

            MoveToPreviousWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {

        if (currentWaypointIndex >= waypoints.Length - 1)
        {

            forward = false;
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex + 1].position, speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(waypoints[currentWaypointIndex + 1].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            if (transform.position == waypoints[currentWaypointIndex + 1].position)
            {

                currentWaypointIndex++;
            }
        }
    }

    private void MoveToPreviousWaypoint()
    {

        if (currentWaypointIndex <= 0)
        {

            forward = true;
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex - 1].position, speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(waypoints[currentWaypointIndex - 1].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            if (transform.position == waypoints[currentWaypointIndex - 1].position)
            {

                currentWaypointIndex--;
            }
        }
    }
}