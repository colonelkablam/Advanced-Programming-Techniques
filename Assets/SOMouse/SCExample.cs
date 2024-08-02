using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCExample : MonoBehaviour
{
    public ScriptableObjectExample objectExample;

    public void Spawn()
    {
        Instantiate(objectExample.gameObject, transform.position, transform.rotation);
    }
}
