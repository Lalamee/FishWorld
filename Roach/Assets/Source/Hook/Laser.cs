using UnityEngine;

public class Laser : MonoBehaviour
{
    private float lineLength = 10f;
    private LineRenderer _laser;

    private void Start()
    {
        _laser = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Vector3 aimDirection = transform.forward;
        Vector3 lineEnd = transform.position + aimDirection * lineLength;
        
        _laser.SetPosition(0, transform.position);
        _laser.SetPosition(1, lineEnd);
    }

    public void OnLaser()
    {
        _laser.enabled = true;
    }

    public void OffLaser()
    {
        _laser.enabled = false;
    }
}
