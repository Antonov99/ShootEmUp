using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;

        [SerializeField] GameManager gameManager;

        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;

        [SerializeField] private GameObject character;

        [SerializeField] private Transform worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform container;

        [SerializeField] private GameObject prefab;

        [SerializeField] private const uint count = 7;

        [SerializeField][ShowInInspector] private readonly Queue<GameObject> enemyPool = new();

        private void Awake()
        {
            for (var i = 0; i < count; i++)
            {
                var enemy = Instantiate(prefab, container);
                enemyPool.Enqueue(enemy);
                enemy.GetComponent<Enemy>().Construct(gameManager, bulletSystem, character);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }
            
            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            enemyPool.Enqueue(enemy);

        }
    }
}