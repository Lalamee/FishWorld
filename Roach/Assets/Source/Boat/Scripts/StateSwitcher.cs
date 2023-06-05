using System;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private Hook _hook;

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
        }
    }
}
