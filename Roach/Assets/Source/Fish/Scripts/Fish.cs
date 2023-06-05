using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    public int Level { get; private set; }
    public event UnityAction<int> LevelSet;

    private void Start()
    {
        Level = Random.Range(1, 10);
        LevelSet?.Invoke(Level);
    }
}
