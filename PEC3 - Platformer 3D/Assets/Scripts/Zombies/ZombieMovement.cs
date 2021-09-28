using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WanderingScript))]
[RequireComponent(typeof(NavMeshAgent))]
public class ZombieMovement : MonoBehaviour
{
    public float checkRadius = 10f;
    public float secondsBetweenCheck = 0.2f;
    private float secondsSinceLastCheck = 0f;

    private WanderingScript wander;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<WanderingScript>();
    }
    void Update()
    {
        secondsSinceLastCheck += Time.deltaTime;
        if (secondsSinceLastCheck >= secondsBetweenCheck)
        {
            secondsSinceLastCheck = 0f;
            if (!FoundPlayer())
                wander.Wander();
        }


    }

    /// <summary>
    /// Looks for player and returns True if they are found
    /// </summary>
    /// <returns>True if player is found, False if not</returns>
    private bool FoundPlayer()
    {
        //Array of found colliders with Layer "Player" in radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,
                                checkRadius,
                                1 << LayerMask.NameToLayer("Player"));

        //Loops through the found colliders
        foreach (Collider hitCollider in hitColliders)
        {
            //If one collider has tag "Player", set it as destination and return true
            if (hitCollider.tag.Equals("Player"))
            {
                agent.destination = hitCollider.transform.position;
                return true;
            }
        }

        //If no player is found, return false
        return false;
    }
}