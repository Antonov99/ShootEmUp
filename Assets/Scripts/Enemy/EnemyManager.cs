using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        
        private readonly HashSet<GameObject> p_activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (p_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
                    }    
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (p_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnDestroyed;

                enemyPool.UnspawnEnemy(enemy);
            }
        }
    }
}