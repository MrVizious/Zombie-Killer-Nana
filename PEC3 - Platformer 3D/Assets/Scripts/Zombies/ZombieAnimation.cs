using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class ZombieAnimation : MonoBehaviour
{

    private GameObject hurtParticles;

    private Animator animator;
    private NavMeshAgent agent;

    private void Update()
    {
        UpdateAnimatorMovementParameters();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        hurtParticles = transform.Find("HurtParticles").gameObject;
    }

    /// <summary>
    /// Plays the animation of the zombie hurting
    /// </summary>
    public void PlayHurtAnimation()
    {
        animator.SetTrigger("Hurt");
        hurtParticles?.SetActive(false);
        hurtParticles?.SetActive(true);
    }

    /// <summary>
    /// Plays the animation of the zombie dying
    /// </summary>
    public void PlayDieAnimation()
    {
        animator.SetTrigger("Die");
    }

    /// <summary>
    /// Plays the animation of the zombie attacking a random animation
    /// </summary>
    public void PlayAttackAnimation()
    {
        for (int i = 1; i < 4; i++)
        {
            animator.ResetTrigger("Attack" + i);
        }
        animator.SetTrigger("Attack" + Random.Range(1, 4));
    }

    /// <summary>
    /// Updates values for the zombie movement animation
    /// </summary>
    private void UpdateAnimatorMovementParameters()
    {
        float velocity = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Forward", velocity);
    }

}