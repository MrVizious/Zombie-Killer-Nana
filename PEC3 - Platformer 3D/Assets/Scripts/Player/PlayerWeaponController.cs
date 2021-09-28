using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerWeaponController : MonoBehaviour
{
    public Weapon weapon;
    public bool bulletsOnStart = true;

    private PlayerInput input;
    private PlayerAnimation animator;

    private void Start()
    {
        if (weapon == null) Debug.LogError("No weapon associated!");
        if (bulletsOnStart) weapon.ResetBullets();
        weapon.Setup(transform);
        input = GetComponent<PlayerInput>();
        animator = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        CheckShoot();
        CheckReload();
    }

    /// <summary>
    /// Checks if the shoot button is pressed down and tries to shoot if it is
    /// </summary>
    private void CheckShoot()
    {
        if (input.shotThisFrame)
        {
            if (weapon.SingleShot()) animator.PlayShootAnimation();
        }
        else if (input.shooting)
        {
            Debug.Log("Shooting kept down");
            if (weapon.ContinuousShot()) animator.PlayShootAnimation();
        }
    }

    /// <summary>
    /// Checks if the reload button is pressed and tries to reload if it is
    /// </summary>
    private void CheckReload()
    {
        if (input.reload) weapon.Reload();
    }

    /// <summary>
    /// Adds a certain amount of bullets to the extra bullets
    /// </summary>
    /// <param name="bulletsAmount">Amount of bullets to add</param>
    public void AddBullets(int bulletsAmount)
    {
        weapon.AddBullets(bulletsAmount);
    }
}
