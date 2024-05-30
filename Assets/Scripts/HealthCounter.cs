using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void SetMaxHealth(int maxHealth)
    {
        // Set the maximum health text
        healthText.text = $"{maxHealth}/{maxHealth}";
    }

    public void SetHealth(int currentHealth, int maxHealth)
    {
        // Set the health text
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
