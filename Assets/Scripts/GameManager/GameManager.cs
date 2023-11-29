using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ShootEmUp
{
    public sealed class GameManager : SerializedMonoBehaviour
    {
        public GameState State => state;

        [SerializeField] private GameState state;
        
        [SerializeField][ShowInInspector] private readonly List<GameListeners.IGameListener> listeners = new();
        
        [SerializeField][ShowInInspector] private readonly List<GameListeners.IGameFixedUpdateListener> fixedUpdateListeners = new();
        [SerializeField][ShowInInspector] private readonly List<GameListeners.IGameUpdateListener> updateListeners = new();
        [SerializeField][ShowInInspector] private readonly List<GameListeners.IGameLateUpdateListener> lateUpdateListeners = new();
        
        private void FixedUpdate()
        {
            if (state != GameState.PLAYING)
                return;

            for (int i = 0, count = fixedUpdateListeners.Count; i < count; i++)
            {
                fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }
        
        private void Update()
        {
            if (state != GameState.PLAYING)
                return;
            
            for (int i = 0, count = updateListeners.Count; i < count; i++)
            {
                updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }
        
        private void LateUpdate()
        {
            if (state != GameState.PLAYING)
                return;

            for (int i = 0, count = lateUpdateListeners.Count; i < count; i++)
            {
                lateUpdateListeners[i].OnLateUpdate(Time.fixedDeltaTime);
            }
        }

        public void AddListener(GameListeners.IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            listeners.Add(listener);
            
            if (listener is GameListeners.IGameFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Add(fixedUpdateListener);
            }
            
            if (listener is GameListeners.IGameUpdateListener updateListener)
            {
                updateListeners.Add(updateListener);
            }

            if (listener is GameListeners.IGameLateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Add(lateUpdateListener);
            }

        }


        public void RemoveListener(GameListeners.IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            listeners.Remove(listener);

            if (listener is GameListeners.IGameFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Remove(fixedUpdateListener);
            }
            
            if (listener is GameListeners.IGameUpdateListener updateListener)
            {
                updateListeners.Remove(updateListener);
            }

            if (listener is GameListeners.IGameLateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Remove(lateUpdateListener);
            }
        }

        public void StartGame()
        {
            if (state!=GameState.OFF)
                return;
            
            foreach (var listener in listeners)
            {
                if (listener is GameListeners.IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            state = GameState.PLAYING;
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            if (state!=GameState.PLAYING)
                return;

            foreach (var listener in listeners)
            {
                if (listener is GameListeners.IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            state = GameState.PAUSED;
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            if (state!=GameState.PAUSED)
                return;

            foreach (var listener in listeners)
            {
                if (listener is GameListeners.IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            state = GameState.PLAYING;
            Time.timeScale = 1;
        }

        public void FinishGame()
        {
            if (state is GameState.OFF or GameState.FINISHED )
                return;

            foreach (var listener in listeners)
            {
                if (listener is GameListeners.IGameFinishListener finishListener)
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