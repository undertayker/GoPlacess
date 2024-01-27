using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Move : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private Transform _waypoints;

    private Transform[] _points;
    private int _pointNumber;

    private void Start()
    {
        _points = new Transform[_waypoints.childCount];

        for (int i = 0; i < _waypoints.childCount; i++)
        {
            _points[i] = _waypoints.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var endPoint = _points[_pointNumber];

        transform.position = Vector3.MoveTowards(transform.position, 
            endPoint.position,
            _speed * Time.deltaTime);

        if (transform.position == endPoint.position)
        {
            NextPlaced();
        }
    }

    public Vector3 NextPlaced()
    {
        _pointNumber++;

        if (_pointNumber == _points.Length)
        {
            _pointNumber = 0;
        }
           
        var direction = _points[_pointNumber].transform.position;
        transform.forward = direction - transform.position;

        return direction;
    }
}