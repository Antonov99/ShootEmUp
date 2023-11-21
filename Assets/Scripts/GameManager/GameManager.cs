using UnityEngine;
using System.Collections.Generic;

namespace ShootEmUp
{
    public enum GameState
    {
        None,
        Start,
        Finish,
        Pause,
        Resume
    }

    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameState gameState;

        private List<Listeners.IGameListener> listeners = new();

        public void AddListener(Listeners.IGameListener listener)
        {
            listeners.Add(listener);
        }
        private void OnStart()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            gameState = GameState.Start;
        }

        private void Finish()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }
            gameState = GameState.Finish;
        }

        private void Pause()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }
            gameState = GameState.Pause;
        }

        private void Resume()
        {
            foreach (var gameListener in listeners)
            {
                if (gameListener is Listeners.IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }
            gameState = GameState.Resume;
        }
        public void GameOver()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}