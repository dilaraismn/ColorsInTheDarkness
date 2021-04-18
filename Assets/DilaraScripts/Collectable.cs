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
        Book,
        Duck,
        Guitar,
    }

    public CollectableType currentCollectableType;
    
    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            player.collectableTextActive.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                switch (currentCollectableType)
                {
                    case CollectableType.Book:
                        UIManager.manager.bookPicture.SetActive(true);
                        UIManager.manager.bookCollect = true;
                        player.collectableTextActive.gameObject.SetActive(false);
                        break;
                    case CollectableType.Duck:
                        UIManager.manager.duckPicture.SetActive(true);
                        UIManager.manager.duckCollect = true;
                        player.collectableTextActive.gameObject.SetActive(false);
                        break;
                    case CollectableType.Guitar:
                        UIManager.manager.guitarPicture.SetActive(true);
                        UIManager.manager.guitarCollect = true;
                        player.collectableTextActive.gameObject.SetActive(false);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                GetComponent<Collider>().enabled = false;
                GameManager.manager.collectableList.Add(gameObject);
                gameObject.SetActive(false); 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            switch (currentCollectableType)
            {
                case CollectableType.Book:
                    player.collectableTextActive.text = "Collectable  Scriptinde Kitap Icin  Degistir";
                    break;
                case CollectableType.Duck:
                    player.collectableTextActive.text = "Collectable Scriptinde Ordek Icin Degistir";
                    break;
                case CollectableType.Guitar:  
                    player.collectableTextActive.text = "Collectable Scriptinde Gitar Icin Degistir";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            player.collectableTextActive.gameObject.SetActive(false);
        }
    }
}
