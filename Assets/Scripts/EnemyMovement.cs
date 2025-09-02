using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private LogicManager _logicManager;
    private Transform[] _waypoints;
    private readonly float _moveSpeed = 2;
    private int _currentWaypoint = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
        _waypoints = GameObject.FindGameObjectWithTag("Enemy Path").GetComponentsInChildren<Transform>();
        transform.position = _waypoints[_currentWaypoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentWaypoint <= _waypoints.Length - 1)
        {
            transform.rotation = Quaternion.Euler(0,0,90 * _currentWaypoint);
            transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].transform.position, _moveSpeed * Time.deltaTime);
            if (transform.position == _waypoints[_currentWaypoint].transform.position)
            {
                _currentWaypoint += 1;
            }

            if (_currentWaypoint == _waypoints.Length)
            {
                _currentWaypoint = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        _logicManager.SpawnEnemy();
    }
}
