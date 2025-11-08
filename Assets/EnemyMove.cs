using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public List<Transform> waypoints;
    public int waypointIndex;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {

        transform.position = Vector2.MoveTowards(transform.position,  waypoints[waypointIndex].position, moveSpeed* Time.deltaTime);

        if(transform.position == waypoints[waypointIndex].position )
        {
            waypointIndex++;
        }
    }
}
