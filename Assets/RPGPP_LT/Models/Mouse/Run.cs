using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float speed = 5f; // Speed at which the GameObject moves

    void Update()
    {
        // Move the GameObject forward constantly
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
