using UnityEngine;


[RequireComponent(typeof(Collider))]
public class FishMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _moveSpeed = 5;
    
    private Vector3 _initialOffset;
    private int _direction;

    public void Start()
    {
        if (_player.position.x < transform.position.x)
            _direction = -1;
        else
            _direction = 1;
    }

    private void Update()
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(scaledMoveSpeed * _direction, 0, 0);
        
        transform.position += moveDirection;
    }
}
