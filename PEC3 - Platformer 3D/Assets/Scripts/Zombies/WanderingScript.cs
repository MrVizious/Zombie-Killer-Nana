using UnityEngine;
using UnityEngine.AI;

//This class was created for the AI subject
[RequireComponent(typeof(NavMeshAgent))]
public class WanderingScript : MonoBehaviour
{
    private NavMeshAgent agent;

    //Public variables that control how far the center of the search will be
    //and how far from that center the point will be chosen
    [Min(0)]
    public float seekCenterDistance = 5f, seekRadius = 3f;

    //Public variable to set how long should the agent wait to do the next
    //position check
    [Min(0)]
    public float secondsPerCheck = 0.15f;
    private float secondsSinceLastCheck = 0f;


    //Public variables that control the maximum depth trying to find a suitable 
    //point with the parameters given
    [Min(0)]
    public int maxNumberOfTries = 200;

    //Set to true in the inspector to draw Debug information
    public bool drawGizmos = false;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Makes the agent wander around the NavMesh
    /// </summary>
    public void Wander()
    {
        //Adds the ime since the last frame to the variable that controls how 
        //often the checks should be made
        secondsSinceLastCheck += Time.deltaTime;

        //If the time since the last check is greater or equal to the specified 
        //cadency, reset the time between checks and check
        if (secondsSinceLastCheck >= secondsPerCheck)
        {
            secondsSinceLastCheck = 0f;
            SeekNextPosition();
        }
    }

    /// <summary>
    /// Tries to find an appropriate next point to follow and, if it can't, it 
    /// sets the point just behind the agent
    /// </summary>
    private void SeekNextPosition()
    {
        // Find center for circle from the floor
        Vector3 seekCenter =
            transform.position - new Vector3(0, transform.position.y, 0)
            + transform.forward * seekCenterDistance;

        //Show debug ray pointing to the center in red if the debug options are set
        if (drawGizmos) Debug.DrawRay(transform.position, seekCenter
                                        - transform.position, Color.red);

        // Declaration of variables for loop control and data to infinity
        Vector3 newExactTarget = Vector3.positiveInfinity;
        Vector3 newInexactTarget = Vector3.positiveInfinity;

        //Set counter for maximum depth of search
        int depthCounter = 0;

        //Loop that searches for a calid point
        while (newExactTarget.x == Mathf.Infinity)
        {
            //Sets a temporary "inexact" point using a random angle
            newInexactTarget =
                seekCenter
                + Quaternion.AngleAxis(Random.Range(0, 360), transform.up)
                * transform.forward * seekRadius;

            //Tries to get a valid "exact" point from the "inexact" point
            newExactTarget = ConvertInexactTargetToExactTarget(newInexactTarget);

            //Checks if the depth is already too deep
            //If it is, it breaks out of the loop and sets the target point 
            //directly behind the agent
            if (depthCounter >= maxNumberOfTries)
            {

                //Logs error of depth
                Debug.LogError("Too much recursion!");

                //Set target behind agent
                newExactTarget = -transform.forward * 0.1f;

                //Break out of while loop
                break;
            }

            //If debug options are set, draw a ray from the center to the inexact 
            //center that has been selected, and paint it white if it is valid or 
            //red if it isn't
            if (drawGizmos)
            {
                Debug.DrawRay(seekCenter, newInexactTarget - seekCenter,
                                newExactTarget.x == Mathf.Infinity ?
                                Color.red : Color.white);
            }

            //Update depth counter
            depthCounter++;
        }

        //Officially set target so the agent follows it
        setTarget(newExactTarget);
    }

    /// <summary>
    /// Tries to find a valid target point within 0.1f distance of the given point.
    /// </summary>
    /// <param name="newInexactTarget"></param>
    /// <returns>Valid point or Vector3.PositiveInfinity 
    /// if no valid point is found</returns>
    private Vector3 ConvertInexactTargetToExactTarget(Vector3 newInexactTarget)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(newInexactTarget, out hit, 2f, NavMesh.AllAreas);
        return hit.position;
    }
    /// <summary>
    /// Sets the input position as the target for the agent
    /// </summary>
    /// <param name="newExactTarget"></param>
    public void setTarget(Vector3 newExactTarget)
    {
        Debug.Log("New exact target chosen");
        agent.destination = newExactTarget;
    }
}