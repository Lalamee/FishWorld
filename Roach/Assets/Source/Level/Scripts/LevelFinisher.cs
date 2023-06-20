using System;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    private int _needCountFinishZone = 3;
    private int _countFinishZone = 0;
    
    public void FinishFishingInZone()
    {
        _countFinishZone++;

        if (_countFinishZone == _needCountFinishZone)
        {
            Debug.Log("Конец");
        }
    }
}
