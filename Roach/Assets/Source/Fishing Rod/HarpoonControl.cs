using System;
using UnityEngine;

public class HarpoonControl : MonoBehaviour
{
    private HarpoonInput _input;
    private float _rotationSpeed = 50f;

    private void Awake()
    {
        _input = new HarpoonInput();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        DrowRay();
        
        if(Input.GetMouseButton(0))
            RotateObject();
    }

    private void DrowRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);
    }

    private void RotateObject()
    {
        Vector2 mouseDelta = _input.Harpoon.Rotation.ReadValue<Vector2>();
        float rotationY = mouseDelta.x * _rotationSpeed * Time.deltaTime;
        
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float newRotationY = currentRotation.y + rotationY;
        
        if (newRotationY > 180f)
            newRotationY -= 360f;
        else if (newRotationY < -180f)
            newRotationY += 360f;
        
        float clampedRotationY = Mathf.Clamp(newRotationY, -60f, 60f);
        transform.rotation = Quaternion.Euler(currentRotation.x, clampedRotationY, currentRotation.z);
    }
}
