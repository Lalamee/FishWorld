using System;
using UnityEngine;

[RequireComponent(typeof(BoatMover))]
public class StateSwitcherPlayer : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private HarpoonControl _harpoonControl;
    [SerializeField] private Laser _laser;
    [SerializeField] private Canvas _arrows;
    [SerializeField] private float rotationSpeed = 5f; 

    private BoatMover _boatMover;

    private bool isRotating = false; 
    private Quaternion desiredRotation;

    private void Start()
    {
        _boatMover = GetComponent<BoatMover>();
    }

    private void Update()
    {
        if (isRotating)
        {
            // Плавное вращение персонажа вокруг оси Z
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            // Проверка, достиг ли персонаж желаемого поворота
            if (Quaternion.Angle(transform.rotation, desiredRotation) < 0.1f)
            {
                isRotating = false;
                _boatMover.enabled = false;
                _hook.enabled = true;
                _laser.OnRenderer();
                _harpoonControl.enabled = true;
                _arrows.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out AreaForBoat _areaForBoat))
        {
            RotateToAxisZ();
            _areaForBoat.StartSpawnFish();
        }
    }
    
    private void RotateToAxisZ()
    {
        isRotating = true;
        
        Vector3 targetDirection = Vector3.forward; 
        desiredRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
    }
}
