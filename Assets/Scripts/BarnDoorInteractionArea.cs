using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarnDoorInteractionArea : MonoBehaviour
{
    [SerializeField] private UnityEvent barnDoorOpenInteraction;
    [SerializeField] private UnityEvent barnDoorCloseInteraction;



    // Ensure you have a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            barnDoorOpenInteraction.Invoke();
            Debug.Log("Player in barn door area!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            barnDoorCloseInteraction.Invoke();
            Debug.Log("Player left barn door area!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (barnDoorOpenInteraction == null)
        {
            barnDoorOpenInteraction = new UnityEvent();
        }
        if (barnDoorCloseInteraction == null)
        {
            barnDoorCloseInteraction = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

