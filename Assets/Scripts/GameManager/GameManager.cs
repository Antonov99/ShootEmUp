using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }

    public sealed class GameManager : MonoBehaviour
    {
        public GameState State
        {
            get { return state; }
        }

        [SerializeField] private GameState state;

        private readonly List<Listeners.IGameListener> listeners = new();
        private readonly List<Listeners.IGameUpdateListener> updateListeners = new();
        private readonly List<Listeners.IGameFixedUpdateListener> fixedUpdateListeners = new();

        private void Update()
        {
            if (state != GameState.PLAYING)
            {
                return;
            }

            var deltaTime = Time.deltaTime;
            for (int i = 0, count = updateListeners.Count; i < count; i++)
            {
                var listener = updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (state != GameState.PLAYING)
            {
                return;
            }

            var deltaTime = Time.fixedDeltaTime;
            for (int i = 0, count = fixedUpdateListeners.Count; i < count; i++)
            {
                var listener = fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }

        public void AddListener(Listeners.IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            listeners.Add(listener);

            if (listener is Listeners.IGameUpdateListener updateListener)
            {
                updateListeners.Add(updateListener);
            }

            if (listener is Listeners.IGameFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Add(fixedUpdateListener);
            }
        }


        public void RemoveListener(Listeners.IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            listeners.Remove(listener);

            if (listener is Listeners.IGameUpdateListener updateListener)
            {
                updateListeners.Remove(updateListener);
            }

            if (listener is Listeners.IGameFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Remove(fixedUpdateListener);
            }
        }

        public void StartGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is Listeners.IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            state = GameState.PLAYING;
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is Listeners.IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            state = GameState.PAUSED;
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is Listeners.IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            state = GameState.PLAYING;
            Time.timeScale = 1;
        }

        public void FinishGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is Listeners.IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }

            state = GameState.FINISHED;
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

    }
}