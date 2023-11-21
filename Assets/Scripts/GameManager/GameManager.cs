using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public void GameOver()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}