using UnityEngine;

public class AreaForBoat : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private FishingStoper _fishingStoper;
    [SerializeField] private PlayerCountTrappedFish _progress;

    public void StartSpawnFish()
    {
        _spawner.enabled = true;
        _fishingStoper.enabled = true;
        _progress.enabled = true;
    }
}
