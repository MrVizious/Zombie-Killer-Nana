using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{

    public Weapon weapon;

    public Text bulletsInfo, weaponName;

    private void Update()
    {
        bulletsInfo.text = weapon.currentMagazineBullets + "/" + weapon.extraBullets;
        weaponName.text = weapon.weaponName;
    }
}
