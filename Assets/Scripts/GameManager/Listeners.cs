using UnityEngine;

namespace ShootEmUp
{
    public class Listeners : MonoBehaviour
    {
        public interface IGameListener
        {
        }
        public interface IGameStartListener : IGameListener
        {
            void OnStart();
        }
        public interface IGameFinishListener : IGameListener
        {
            void OnFinish();
        }
        public interface IGamePauseListener : IGameListener
        {
            void OnPause();
        }
        public interface IGameResumeListener : IGameListener
        {
            void OnResume();
        }

        public interface IGameUpdateListener : IGameListener
        {
            void OnUpdate(float deltaTime);
        }
        public interface IGameFixedUpdateListener : IGameListener
        {
            void OnFixedUpdate(float deltaTime);
        }

    }
}