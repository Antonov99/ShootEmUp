using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterAttackController : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private InputSystem inputSystem;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;

        public void OnEnable()
        {
            inputSystem.OnHeroFire += OnFlyBullet;
        }

        public void OnDisable()
        {
            inputSystem.OnHeroFire -= OnFlyBullet;
        }

        private void OnFlyBullet()
        {
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