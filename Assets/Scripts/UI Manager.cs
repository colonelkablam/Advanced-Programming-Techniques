using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerManager playerManager;

    private Slider healthSlider;

    private void OnEnable()
    {
        playerManager.HealthChanged += UpdateHealthDisplay;

    }

    private void OnDisable()
    {
        playerManager.HealthChanged -= UpdateHealthDisplay;
    }

    private void Awake()
    {
        healthSlider = GetComponentInChildren<Slider>();
    }

    private void UpdateHealthDisplay(int newHealth)
    {
        healthSlider.value = newHealth;
    }

}
