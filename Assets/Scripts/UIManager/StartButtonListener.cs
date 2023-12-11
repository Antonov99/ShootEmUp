using System;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    [Serializable]
    public sealed class StartButtonListener: IInitializable, IDisposable
    {
        private GameManager gameManager;
        private Button startButton;

        [Inject]
        public void Constructor(GameManager gameManager, Button startButton)
        {
            this.gameManager = gameManager;
            this.startButton = startButton;
        }

        public void Initialize()
        {
            startButton.onClick.AddListener(Launch);
        }

        private void Launch()
        {
            startButton.onClick.RemoveListener(Launch);
            startButton.gameObject.SetActive(false);
            gameManager.StartGame();
        }

        public void Dispose()
        {
            startButton.onClick.RemoveListener(Launch);
        }
    }
}