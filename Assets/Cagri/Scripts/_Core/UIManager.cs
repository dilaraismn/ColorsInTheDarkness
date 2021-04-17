using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cagri.Scripts._Core
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager manager;

        public GameObject startGameUi;
        public GameObject inGameUi;
        public GameObject finishGameUi;

        public GameObject winGameUI;
        public GameObject loseGameUI;
        
        public GameObject moneyPicture;
        public GameObject timePicture;
        public GameObject pcPicture;
        public GameObject alcoholPicture;

        [HideInInspector]public bool moneyCollect;
        [HideInInspector]public bool timeCollect;
        [HideInInspector]public bool pcCollect;
        [HideInInspector]public bool alcoholCollect;

        private void Awake()
        {
            inGameUi.SetActive(false);
            startGameUi.SetActive(false);
            finishGameUi.SetActive(false);
            moneyPicture.SetActive(false);
            timePicture.SetActive(false);
            pcPicture.SetActive(false);
            alcoholPicture.SetActive(false);
            winGameUI.SetActive(false);
            loseGameUI.SetActive(false);
            manager = this;
            
            GameManager.manager.CurrentGameState = GameManager.GameState.Prepare;
        }


        private void Update()
        {
            if (moneyCollect&&timeCollect&&pcCollect&&alcoholCollect&&!GameManager.manager.finishDoorOpen)
            {
                GameManager.manager.finishDoorOpen = true;
            }
        }

        public void StartGameButton()
        {
            StartCoroutine(StartUIDisable());
        }

        IEnumerator StartUIDisable()
        {
            startGameUi.SetActive(false);
            yield return new WaitForSeconds(2f);
            GameManager.manager.CurrentGameState = GameManager.GameState.MainGame;
        }

        public void RetryButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
