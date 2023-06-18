using UnityEngine;

[RequireComponent(typeof(FishingZone))]
public class FishingStoper : MonoBehaviour
{
    private FishingZone _fishingZone;
    private Player _player;
    private BoatMover _boat;
    private HarpoonControl _harpoon;
    private Hook _hook;
    private Laser _laser;
    private int _playerLevel;
    private int _startPlayerLevel;
    private int _levelDifference = 5;

    private void Start()
    {
        _fishingZone = GetComponent<FishingZone>();
        _player = FindObjectOfType<Player>();
        _boat = FindObjectOfType<BoatMover>();
        _harpoon = FindObjectOfType<HarpoonControl>();
        _hook = FindObjectOfType<Hook>();
        _laser = FindObjectOfType<Laser>();
        _startPlayerLevel = _player.GetStartLevel();
    }

    private void Update()
    {
        _playerLevel = _player.GetLevel();
        if (_playerLevel >= _startPlayerLevel + _levelDifference)
        {
            StopFishing();
        }
    }

    private void StopFishing()
    {
        Destroy(_fishingZone.gameObject);
        _player.SetNewStartLevel();
        _boat.enabled = true;
        _hook.enabled = false;
        _harpoon.enabled = false;
        _laser.enabled = false;
    }
}
