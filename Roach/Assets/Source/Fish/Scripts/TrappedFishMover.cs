using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookFishMover : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Vector3 _finishPosition;
    private FishMover _fishMover;
    private bool _isMoving;
    private float _returnTime;
    private float _returnTimer;

    private void Start()
    {
        _fishMover = GetComponent<FishMover>();
        _isMoving = false;
    }

    public void StartMoving(Vector3 finishPosition,float returnTime, float returnTimer)
    {
        _fishMover.enabled = false;
        _isMoving = true;
        _targetPosition = transform.position;
        _finishPosition = finishPosition;
        _returnTime = returnTime;
        _returnTimer = returnTimer;
    }

    private void Update()
    {
        if (_isMoving)
        {
            _returnTimer += Time.deltaTime;
            float lerpProgress = _returnTimer / _returnTime;
            transform.position = Vector3.Lerp(_targetPosition, _finishPosition, lerpProgress);

            if (lerpProgress >= 1f)
                _isMoving = false;
        }
    }
}
