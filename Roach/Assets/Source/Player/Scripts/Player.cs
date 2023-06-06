using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _level;
    
    public event UnityAction<int> LevelChange;

    private void Start()
    {
        _level = 1;
        LevelChange?.Invoke(_level);
    }

    public void CatchFish(int fishLevel)
    {
        _level += fishLevel;
        LevelChange?.Invoke(_level);
    }

    public bool IsPlayerLevelMore(int fishLevel)
    {
        if (_level < fishLevel)
            return false;
        
        return true;
    }
}
