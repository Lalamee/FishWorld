using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    public event UnityAction<int> LevelSet;

    public int Level { get; private set; }

    private Player _player;
    private int _firstLevel;
    private int _levelStep;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _firstLevel = 1;
        _levelStep = 5;
        Level = Random.Range(_firstLevel, _player.GetLevel() + _levelStep);
        
        LevelSet?.Invoke(Level);
    }
}
