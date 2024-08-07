using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerSO"  )] 
public class PlayerSO : ScriptableObject
{
    public string name;
    public float speed;
    public float jumpForce;
    public float rotationSpeed;
    public int health;

    public GameObject playerObject;


}
