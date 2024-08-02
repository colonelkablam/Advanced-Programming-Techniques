using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawn", menuName = "ScriptableObjectExample/Data")]
public class ScriptableObjectExample : ScriptableObject
{
    public string name;
    public string description;
    public GameObject gameObject;
}
