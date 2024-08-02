using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects",1f,3f);
    }

    void SpawnObjects()
    {

        Instantiate(spawnObject, this.transform.position,this.transform.rotation);
    }

    
}
