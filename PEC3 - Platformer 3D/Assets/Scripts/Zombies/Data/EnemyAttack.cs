using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObjects/Enemy/Attack", order = 1)]
public class EnemyAttack : ScriptableObject
{
    public int damagePerAttack = 20;
    public float attackReach = 2f, secondsBetweenAttacks = 0.8f;


    /// <summary>
    /// Tries to find the player and damages them if found
    /// </summary>
    /// <returns>True if found, false if not</returns>
    public bool TryToAttack(Transform enemyTransform)
    {

        Color hitColor = Color.yellow;

        //Raycast to hit player
        for (int i = -1; i < 2; i++)
        {
            Quaternion angledQuaternion = new Quaternion();
            angledQuaternion.eulerAngles = Vector3.up * 15 * i;

            RaycastHit hit;
            if (Physics.Raycast(enemyTransform.position + enemyTransform.up * 1.325f,
                                enemyTransform.TransformDirection(
                                    angledQuaternion * Vector3.forward
                                ),
                                out hit,
                                attackReach,
                                1 << LayerMask.NameToLayer("Player"))
            )
            {
                hit.transform.GetComponent<PlayerHealthController>().Damage(damagePerAttack);
                Debug.Log("Player hit!");
                hitColor = Color.red;
                Debug.DrawRay(enemyTransform.position + enemyTransform.up * 1.325f,
                            enemyTransform.TransformDirection(
                                angledQuaternion * Vector3.forward
                            ) * attackReach,
                            hitColor, 0.3f);
                return true;
            }
            Debug.DrawRay(enemyTransform.position + enemyTransform.up * 1.325f,
                        enemyTransform.TransformDirection(
                            angledQuaternion * Vector3.forward
                        ) * attackReach,
                        hitColor, 0.3f);
        }


        return false;
    }
}
