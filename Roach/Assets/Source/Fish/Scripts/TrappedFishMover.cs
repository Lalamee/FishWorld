using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedFishMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Vector3 _targetPosition;
    private Vector3 _finishPosition;
    private Fish _fish;
    private FishMover _fishMover;
    private bool _isMoving;
    private float _returnTime;
    private float _returnTimer;
    private int _fishLevel;

    private void Start()
    {
        _fish = GetComponent<Fish>();
        _fishMover = GetComponent<FishMover>();
        _isMoving = false;
        _fishLevel = _fish.Level;
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
            _player.CatchFish(_fishLevel);

            if (lerpProgress >= 0.75)
            {
                Destroy(gameObject);
            }
        }
    }
}
