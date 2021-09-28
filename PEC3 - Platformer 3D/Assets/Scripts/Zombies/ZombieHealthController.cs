using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ZombieAnimation))]
public class ZombieHealthController : MonoBehaviour
{

    public EnemyHealth health;
    public int currentHealth;

    private ZombieAnimation animator;

    void Start()
    {
        animator = GetComponent<ZombieAnimation>();
        currentHealth = health.maxHealth;
    }

    /// <summary>
    /// Damages Enemy by a certain amount
    /// </summary>
    /// <param name="damageAmount">Amount of damage to hurt the enemy</param>
    public void Damage(int damageAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, health.maxHealth);
        if (currentHealth == 0) Die();
        else animator.PlayHurtAnimation();
    }

    /// <summary>
    /// Makes the enemy die, telling the ZombieAnimation script to play the
    /// animation of dying and disabling the colliders
    /// </summary>
    private void Die()
    {
        GetComponent<ZombieMovement>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<ZombieAttackController>().enabled = false;
        animator.PlayDieAnimation();
    }

}
