using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AmmoBox : MonoBehaviour
{
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
            Debug.Log("Ammo box found!");

            other.GetComponent<PlayerWeaponController>().AddBullets(
                other.GetComponent<PlayerWeaponController>().weapon.magazineSize
            );

            //Destroy medkit after healing
            Destroy(gameObject);
        }
    }

}
