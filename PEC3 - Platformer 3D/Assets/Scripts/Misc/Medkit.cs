using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Medkit : MonoBehaviour
{
    public int healAmount;
    private Collider trigger;
    private void Start()
    {
        trigger = GetComponent<Collider>();
        //Makes sure the collider is a trigger
        trigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the other collider is of a player, heal them
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Medkit found!");
            if (other.gameObject.GetComponent<PlayerHealthController>().Heal(healAmount))
            {
                //Destroy medkit after healing
                Destroy(gameObject);
            }
        }
    }

}
