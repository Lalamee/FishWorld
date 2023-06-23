using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _laser;
    private float lineLength = 10f;

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

    public void OnRenderer()
    {
        _laser.enabled = true;
    }

    public void OffRenderer()
    {
        _laser.enabled = false;
    }
}
