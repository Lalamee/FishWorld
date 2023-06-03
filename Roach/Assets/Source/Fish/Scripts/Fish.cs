using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    public event UnityAction<int> LevelSet; 
    
    private int _level;

    private void Start()
    {
        _level = Random.Range(1, 10);
        LevelSet?.Invoke(_level);
    }
}
