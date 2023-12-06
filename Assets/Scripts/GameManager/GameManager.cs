using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager 
    {
        public GameState State => state;

        private GameState state;

        public void StartGame()
        {
            state = GameState.PLAYING;
            Debug.Log("Start");
            Time.timeScale = 1f;
        }

        public void FinishGame()
        {
            state = GameState.FINISHED;
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

    }
}