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
            startPanel.SetActive(true);
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