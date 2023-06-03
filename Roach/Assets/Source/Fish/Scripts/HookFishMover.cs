using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookFishMover : MonoBehaviour
{
    private Vector3 _targetPosition;
    private FishMover _fishMover;
    private bool _isMoving;
    private float _moveSpeed; 

    private void Start()
    {
        _fishMover = GetComponent<FishMover>();
        _isMoving = false;
    }

    public void StartMoving(Vector3 target, float speed)
    {
        _fishMover.enabled = false;
        _moveSpeed = speed;
        _targetPosition = target;
        _isMoving = true;
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
            {
                _isMoving = false;
            }
        }
    }
}
