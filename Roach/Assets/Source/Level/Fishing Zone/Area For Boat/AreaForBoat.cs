using UnityEngine;

public class AreaForBoat : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private FishingStoper _fishingStoper;

    public void StartSpawnFish()
    {
        _spawner.enabled = true;
        _fishingStoper.enabled = true;
    }
}
