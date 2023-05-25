using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishLevel : MonoBehaviour
{
    [SerializeField] private Fish _fish;
    [SerializeField] private TMP_Text _level;

    private void OnEnable()
    {
        _fish.LevelSet += OnLevelSet;
    }

    private void OnDisable()
    {
        _fish.LevelSet -= OnLevelSet;
    }

    private void OnLevelSet(int level)
    {
        _level.text = level.ToString() + " Level";
    }
}
