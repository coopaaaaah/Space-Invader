using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public Transform[] waypoints;
    private readonly float _moveSpeed = 2;
    private int _currentWaypoint = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = waypoints[_currentWaypoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentWaypoint <= waypoints.Length - 1)
        {
            transform.rotation = Quaternion.Euler(0,0,90 * _currentWaypoint);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position, _moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[_currentWaypoint].transform.position)
            {
                _currentWaypoint += 1;
            }

            if (_currentWaypoint == waypoints.Length)
            {
                _currentWaypoint = 0;
            }
        }
    }
}
