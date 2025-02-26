using System.Collections;
using UnityEngine;

public class MeshExplosion : MonoBehaviour
{
    public Transform[] parentMeshes;
    public Vector3[] explosionDirections;

    public float explosionTime = 2f;
    public bool returnToOriginal = true;
    public float holdtime;

    public GameObject hitRay, displayText;

    private Vector3[] originalPositions;
    private bool isExploded = false;


    void Start()
    {
        hitRay.SetActive(false);
        displayText.SetActive(false);
        if (parentMeshes.Length == 0)
        {
            Debug.LogError("Assign parent meshes in the inspector.");
            return;
        }

        if (explosionDirections.Length != parentMeshes.Length)
        {
            Debug.LogError("Explosion directions count must match the parentMeshes count!");
            return;
        }

        originalPositions = new Vector3[parentMeshes.Length];

        for (int i = 0; i < parentMeshes.Length; i++)
        {
            originalPositions[i] = parentMeshes[i].localPosition;
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!isExploded)
            {
                Explode();
            }
            else
            {
                StartCoroutine(Reassemble());
            }

            isExploded = !isExploded;
        }


        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            hitRay.SetActive(!hitRay.activeSelf);
            displayText.SetActive(!displayText.activeSelf);
        }

    }

    public void Explode()
    {
        StartCoroutine(ExplodeRoutine());
    }

    IEnumerator ExplodeRoutine()
    {

        hitRay.SetActive(true);
        displayText.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < explosionTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / explosionTime;

            for (int i = 0; i < parentMeshes.Length; i++)
            {
                parentMeshes[i].localPosition = Vector3.Lerp(originalPositions[i], originalPositions[i] + explosionDirections[i], t);
            }

            yield return null;
        }

        if (returnToOriginal)
        {
            yield return new WaitForSeconds(holdtime);
        }
    }

    public IEnumerator Reassemble()
    {
        hitRay.SetActive(false);
        displayText.SetActive(false);

        float elapsedTime = 0f;
        while (elapsedTime < explosionTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / explosionTime;

            for (int i = 0; i < parentMeshes.Length; i++)
            {
                parentMeshes[i].localPosition = Vector3.Lerp(parentMeshes[i].localPosition, originalPositions[i], t);
            }

            yield return null;
        }
    }
}
