using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastScanner : MonoBehaviour
{
    [SerializeField] private Camera scannerCamera;
    [SerializeField] private LayerMask evidenceLayer;

    [Header("DEBUG")]
    [Tooltip("Activate Raycast Lines")][SerializeField] private bool DEBUG = false;

    private void OnEnable()
    {
        PlayerInput.OnFire += RaycastFromScanCamera;
    }

    private void OnDisable()
    {
        PlayerInput.OnFire -= RaycastFromScanCamera;
    }

    private void RaycastFromScanCamera()
    {
        Ray mainCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (DEBUG)
        {
            Debug.DrawRay(mainCameraRay.origin, mainCameraRay.direction * 100f, Color.red, 20f);
        }

        /* First Raycast - Target: Render Texture */
        if (Physics.Raycast(mainCameraRay, out RaycastHit hit, 100f, evidenceLayer))
        {
            HandleFirstRaycastHit(hit);
        }
    }

    private void HandleFirstRaycastHit(RaycastHit hit)
    {
        if (hit.transform is RectTransform rawImageRectTransform)
        {
            Vector3 localHitPoint = rawImageRectTransform.InverseTransformPoint(hit.point);
            Vector2 normalizedPoint = NormalizeLocalPoint(localHitPoint, rawImageRectTransform);
            Ray scannerCameraRay = scannerCamera.ViewportPointToRay(normalizedPoint);

            if (DEBUG)
            {
                Debug.DrawRay(scannerCameraRay.origin, scannerCameraRay.direction * 100f, Color.blue, 20f);
            }

            /* Second Raycast From Scanner Camera - Target: World Space Objects */
            if (Physics.Raycast(scannerCameraRay, out RaycastHit secondHit, 100f, evidenceLayer))
            {
                HandleSecondRaycastHit(secondHit);
            }
        }
    }

    private void HandleSecondRaycastHit(RaycastHit hit)
    {
        ModularPart part = hit.collider.GetComponent<ModularPart>();

        ////If object is a symptom
        //if (hit.collider.gameObject.GetComponent<ClickableSymptoms>() != null)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Debug.Log("Found Symptom");
        //        hit.collider.gameObject.GetComponent<ClickableSymptoms>().DisplayTooltip();
        //    }
        //}

        if (part != null)
        {
            part.BroadcastData();
        }
        else
        {
            Debug.LogError($"Evidence without data hit: {hit.collider.name}");
        }
    }

    private Vector2 NormalizeLocalPoint(Vector3 localPoint, RectTransform rectTransform)
    {
        float normalizedX = (localPoint.x - rectTransform.rect.x) / rectTransform.rect.width;
        float normalizedY = (localPoint.y - rectTransform.rect.y) / rectTransform.rect.height;
        return new Vector2(normalizedX, normalizedY);
    }
}
