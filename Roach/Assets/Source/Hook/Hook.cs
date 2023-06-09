using System.Collections;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private HarpoonControl _harpoonControl;
    [SerializeField] private Laser _laser;
    [SerializeField] private float _speed;
    [SerializeField] private float _returnTime;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private Fish _hookedObject;
    private bool _isMoving;
    private bool _isReturning;
    private float _returnTimer;

    private void Start()
    {
        _isMoving = false;
        _isReturning = false;
        _returnTimer = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !_isMoving && !_isReturning)
        {
            _initialPosition = transform.position;
            _isMoving = true;
            
            _laser.OffLaser();
            _harpoonControl.LockMovement();
            
            StartCoroutine(ReturnTimerCoroutine());
        }

        if (_isMoving)
        {
            MoveHook();
        }

        if (_isReturning)
        {
            ReturnHook();
        }
    }

    private void MoveHook()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void ReturnHook()
    {
        _returnTimer += Time.deltaTime;
        float lerpProgress = _returnTimer / _returnTime;
        transform.position = Vector3.Lerp(_targetPosition, _initialPosition, lerpProgress);

        if (lerpProgress >= 1f)
        {
            _harpoonControl.UnlockMovement();
            _laser.OnLaser();
            _isReturning = false;
            _returnTimer = 0f;
        }
    }

    private void ChangeHookState()
    {
        if (_isMoving && !_isReturning)
        {
            _targetPosition = transform.position;
            _isMoving = false;
            _isReturning = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isReturning && collision.gameObject.TryGetComponent(out TrappedFish _trappedFish))
        {
            _targetPosition = transform.position;
            _isMoving = false;
            _isReturning = true;
            _trappedFish.StartMoving(_initialPosition, _returnTime, _returnTimer);
            _trappedFish.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private IEnumerator ReturnTimerCoroutine()
    {
        yield return new WaitForSeconds(_returnTime);
        ChangeHookState();
    }
}