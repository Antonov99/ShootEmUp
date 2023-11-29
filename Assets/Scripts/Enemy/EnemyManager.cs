using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;

        private readonly HashSet<GameObject> activeEnemies = new();

        public void SpawnEnemy()
        {
            var enemy = enemyPool.SpawnEnemy();
            if (enemy != null)
            {
                if (activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnDestroyed;

                enemyPool.UnspawnEnemy(enemy);
            }
        }
    }
}