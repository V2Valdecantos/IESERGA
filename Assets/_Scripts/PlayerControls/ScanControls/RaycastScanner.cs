using UnityEngine;

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
        RaycastHit hit;
        Ray r = scannerCamera.ScreenPointToRay(Input.mousePosition);

        if (DEBUG)
        {
            Debug.DrawRay(r.origin, r.direction * 100f, Color.red, 10f);
        }

        if (Physics.Raycast(r, out hit, evidenceLayer, evidenceLayer))
        {
            ModularPart part = hit.collider.GetComponent<ModularPart>();

            if (part == null)
            {
                Debug.LogError($"Evidence without data hit: {gameObject.name}");
                return;
            }

            part.BroadcastData();
        }
    }
}
