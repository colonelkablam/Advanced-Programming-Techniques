using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractionArea : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    private Animator chestAnimator;

    private void Start()
    {
        // Get the Animator component attached to the chest
        chestAnimator = chest.GetComponent<Animator>();
    }

    private void Update()
    {
        // Optional: You can handle additional logic here if needed
    }

    private void OnTriggerStay(Collider other)
    {
        // Ensure interaction only is triggered by player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in chest interaction area");
            PlayerManager playerManager = other.gameObject.GetComponent<PlayerManager>();
            if (playerManager != null && playerManager.GetPlayerUsing())
            {
                HandlePlayerInteraction(playerManager);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Ensure interaction only is triggered by player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left chest interaction area");
            HandlePlayerLeavingInteraction();
        }
    }

    private void HandlePlayerInteraction(PlayerManager playerManager)
    {
        // Trigger the chest open animation
        chestAnimator.SetTrigger("ChestOpen");

        // Reset player using state
        playerManager.ResetPlayerUsingState();
    }

    private void HandlePlayerLeavingInteraction()
    {
        // Trigger the chest close animation
        chestAnimator.SetTrigger("ChestClose");
    }
}
