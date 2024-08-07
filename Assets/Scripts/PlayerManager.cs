using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Declare a Delegate
    public delegate void OnHealthChanged(int newHealth);

    public PlayerSO playerSO; // data object for the player

    public static PlayerManager instance; // 

    // Define an Event Using the Delegate
    public event OnHealthChanged HealthChanged;

    public int health;
    public int score;

    private bool playerUsingState = false;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple PlayerManager instances being created");
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
        health = playerSO.health;
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(25);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerUsingState = true;
            Debug.Log("Player Using");
        }
    }

    // The main function which will call the delegate 
    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthChanged?.Invoke(health); // '?' checks if the event is null and Invoke notifies all the subscribers
    }

    public bool GetPlayerUsing()
    {
        return playerUsingState;
    }

    public void ResetPlayerUsingState()
    {
        playerUsingState = false;
    }
}
