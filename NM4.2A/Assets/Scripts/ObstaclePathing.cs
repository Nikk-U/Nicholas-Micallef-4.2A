using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float enemyMovment = 2f;
    [SerializeField] WC WC;
    int waypointIndex = 0;
    private void Start()
    {
        waypoints = WC.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }
    private void Update()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;
           
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovment);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
