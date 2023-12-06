using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCooldownSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private float countdown;

        public void OnEnable()
        {
            StartCoroutine(nameof(StartSpawn));
        }

        public void OnDisable()
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