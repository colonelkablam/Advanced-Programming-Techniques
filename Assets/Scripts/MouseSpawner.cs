using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mouseObject;
    [SerializeField] private Transform _mouseSpawnTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMice()
    {
        StartCoroutine(FireSpawner(Random.Range(1, 4)));
    }

    IEnumerator FireSpawner(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_mouseObject, _mouseSpawnTransform.position, _mouseSpawnTransform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
