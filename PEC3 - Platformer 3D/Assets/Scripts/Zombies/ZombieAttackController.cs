using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ZombieAnimation))]
public class ZombieAttackController : MonoBehaviour
{
    public EnemyAttack attack;

    private ZombieAnimation animator;
    private float timeOfLastAttack = 0f;

    private void Start()
    {
        animator = GetComponent<ZombieAnimation>();
        timeOfLastAttack = 0f;
    }

    private void Update()
    {
        if (Time.time - timeOfLastAttack > attack.secondsBetweenAttacks)
        {
            timeOfLastAttack = Time.time;
            if (attack.TryToAttack(transform)) animator.PlayAttackAnimation();
        }
    }

}
