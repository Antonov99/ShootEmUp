using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;

        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;

        private readonly Queue<Bullet> p_bulletPool = new();
        private readonly HashSet<Bullet> p_activeBullets = new();
        private readonly List<Bullet> p_cache = new();

        private void Awake()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
                p_bulletPool.Enqueue(bullet);
            }
        }

        private void FixedUpdate()
        {
            p_cache.Clear();
            p_cache.AddRange(p_activeBullets);

            for (int i = 0, count = p_cache.Count; i < count; i++)
            {
                var bullet = p_cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            if (p_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = Instantiate(prefab, worldTransform);
            }

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            if (p_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += RemoveBullet;
            }
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (p_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= RemoveBullet;
                bullet.transform.SetParent(container);
                p_bulletPool.Enqueue(bullet);
            }
        }

        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}