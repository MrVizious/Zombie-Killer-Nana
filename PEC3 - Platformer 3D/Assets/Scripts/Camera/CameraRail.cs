using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraRail : MonoBehaviour
{
    public float secondsBetweenUpdate = 0.05f;
    public int inBetweenNodes = 30;
    public List<Vector3> initialCameraPositions;
    public Vector3 closestNode;
    public Transform player;

    private List<Vector3> nodes;
    private float lastUpdateTime = 0f;

    private void Start()
    {
        initialCameraPositions = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++)
        {
            initialCameraPositions.Add(
                transform.Find("Position (" + i + ")").transform.position
            );
        }
        nodes = new List<Vector3>();
        for (int i = 0; i < initialCameraPositions.Count - 1; i++)
        {
            nodes.Add(initialCameraPositions[i]);
            for (int step = 1; step <= inBetweenNodes; step++)
            {
                Vector3 totalDistance =
                    initialCameraPositions[i + 1]
                    - initialCameraPositions[i];
                Vector3 steppedDistance =
                    (totalDistance / (inBetweenNodes + 1)) * step;
                Vector3 finalPosition =
                    initialCameraPositions[i] + steppedDistance;
                nodes.Add(finalPosition);
            }
        }
        nodes.Add(
            initialCameraPositions[initialCameraPositions.Count - 1]
        );
    }

    private void Update()
    {
        if (Time.time - lastUpdateTime >= secondsBetweenUpdate)
        {
            Debug.Log("Updating closest");
            lastUpdateTime = Time.time;
            UpdateClosestNode();
        }
        if (Input.GetKeyDown(KeyCode.O)) DrawLines();
    }

    /// <summary>
    /// Updates which of the nodes is closest to the player
    /// </summary>
    public void UpdateClosestNode()
    {
        Vector3 playerPosition = player.position;
        closestNode = nodes.Aggregate((x, y) =>
                        Vector3.Distance(x, playerPosition)
                        < Vector3.Distance(y, playerPosition)
                        ? x : y);
    }

    private void DrawLines()
    {
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            Debug.DrawLine(nodes[i], nodes[i + 1], Color.red, 5f);
        }
    }

}
