using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class EndPoint : MonoBehaviour
{
    private Collider trigger;

    private void Start()
    {
        trigger = GetComponent<Collider>();
        trigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) SceneManager.LoadScene("EndMenu");
    }

}
