using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealth", menuName = "ScriptableObjects/Player/Health", order = 1)]
public class PlayerHealth : ScriptableObject
{
    public int maxHealth, currentHealth;

    /// <summary>
    /// Heals the player a given amount
    /// </summary>
    /// <param name="healingAmount">Amount to heal the player</param>
    /// <returns>True if the healing worked, false if not</returns>
    public bool Heal(int healingAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + healingAmount,
                                        0,
                                        maxHealth);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Damages the player a given amount
    /// </summary>
    /// <param name="damagingAmount">Amount to damage the player</param>
    public void Damage(int damagingAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damagingAmount,
                                    0,
                                    maxHealth);

        //TODO: Turn into event
        if (currentHealth == 0) Debug.Log("Dead!");
    }

    /// <summary>
    /// Resets the player's health
    /// </summary>
    public void Reset()
    {
        currentHealth = maxHealth;
    }
}
