using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager :
        MonoBehaviour,
        Listeners.IGameFinishListener,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener
    {
        [SerializeField] private EnemyPool enemyPool;
        
        private readonly HashSet<GameObject> activeEnemies = new();

        private void Awake()
        {
            enabled = false;
        }
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
                    }    
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

        public void OnStart()
        {
            enabled = true;
        }

        public void OnResume()
        {
            enabled = true;
        }

        public void OnFinish()
        {
            enabled = false;
        }

        public void OnPause()
        {
            enabled = false;
        }
    }
}