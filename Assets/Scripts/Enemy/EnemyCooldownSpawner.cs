using System;
using System.Threading.Tasks;
using Zenject;

namespace ShootEmUp
{
    public class EnemyCooldownSpawner: IInitializable,IDisposable
    {
        private EnemyManager enemyManager;
        private const int countdown = 2000;
        private bool spawning=true;

        [Inject]
        public void Construct(EnemyManager enemyManager)
        {
            this.enemyManager = enemyManager;
        }

        public void Initialize()
        {
            StartEnemySpawnAsync();
        }

        public void Dispose()
        {
            spawning = false;
        }

        private async Task StartEnemySpawnAsync()
        {
            while (spawning)
            {
                enemyManager.SpawnEnemy();
                await Task.Delay(countdown);
            }
        }
    }
}