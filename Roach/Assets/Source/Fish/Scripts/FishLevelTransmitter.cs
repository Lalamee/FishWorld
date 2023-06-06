using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLevelTransmitter : MonoBehaviour
{
    public bool IsCanTransmit { get; private set; }
    
    private Fish _fish;
    private Player _player;

    private void Start()
    {
        IsCanTransmit = false;
        _fish = GetComponent<Fish>();
        _player = FindObjectOfType<Player>();
    }

    public void TransmitAndDestroy()
    {
        if (_player.IsPlayerLevelMore(_fish.Level))
        {
            _player.CatchFish(_fish.Level);
            Destroy(_fish.gameObject);
        }
        else
        {
            Destroy(_player.gameObject);
        }
    }
}
