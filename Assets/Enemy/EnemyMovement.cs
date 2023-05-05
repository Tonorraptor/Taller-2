using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex;

    private void Start()
    {
        transform.position = _waypoints[0].position;
        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        Vector2 targetPosition = _waypoints[_currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
    }
}

