using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;

        [SerializeField] private GameObject character;

        [SerializeField] private Transform worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform container;

        [SerializeField] private GameObject prefab;

        private readonly Queue<GameObject> p_enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < 6; i++)
            {
                var enemy = Instantiate(prefab, container);
                p_enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!p_enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(character);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            p_enemyPool.Enqueue(enemy);
        }
    }
}