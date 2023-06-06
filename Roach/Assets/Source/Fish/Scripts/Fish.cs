using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    public int Level { get; private set; }

    private FishLevelTransmitter _fishLevelTransmitter;
    
    public event UnityAction<int> LevelSet;

    private void Start()
    {
        _fishLevelTransmitter = GetComponent<FishLevelTransmitter>();
        Level = Random.Range(1, 10);
        LevelSet?.Invoke(Level);
    }

    public void SetTrappedState(Vector3 finishPosition,float returnTime, float returnTimer)
    {
        
    }
}
