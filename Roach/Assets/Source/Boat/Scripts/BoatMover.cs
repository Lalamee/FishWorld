using UnityEngine;

public class BoatMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 2f;

    private BoatInput _input;
    private float _zero = 0f;
    
    private void Awake()
    {
        _input = new BoatInput();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = _input.Boat.Move.ReadValue<Vector2>();
        
        Move(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        float scaledRotationSpeed = _rotationSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, _zero, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;

        if (moveDirection != Vector3.zero)
        {
            Quaternion transformPoint = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, transformPoint, scaledRotationSpeed);
        }
    }
}
