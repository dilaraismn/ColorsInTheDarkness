using System;
using UnityEngine;

namespace Cagri.Scripts._Core
{
   public class GameManager : MonoBehaviour
   {
      public static Camera cam;
      public static GameManager manager;
      
      
      public enum GameState
      {
         Prepare,
         MainGame,
         FinishGame,
      }
      private bool _startPrepare;
      
      private GameState _currentGameState;

      public GameState CurrentGameState
      {
         get { return _currentGameState;}
         set
         {
            switch (value)
            {
               case GameState.Prepare:
                  
                  
                  _startPrepare = true;
                  
                  break;
               case GameState.MainGame:
                  break;
               case GameState.FinishGame:
                  break;
               default:
                  throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
            _currentGameState = value;
         }
      }
   
      private void Awake()
      {
         cam=Camera.main;
         manager = this;
      }

      private void Start()
      {
         CurrentGameState = GameState.Prepare;
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
               Debug.Log("1");
               break;
            case GameState.MainGame:
               break;
            case GameState.FinishGame:
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
      }
      
   }
}
