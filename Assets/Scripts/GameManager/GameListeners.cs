using UnityEngine;

namespace ShootEmUp
{
    public class GameListeners : MonoBehaviour
    {
        public interface IGameListener
        {
        }

        public interface IGameStartListener : IGameListener
        {
            void OnStart();
        }

        public interface IGamePauseListener : IGameListener
        {
            void OnPause();
        }

        public interface IGameResumeListener : IGameListener
        {
            void OnResume();
        }

        public interface IGameFinishListener : IGameListener
        {
            void OnFinish();
        }

        public interface IGameFixedUpdateListener : IGameListener
        {
            void OnFixedUpdate(float fixedDeltaTime);
        }

        public interface IGameUpdateListener : IGameListener
        {
            void OnUpdate(float deltaTime);
        }

        public interface IGameLateUpdateListener : IGameListener
        {
            void OnLateUpdate(float deltaTime);
        }
    }
}