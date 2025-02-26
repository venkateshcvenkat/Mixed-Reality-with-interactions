using UnityEngine;

public class GrabReleaseOculus : MonoBehaviour
{
    public OVRInput.Button grabButton = OVRInput.Button.PrimaryHandTrigger;
    private bool wasGrabbing = true;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
  

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;

    }

    void Update()
    {
        bool isGrabbing = OVRInput.Get(grabButton);

        if (wasGrabbing && !isGrabbing)
        {
            OnGrabReleased();
        }

    }

    void OnGrabReleased()
    {

        Debug.Log("Grab Released! Returning to initial position.");

        transform.position = initialPosition;
        transform.rotation = initialRotation;


    }
}
