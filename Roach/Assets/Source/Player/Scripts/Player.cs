using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _level;
    private int _startLevel;
    
    public event UnityAction<int> LevelChange;

    private void Start()
    {
        _level = 1;
        _startLevel = _level;
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

    public int GetLevel()
    {
        return _level;
    }

    public int GetStartLevel()
    {
        return _startLevel;
    }

    public void SetNewStartLevel()
    {
        _startLevel = _level;
    }
}
