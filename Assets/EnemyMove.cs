using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum StartingPos 
{
    One,
    Two, 
    Three,
    Four,
    Five,
    Zero
}


public class EnemyMove : MonoBehaviour
{
    private GameObject waypointManager;
    public List<Transform> waypoints;
    public List<Transform> startingLoc;
    public int waypointIndex;
    public float moveSpeed;
    public StartingPos startingPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypointManager = GameObject.Find("Empties");
        waypoints = waypointManager.GetComponent<WaypointManager>().WaypointList;
        startingLoc = waypointManager.GetComponent<WaypointManager>().startingPoints;
        //transform.position = waypoints[waypointIndex].position;

        switch(startingPos)
        {
            case StartingPos.One:
                transform.position = startingLoc[0].position;
                break;
            case StartingPos.Two:
                transform.position = startingLoc[1].position;
                break;
            case StartingPos.Three:
                transform.position = startingLoc[2].position;
                break;
            case StartingPos.Four:
                transform.position = startingLoc[3].position;
                break;
            case StartingPos.Five:
                transform.position = startingLoc[4].position;
                break;
            case StartingPos.Zero:
                break;
        }

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
