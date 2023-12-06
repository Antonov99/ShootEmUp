using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : 
        MonoBehaviour,
        GameListeners.IGameFixedUpdateListener
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private BulletSystem bulletSystem;

        private GameObject target;
        private float currentTime;


        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void Reset()
        {
            currentTime = countdown;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (!moveAgent.IsReached)
            {
                return;
            }
            
            if (!target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            currentTime -= Time.fixedDeltaTime;
            if (currentTime <= 0)
            {
                Fire();
                Reset();
            }
        }

        private void Fire()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2) target.transform.position - startPosition;
            var direction = vector.normalized;
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.ENEMY,
                color = Color.red,
                damage = 1,
                position = startPosition,
                velocity = direction * 2.0f
            });
        }

        public void SetBulletSystem(BulletSystem bulletSystem)
        {
            this.bulletSystem = bulletSystem;
        }
    }
}