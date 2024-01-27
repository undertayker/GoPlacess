using UnityEngine;

public class GoPlaces : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private Transform AllPlacesPoint;

    private Transform[] arrayPlaces;
    private int NumberOfPlaceInArrayPlaces;

    private void Start()
    {
        arrayPlaces = new Transform[AllPlacesPoint.childCount];

        for (int i = 0; i < AllPlacesPoint.childCount; i++)
        {
            arrayPlaces[i] = AllPlacesPoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var pointByNumberInArray = arrayPlaces[NumberOfPlaceInArrayPlaces];

        transform.position = Vector3.MoveTowards(transform.position, 
            pointByNumberInArray.position,
            _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
        {
            NextPlaceTakerLogic();
        }
    }


    public Vector3 NextPlaceTakerLogic()
    {
        NumberOfPlaceInArrayPlaces++;

        if (NumberOfPlaceInArrayPlaces == arrayPlaces.Length)
        {
            NumberOfPlaceInArrayPlaces = 0;
        }
           
        var thisPointVector = arrayPlaces[NumberOfPlaceInArrayPlaces].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}