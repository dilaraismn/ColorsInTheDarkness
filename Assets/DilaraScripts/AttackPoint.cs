using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts.Player;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       EnemyAI enemy = other.GetComponent<EnemyAI>();
       if (enemy)
       {
           Destroy(enemy.gameObject);
       }
    }
}
