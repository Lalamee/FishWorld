using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedFish : MonoBehaviour
{

    private Vector3 _targetPosition;
    private Vector3 _finishPosition;
    private FishLevelTransmitter _fishLevelTransmitter;
    private FishMover _fishMover;
    private bool _isLevelChange;
    private bool _isMoving;
    private float _returnTime;
    private float _returnTimer;

    private void Start()
    {
        _fishLevelTransmitter = GetComponent<FishLevelTransmitter>();
        _fishMover = GetComponent<FishMover>();
        _isLevelChange = false;
        _isMoving = false;
    }


    private void Update()
    {
        if (_isMoving)
        {
            _returnTimer += Time.deltaTime;
            float lerpProgress = _returnTimer / _returnTime;
            transform.position = Vector3.Lerp(_targetPosition, _finishPosition, lerpProgress);

            if (lerpProgress >= 0.75 && !_isLevelChange)
            {
                _fishLevelTransmitter.TransmitAndDestroy();
                _isLevelChange = true;
            }
        }
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
}
