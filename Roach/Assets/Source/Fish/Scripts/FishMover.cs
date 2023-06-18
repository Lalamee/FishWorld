using UnityEngine;


[RequireComponent(typeof(Collider))]
public class FishMover : MonoBehaviour
{
    [SerializeField] private Boat _boat;
    [SerializeField] private float _moveSpeed = 5;
    
    private Vector3 _initialOffset;
    private int _direction;
    private int _directionNumber;
    private float _zero;

    private void Start()
    {
        _boat = FindObjectOfType<Boat>();
        _directionNumber = 1;
        _zero = 0f;

        float boatX = _boat.transform.position.x;
        
        if (boatX < transform.position.x)
            _direction = -_directionNumber;
        else
            _direction = _directionNumber;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(scaledMoveSpeed * _direction, _zero, _zero);
        
        transform.position += moveDirection;
    }
}
