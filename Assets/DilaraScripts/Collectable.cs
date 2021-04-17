using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts._Core;
using Cagri.Scripts.Player;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum CollectableType
    {
        Money,
        Time,
        Pc,
        Alcohol,
    }

    public CollectableType currentCollectableType;
    
    public GameObject cObject;
    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                switch (currentCollectableType)
                {
                    case CollectableType.Money:
                        UIManager.manager.moneyPicture.SetActive(true);
                        UIManager.manager.moneyCollect = true;
                        break;
                    case CollectableType.Time:
                        UIManager.manager.timePicture.SetActive(true);
                        UIManager.manager.timeCollect = true;
                        break;
                    case CollectableType.Pc:
                        UIManager.manager.pcPicture.SetActive(true);
                        UIManager.manager.pcCollect = true;
                        break;
                    case CollectableType.Alcohol:
                        UIManager.manager.alcoholPicture.SetActive(true);
                        UIManager.manager.alcoholCollect = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Destroy(gameObject); //todo maybe cObject
            }
        }
    }
}
