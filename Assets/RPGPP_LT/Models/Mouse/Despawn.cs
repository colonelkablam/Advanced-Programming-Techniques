using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] private float despawnTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    public void SetDespawnTime(float time)
    {
        this.despawnTime = time;    
    }
}
