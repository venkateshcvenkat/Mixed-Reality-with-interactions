using Oculus.Platform.Models;
using UnityEngine;

public class ResetOnRelease : MonoBehaviour
{
    public GameObject detectedObject;
    public GameObject hitRay,debugText;
   
    private void Start()
    {
        hitRay.SetActive(false);
        debugText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("guard") || other.gameObject.CompareTag("gasket") ||
        other.gameObject.CompareTag("enginebody") || other.gameObject.CompareTag("inout") ||
        other.gameObject.CompareTag("ecu") || other.gameObject.CompareTag("exhaust"))
        {
            detectedObject = other.gameObject;

        }
    }

    private void Update()
    {
        
        if (detectedObject != null && OVRInput.GetDown(OVRInput.Button.One))
        {
            detectedObject.transform.localPosition = Vector3.zero;
            detectedObject.transform.localRotation = Quaternion.identity;
            detectedObject.transform.localScale = Vector3.one;
            Debug.Log("Button Released");

        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            hitRay.SetActive(!hitRay.activeSelf);
            debugText.SetActive(!debugText.activeSelf);
        }
    }


}
 