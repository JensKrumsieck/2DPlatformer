using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    private int _currentWaypointIndex;

    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[_currentWaypointIndex].transform.position) < .1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[_currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}