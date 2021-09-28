using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a class for testing purposes
public class RotatingObject : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.up * speed * Time.deltaTime);
    }
}
