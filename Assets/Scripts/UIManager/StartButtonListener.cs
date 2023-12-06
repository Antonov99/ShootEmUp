using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    [Serializable]
    public class StartButtonListener: IInitializable
    {
        private GameManager gameManager;
        [field:SerializeField] private Button startButton;

        [Inject]
        public void Constructor(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Initialize()
        {
            startButton.onClick.AddListener(Launch);
        }

        private void Launch()
        {
            gameManager.StartGame();
            startButton.onClick.RemoveListener(Launch);
            
            startButton.gameObject.SetActive(false);
        }
    }
}