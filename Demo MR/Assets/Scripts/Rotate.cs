using System.Collections;
using UnityEngine;

public class Rotate_01 : MonoBehaviour
{
    public Vector3 side;
    public float speed = 2f;



    private void Update()
    {
        transform.Rotate(side * speed);

    }









}