using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyManager
    {
        private EnemyPool enemyPool;
        private readonly HashSet<GameObject> activeEnemies = new();

        [Inject]
        public void Construct(EnemyPool enemyPool)
        {
            this.enemyPool = enemyPool;
        }

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