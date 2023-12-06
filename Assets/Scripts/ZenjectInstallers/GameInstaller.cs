using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerService playerService;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private StartButtonListener startButtonListener;
        
        
        public override void InstallBindings()
        {
            BulletSystemInstaller();
            PlayerInstaller();
            GameManagerInstaller();
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

        private void GameManagerInstaller()
        {
            Container.Bind<GameManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StartButtonListener>().FromInstance(startButtonListener).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterDeathObserver>().AsSingle().NonLazy();
        }
    }
}