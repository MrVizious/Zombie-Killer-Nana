using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput input;
    private Animator animator;
    private GameObject hurtParticles;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        hurtParticles = transform.Find("HurtParticles").gameObject;
    }

    void Update()
    {
        UpdateWalkingAnimation();
        UpdateJumpAnimation();
    }

    /// <summary>
    /// Sets the parameters used by the walking animation. Should be called
    /// everyframe the walking animation wants to be updated
    /// </summary>
    private void UpdateWalkingAnimation()
    {
        Vector3 localMovement = transform.InverseTransformDirection(
            input.movementInput
        );
        animator.SetFloat("Vertical", localMovement.z);
        animator.SetFloat("Horizontal", localMovement.x);
    }

    /// <summary>
    /// Sets the jump animation trigger on if the player pressed jump
    /// </summary>
    private void UpdateJumpAnimation()
    {
        if (input.jumpedThisFrame)
        {
            animator.SetTrigger("Jump");
            Debug.Log("Jumped!");
        }
    }

    /// <summary>
    /// Activates the trigger that makes the animator play the shooting animation
    /// </summary>
    public void PlayShootAnimation()
    {
        animator.SetBool("Shoot", true);
    }

    /// <summary>
    /// Activates the trigger that makes the animator play the dying animation
    /// </summary>
    public void PlayDieAnimation()
    {
        animator.SetBool("Die", true);
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DeathMenu");
    }

    /// <summary>
    /// Activates the trigger that makes the animator play the hurt animation
    /// </summary>
    public void PlayHurtAnimation()
    {
        animator.SetBool("Hurt", true);
        hurtParticles.SetActive(false);
        hurtParticles.SetActive(true);
    }
}
