using UnityEngine;

namespace ShootEmUp
{
    public class UIManager : 
        MonoBehaviour,
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener,
        GameListeners.IGamePauseListener,
        GameListeners.IGameResumeListener
    {
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject resumeButton;

        public void Awake()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
        }

        public void OnStart()
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }
        public void OnFinish()
        {
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
    }
}