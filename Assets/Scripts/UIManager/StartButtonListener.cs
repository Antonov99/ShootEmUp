using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class StartButtonListener: MonoBehaviour
    {
        [SerializeField] private GameLauncher gameLauncher;
        [SerializeField] private Button startButton;

        private void Awake()
        {
            startButton.onClick.AddListener(Launch);
        }

        private void Launch()
        {
            gameLauncher.DelayedStartGame();
            startButton.onClick.RemoveListener(Launch);
            
            startButton.gameObject.SetActive(false);
        }
    }
}