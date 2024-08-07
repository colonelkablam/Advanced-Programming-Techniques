using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNew : MonoBehaviour
{

    [SerializeField] private GameObject spawnGameObject;

    [SerializeField] private Transform spawnTransform;


    public void Start()
    {
        InvokeRepeating("SpawnItem", 3.0f, 2.0f);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)) { CancelInvoke("SpawnItem"); }
    }

    private void SpawnItem()
    {
        Instantiate(spawnGameObject, spawnTransform.position, spawnTransform.rotation);
    }
}
