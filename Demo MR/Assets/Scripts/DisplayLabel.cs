using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;

public class DisplayLabel : MonoBehaviour
{
    public Transform rayStartPoint;
    public float rayLength = 5;
    public TextMeshPro debugText;

    void Update()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);
        Debug.DrawRay(rayStartPoint.position, rayStartPoint.forward);
        bool hasHitPhysics = Physics.Raycast(ray, out RaycastHit physicsHit, rayLength);


        if (hasHitPhysics)
        {

            string objectName = physicsHit.collider.gameObject.name;
            UpdateText(physicsHit.point, physicsHit.normal, "ANCHOR: " + objectName);
        }

    }

    void UpdateText(Vector3 position, Vector3 normal, string text)
    {
        debugText.transform.position = position;
        debugText.transform.rotation = Quaternion.LookRotation(-normal);
        debugText.text = text;
    }
}

