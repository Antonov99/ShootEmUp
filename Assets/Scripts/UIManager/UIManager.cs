using UnityEngine;

namespace ShootEmUp
{
    public class UIManager : 
        MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener
    {
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject resumeButton;

        [SerializeField] private GameLauncher gameLauncher;

        public void Awake()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
        }

        public void OnStart()
        {
            startPanel.SetActive(false);
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }
        public void OnFinish()
        {
            startPanel.SetActive(false);
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
        }
        public void OnPause()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }
        public void OnResume()
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }

        public void StartWithTimer()
        {
            startPanel.SetActive(false);
            gameLauncher.DelayedStartGame();
        }

    }
}