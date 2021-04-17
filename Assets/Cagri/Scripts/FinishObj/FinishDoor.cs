using Cagri.Scripts._Core;
using Cagri.Scripts.Player;
using UnityEngine;

namespace Cagri.Scripts.FinishObj
{
    public class FinishDoor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player && GameManager.manager.finishDoorOpen)
            {
                GameManager.manager.winGame = true;
                GameManager.manager.CurrentGameState = GameManager.GameState.FinishGame;
                // todo maybe animation 
            }
        }
    }
}
