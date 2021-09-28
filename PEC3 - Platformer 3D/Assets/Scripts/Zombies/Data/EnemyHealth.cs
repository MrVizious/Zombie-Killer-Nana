using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "ScriptableObjects/Enemy/Health", order = 1)]
public class EnemyHealth : ScriptableObject
{
    public int maxHealth;
}
