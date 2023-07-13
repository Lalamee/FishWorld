using UnityEngine;
using UnityEngine.UI;

public class ArrowView : MonoBehaviour
{
    [SerializeField] private Transform targetObject; 
    
    private Image arrowImage; 

    private void Start()
    {
        arrowImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (targetObject == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(targetObject.position);
        
            bool isVisible = targetScreenPos.z > 0 && targetScreenPos.x > 0 && targetScreenPos.x < Screen.width && targetScreenPos.y > 0 && targetScreenPos.y < Screen.height;
        
            if (arrowImage != null)
            {
                arrowImage.enabled = !isVisible;
            }

            if (!isVisible)
            {
                Show(targetScreenPos);
            }
        }
    }

    private void Show(Vector3 target)
    {
        float offsetX = Mathf.Clamp(target.x, 50f, Screen.width - 50f);
        float offsetY = Mathf.Clamp(target.y, 50f, Screen.height - 50f);
        Vector3 arrowScreenPos = new Vector3(offsetX, offsetY, target.z);
            
        Vector3 arrowWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(arrowScreenPos.x, arrowScreenPos.y, 10f));
            
        transform.position = arrowWorldPos;
    }
}
