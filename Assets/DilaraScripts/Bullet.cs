using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts._Core;
using Cagri.Scripts.Player;
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
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            if (player._health>0f)
            {
                player._health -= 5;
                AudioController.instance.PlayAudio(AudioType.SFX2);
            }
        }
        Destroy(gameObject);
    }
}
