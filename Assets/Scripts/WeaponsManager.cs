using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    public void EnableWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(true);
        }
    }

    public void DisableWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }
}
