using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts.Player;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter(Collider collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player)
        {
            if (enemy!=null)
            {
                enemy.SetActive(true);

            }
        }
    }
}
