using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerHealthController : MonoBehaviour
{
    public PlayerHealth health;
    private PlayerAnimation animator;
    public bool healOnStart = true;

    private void Start()
    {
        animator = GetComponent<PlayerAnimation>();
        //Reset the health on starting a new level
        if (healOnStart) health.Reset();
    }

    /// <summary>
    /// Damages the player a certain amount
    /// </summary>
    /// <param name="damagingAmount">Amount to damage the player</param>
    public void Damage(int damagingAmount)
    {
        health.Damage(damagingAmount);
        if (health.currentHealth <= 0) Die();
        else animator.PlayHurtAnimation();
    }

    /// <summary>
    /// Heals the damage a certain amount
    /// </summary>
    /// <param name="healingAmount">Amount to heal the player</param>
    /// <returns>True if the player has healed, false if not</returns>
    public bool Heal(int healingAmount)
    {
        return health.Heal(healingAmount);
    }

    /// <summary>
    /// The player dies, tells the PlayerAnimation script to play the animation
    /// and does everything else necessary
    /// </summary>
    private void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        animator.PlayDieAnimation();
    }

}
