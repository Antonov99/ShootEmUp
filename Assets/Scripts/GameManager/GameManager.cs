using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager 
    {
        public GameState State => state;

        private GameState state;

        public void StartGame()
        {
            Debug.Log("d");
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