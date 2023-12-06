using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerService playerService;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;
        
        public override void InstallBindings()
        {
            BulletSystemInstaller();
            PlayerInstaller();
        }
        
        private void BulletSystemInstaller()
        {
            Container.Bind<BulletConfig>().FromInstance(bulletConfig).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletSystem>().FromInstance(bulletSystem).AsSingle().NonLazy();
        }
        
        private void PlayerInstaller()
        {
            Container.Bind<PlayerService>().FromInstance(playerService).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterAttackController>().AsSingle().NonLazy();
        }
    }
}