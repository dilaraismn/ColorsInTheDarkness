using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts._Core;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Transform particle;

    private void Start()
    {
        transform.LookAt(GameManager.manager.player.transform.position);
    }

    void Update()
    {
        transform.position += transform.forward * (bulletSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, GameManager.manager.player.transform.position) >= 20)
        {
            Destroy(gameObject, 3f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //todo particle
    }
}
