using UnityEngine;

[RequireComponent(typeof(BoatMover))]
public class StateSwitcherPlayer : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private HarpoonControl _harpoonControl;
    [SerializeField] private Laser _laser;

    private BoatMover _boatMover;

    private void Start()
    {
        _boatMover = GetComponent<BoatMover>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out AreaForBoat _areaForBoat))
        {
            _boatMover.enabled = false;
            _hook.enabled = true;
            _laser.enabled = true;
            _harpoonControl.enabled = true;
            _areaForBoat.StartSpawnFish();
        }
    }
}
