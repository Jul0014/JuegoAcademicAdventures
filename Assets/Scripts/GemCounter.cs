using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCounter : MonoBehaviour
{
    public TextMeshProUGUI gemText;

    public void SetGems(int currentHealth)
    {
        // Set the health text
        gemText.text = $"{currentHealth}";
    }
}
