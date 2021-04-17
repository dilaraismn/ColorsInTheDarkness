using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts.Player;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject cObject;
    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
