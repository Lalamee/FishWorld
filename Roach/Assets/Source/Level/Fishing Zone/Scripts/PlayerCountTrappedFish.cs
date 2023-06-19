using System;
using TMPro;
using UnityEngine;


public class PlayerCountTrappedFish : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _count;
    
    private int _needCountFish = 5;

    private void Start()
    {
        _count.text = "0/0";
    }

    private void OnEnable()
    {
        _player.CountTrappedFishChange += OnCountChange;
    }

    private void OnDisable()
    {
        _player.CountTrappedFishChange -= OnCountChange;
    }

    private void OnCountChange(int count)
    {
        _count.text = count.ToString() + '/' + _needCountFish.ToString();
    }
}