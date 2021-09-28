using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{

    public Transform beginTransform;
    public float laserLength = 10f;

    private LineRenderer laser;
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        //Make the laser use the world space for coordinates
        laser.useWorldSpace = true;
        if (beginTransform == null) Debug.LogError("No Begin Transform specified");
    }

    void Update()
    {
        UpdatePointsPositions();
    }

    /// <summary>
    /// Updates the positions of the beginning and end points
    /// </summary>
    private void UpdatePointsPositions()
    {
        laser.SetPosition(0, beginTransform.position + transform.forward * laserLength);
        laser.SetPosition(1, beginTransform.position);
    }
}
