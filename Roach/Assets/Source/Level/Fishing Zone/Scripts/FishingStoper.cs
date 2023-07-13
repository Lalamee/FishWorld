using UnityEngine;

[RequireComponent(typeof(FishingZone))]
public class FishingStoper : MonoBehaviour
{
    [SerializeField] private Canvas _arrows;
    
    private Player _player;
    private BoatMover _boat;
    private HarpoonControl _harpoon;
    private Hook _hook;
    private Laser _laser;
    private LevelFinisher _levelFinisher;
    private int _countTrappedFish;
    private int _needCountFish = 3;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _boat = FindObjectOfType<BoatMover>();
        _harpoon = FindObjectOfType<HarpoonControl>();
        _hook = FindObjectOfType<Hook>();
        _laser = FindObjectOfType<Laser>();
        _levelFinisher = FindObjectOfType<LevelFinisher>();
    }

    private void Update()
    {
        _countTrappedFish = _player.GetCountTrappedFish();
        if (_countTrappedFish == _needCountFish)
        {
            StopFishing();
        }
    }

    private void StopFishing()
    {
        _levelFinisher.FinishFishingInZone();
        Destroy(gameObject);
        _laser.OffRenderer();
        _player.SetNewStartLevel();
        _player.ResetCountTrappedFish();
        _boat.enabled = true;
        _harpoon.enabled = false;
        _hook.enabled = false;
        _arrows.enabled = true;
    }
}
