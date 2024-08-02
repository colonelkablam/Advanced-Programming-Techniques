using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Declare a Delagate 
    public delegate void OnHealthChanged(int newHealth);

    //Define an Event Using the Delegate
    public event OnHealthChanged HealthChanged;

    public int health=100;

    public int score = 0;



    //The main function which will call the delegate 
    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthChanged?.Invoke(health);//Tip 1: '?' checks if the event is null //Tip 2: Invoke notifies all the subscriber
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(25);
        }
    }

    
}
