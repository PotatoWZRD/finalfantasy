using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject waypointManager;
    public List<Transform> waypoints;
    public int waypointIndex;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypointManager = GameObject.Find("Empties");
        waypoints = waypointManager.GetComponent<WaypointManager>().WaypointList;
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
        if (waypointIndex < waypoints.Count-1) 
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].position)
            {
                waypointIndex++;
            }

        }
    }
}
