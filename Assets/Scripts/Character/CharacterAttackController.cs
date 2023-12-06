using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterAttackController : IInitializable, IDisposable
    {
        private InputSystem inputSystem;
        private BulletSystem bulletSystem;
        private BulletConfig bulletConfig;
        
        private GameObject character;
        
        [Inject]
        public void Construct(
            InputSystem inputSystem, 
            BulletConfig bulletConfig, 
            BulletSystem bulletSystem, 
            PlayerService playerService)
        {
            this.inputSystem = inputSystem;
            this.bulletConfig = bulletConfig;
            this.bulletSystem = bulletSystem;
            character = playerService.Character;
        }
        
        public void Initialize()
        {
            inputSystem.OnHeroFire += OnFlyBullet;
        }

        public void Dispose()
        {
            inputSystem.OnHeroFire -= OnFlyBullet;
        }

        private void OnFlyBullet()
        {
            Debug.Log(bulletConfig.physicsLayer);
            Debug.Log(bulletConfig.color);
            Debug.Log(bulletConfig.damage);
            Debug.Log(bulletConfig.speed);
            var weapon = character.GetComponent<WeaponComponent>();
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
            });
        }
    }
}