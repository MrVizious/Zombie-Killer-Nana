using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Player/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName = "Pistol";

    //Bullets info
    public int magazineSize = 20;
    public int currentMagazineBullets = 20, extraBullets = 20;


    //Shot information
    public int damagePerBullet = 30;
    public bool isAutomatic = false;
    public float secondsBetweenShots = 0.3f;
    private float timeOfLastShot = 0f;

    //Player info for shooting purposes
    private Transform playerTransform;

    /// <summary>
    /// Gives the weapon a total of 2 magazines worth of bullets, one
    /// already loaded
    /// </summary>
    public void ResetBullets()
    {
        currentMagazineBullets = magazineSize;
        extraBullets = magazineSize;
    }

    /// <summary>
    /// Sets the necessary information for the weapon
    /// </summary>
    /// <param name="newPlayerTransform"></param>
    public void Setup(Transform newPlayerTransform)
    {
        timeOfLastShot = 0f;
        playerTransform = newPlayerTransform;
    }

    /// <summary>
    /// Shoots if the weapon is automatic. Should be called when just pressing
    /// the fire button once
    /// </summary>
    /// <returns>True if could shoot, false if not</returns>
    public bool SingleShot()
    {
        if (CanShoot())
        {
            timeOfLastShot = Time.time;
            SpendBullet();

            Color hitColor = Color.yellow;

            //Raycast to hit enemy
            RaycastHit hit;
            if (Physics.Raycast(playerTransform.position + playerTransform.up * 1.325f,
                                playerTransform.TransformDirection(Vector3.forward),
                                out hit,
                                Mathf.Infinity,
                                1 << LayerMask.NameToLayer("Enemy"))
            )
            {
                hit.transform.GetComponent<ZombieHealthController>().Damage(damagePerBullet);
                Debug.Log("Enemy hit!");
                hitColor = Color.red;
            }

            Debug.DrawRay(playerTransform.position + playerTransform.up * 1.325f,
                        playerTransform.TransformDirection(Vector3.forward) * 20f,
                        hitColor, 2f);

            return true;
        }
        return false;
    }

    /// <summary>
    /// Shoots if the weapon is automatic. Should be called when keeping the fire
    /// button pressed
    /// </summary>
    /// <returns>True if could shoot, false if not</returns>
    public bool ContinuousShot()
    {
        if (!isAutomatic) return false;
        return SingleShot();
    }

    /// <summary>
    /// Tries to spend a bullet
    /// </summary>
    /// <returns>True if the bullet was spent, false if not</returns>
    private bool SpendBullet()
    {
        if (currentMagazineBullets > 0)
        {
            currentMagazineBullets--;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if the bullets in the magazine and the time since the last
    /// shot are good for shooting
    /// </summary>
    /// <returns>True if can shoot, false if not</returns>
    private bool CanShoot()
    {
        return (currentMagazineBullets > 0)
                && (Time.time - timeOfLastShot >= secondsBetweenShots);
    }

    /// <summary>
    /// Reloads the weapon
    /// </summary>
    public void Reload()
    {
        //Calculates how many bullets to reload
        int bulletsToAdd = Mathf.Min(magazineSize - currentMagazineBullets,
                                    extraBullets);

        //Adds the bullets to the current magazine
        currentMagazineBullets += bulletsToAdd;

        //Substracts the bullets from the extra bullets
        extraBullets -= bulletsToAdd;
    }

    /// <summary>
    /// Adds a certain amount of extra bullets
    /// </summary>
    /// <param name="bulletsAmount">Amount of bullets to add</param>
    public void AddBullets(int bulletsAmount)
    {
        extraBullets += bulletsAmount;
    }
}