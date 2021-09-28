using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float speed = 4f;
    public Transform player;
    public CameraRail rail;
    void FixedUpdate()
    {
        transform.position = rail.closestNode;
        transform.position = Vector3.Slerp(transform.position, rail.closestNode, Time.deltaTime * speed);
        transform.LookAt(player);
    }
}
