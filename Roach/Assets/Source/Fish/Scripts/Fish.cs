using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    private int _level;

    public event UnityAction<int> LevelSet; 

    private void Start()
    {
        _level = Random.Range(1, 10);
        LevelSet?.Invoke(_level);
    }
}
