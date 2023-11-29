using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCooldownSpawner :
        MonoBehaviour,
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private float countdown;

        public void OnStart()
        {
            StartCoroutine(nameof(StartSpawn));
        }

        public void OnFinish()
        {
            StopCoroutine(nameof(StartSpawn));
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(countdown);
                enemyManager.SpawnEnemy();
            }
        }
    }
}