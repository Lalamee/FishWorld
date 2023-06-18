using UnityEngine;

[RequireComponent(typeof(Fish))]
public class FishLevelTransmitter : MonoBehaviour
{
    private Fish _fish;
    private Player _player;

    private void Start()
    {
 
        _fish = GetComponent<Fish>();
        _player = FindObjectOfType<Player>();
    }

    public void TransmitAndDestroy()
    {
        if (_player.IsPlayerLevelMore(_fish.Level))
        {
            _player.CatchFish(_fish.Level);
            Destroy(_fish.gameObject);
        }
        else
        {
            Destroy(_player.gameObject);
        }
    }
}
