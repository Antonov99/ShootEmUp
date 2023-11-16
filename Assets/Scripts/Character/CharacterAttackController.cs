using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterAttackController: MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private InputSystem inputSystem;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public void OnEnable()
        {
            inputSystem.OnSpaceEntered += OnFlyBullet;
        }

        public void OnDisable()
        {
            inputSystem.OnSpaceEntered -= OnFlyBullet;
        }

        public void OnFlyBullet()
        {
            var weapon = character.GetComponent<WeaponComponent>();
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) _bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage =_bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}