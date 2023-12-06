using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : MonoBehaviour,
        GameListeners.IGameFinishListener,
        GameListeners.IGameStartListener,
        GameListeners.IGamePauseListener,
        GameListeners.IGameResumeListener
    {
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;

        [SerializeField] private const uint initialCount = 50;

        private readonly Queue<Bullet> bulletPool = new();

        private void Awake()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
                bulletPool.Enqueue(bullet);
            }
        }

        public Bullet Fire()
        {
            if (bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = Instantiate(prefab, worldTransform);
            }
            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            bulletPool.Enqueue(bullet);
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