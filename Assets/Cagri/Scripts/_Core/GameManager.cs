using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts.Player;
using UnityEngine;

namespace Cagri.Scripts._Core
{
   public class GameManager : MonoBehaviour
   {
      public static Camera cam;
      public static GameManager manager;
      
      [Header("Camera")]
      public Transform camPlayerPos;
      public Transform camRoot;
      
      [HideInInspector]public List<GameObject> collectableList;
      
      public enum GameState
      {
         Prepare,
         MainGame,
         FinishGame,
      }
      private bool _startPrepare;
      [Header("Player")]
      public PlayerController player;
      
      private GameState _currentGameState;
      [HideInInspector]public bool winGame;
      public GameState CurrentGameState
      {
         get { return _currentGameState;}
         set
         {
            switch (value)
            {
               case GameState.Prepare:
                  _startPrepare = true;
                  UIManager.manager.startGameUi.SetActive(true);
                  UIManager.manager.menuUi.SetActive(true);
                  AudioController.instance.PlayAudio(AudioType.Oyun1);
                  break;
               case GameState.MainGame:
                  UIManager.manager.inGameUi.SetActive(true);
                  AudioController.instance.PlayAudio(AudioType.Oyun2);
                  break;
               case GameState.FinishGame:
                  UIManager.manager.inGameUi.SetActive(false);
                  AudioController.instance.StopAudio(AudioType.Oyun2, false, 0f, 0f);
                  UIManager.manager.finishGameUi.SetActive(true);
                  if (winGame)
                  {
                     UIManager.manager.winGameUI.SetActive(true);
                     AudioController.instance.PlayAudio(AudioType.Oyun3);
                  }
                  else
                  {
                     StartCoroutine(LoseGameDelay());
         
                  }

                  break;
               default:
                  throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
            _currentGameState = value;
         }
      }

      IEnumerator LoseGameDelay()
      {
         yield return new WaitForSeconds(3f);
         AudioController.instance.PlayAudio(AudioType.Oyun1, true, 0.1f, 0f);
         UIManager.manager.loseGameUI.SetActive(true);
         
      }

      [HideInInspector] public bool watchMod;
      [HideInInspector] public bool finishDoorOpen;
      
      private void Awake()
      {
         cam=Camera.main;
         manager = this;
      }
      
      private void Update()
      {
         switch (CurrentGameState)
         {
            case GameState.Prepare:
               if (!_startPrepare)
               {
                  
                  return;
               }
               break;
            case GameState.MainGame:
               if (watchMod)
               {
                  return;
               }
               player.IsGrounded();
               CamFollow();
               KillPlayer();
               break;
            case GameState.FinishGame:
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
      }
      
      private void CamFollow()
      {
         camPlayerPos.position = Vector3.Lerp(camPlayerPos.position, player.transform.position, Time.deltaTime*1.5f);
         
         cam.transform.SetParent(camRoot);
         cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition,Vector3.zero, Time.deltaTime*2.5f);
         cam.transform.localRotation = Quaternion.Lerp(cam.transform.localRotation,Quaternion.identity, Time.deltaTime*2.5f);
      }

      private void KillPlayer()
      {
         if (player._health <= 0)
         {
            player.playerAnimatorController.SetTrigger("PlayerDeath");
            AudioController.instance.PlayAudio(AudioType.SFX5);
            winGame = false;
            CurrentGameState = GameState.FinishGame;
         }
      }
   }
}
