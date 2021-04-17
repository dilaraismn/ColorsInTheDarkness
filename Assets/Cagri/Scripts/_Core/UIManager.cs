using System;
using UnityEngine;

namespace Cagri.Scripts._Core
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager manager;

        public GameObject startGameUi;
        public GameObject inGameUi;
        public GameObject finishGameUi;
        
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
            manager = this;
        }


        private void Update()
        {
            if (moneyCollect&&timeCollect&&pcCollect&&alcoholCollect)
            {
                GameManager.manager.finishDoorOpen = true;
            }
        }
    }
}
