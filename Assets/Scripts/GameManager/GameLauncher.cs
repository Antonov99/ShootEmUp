using UnityEngine;
using System.Collections;

namespace ShootEmUp
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        public void DelayedStartGame()
        {
            StartCoroutine(DelayedStart());
        }

        public IEnumerator DelayedStart()
        { 
            for (int i = 3; i > 0 ; i--)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(1);
            }
            gameManager.StartGame();
        }
    }
}