using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _level;
    
    public event UnityAction<int> LevelChange;

    private void Start()
    {
        _level = 0;
        LevelChange?.Invoke(_level);
    }
    
}
