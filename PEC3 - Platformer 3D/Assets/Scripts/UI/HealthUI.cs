using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public PlayerHealth health;

    public Text currentHealth;

    private void Update()
    {
        currentHealth.text = health.currentHealth + "/" + health.maxHealth;
    }
}
