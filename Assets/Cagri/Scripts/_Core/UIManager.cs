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

        [Header("StartGame")]
        public GameObject startGameUi;
        public GameObject menuUi;
        public GameObject creditsUi;
        
        [Header("Ingame")]
        public GameObject inGameUi;

        [Header("FinishGame")]
        public GameObject finishGameUi;
        public GameObject winGameUI;
        public GameObject loseGameUI;
        
        [Header("InGameUIImage")]
        public GameObject bookPicture;
        public GameObject duckPicture;
        public GameObject guitarPicture;

        [HideInInspector] public bool bookCollect;
        [HideInInspector] public bool duckCollect;
        [HideInInspector] public bool guitarCollect;

        public bool ui;

        private void Awake()
        {
            menuUi.SetActive(false);
            creditsUi.SetActive(false);
            inGameUi.SetActive(false);
            startGameUi.SetActive(false);
            finishGameUi.SetActive(false);
            bookPicture.SetActive(false);
            duckPicture.SetActive(false);
            guitarPicture.SetActive(false);
            winGameUI.SetActive(false);
            loseGameUI.SetActive(false);
            manager = this;

        }

        private void Start()
        {
            GameManager.manager.CurrentGameState = GameManager.GameState.Prepare;
        }


        private void Update()
        {
            if (bookCollect && duckCollect && guitarCollect && !GameManager.manager.finishDoorOpen)
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

        public void Credits()
        {
            menuUi.SetActive(false);
            creditsUi.SetActive(true);
        }

        public void BackMenu()
        {
            menuUi.SetActive(true);
            creditsUi.SetActive(false);
        }

        public void QuitButton()
        {
            Application.Quit();
        }

    }
}
