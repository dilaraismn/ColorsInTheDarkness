using Cagri.Scripts._Core;
using Cagri.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player)
        {
            GameManager.manager.winGame = true;
            GameManager.manager.CurrentGameState = GameManager.GameState.FinishGame;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.playerAnimatorController.SetBool("Walk", false);
        }
    }
}
