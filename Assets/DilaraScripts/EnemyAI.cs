using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts._Core;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour

{
    //look to player
    public float MoveSpeed;
    public float MinDistance;
    //attack
    public GameObject bullet;
    private bool doesFire;
    public float fireRate;
    
    private void Update()
    {
        switch (GameManager.manager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                break;
            case GameManager.GameState.MainGame:
                if (gameObject.active);
                {
                    LookToPlayer();
                    AttackPlayer();
                }
                break;
            case GameManager.GameState.FinishGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        

    }
    private void LookToPlayer()
    {
        transform.LookAt(GameManager.manager.player.transform.position);
        if (Vector3.Distance(transform.position, GameManager.manager.player.transform.position) >= MinDistance)
        {
            transform.position += transform.forward * (MoveSpeed * Time.deltaTime);
        }
    }
    
    private void AttackPlayer()
    {
        if (!doesFire)
        {
            doesFire = true;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        GameObject objBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1/fireRate);
        doesFire = false;
    }
}
