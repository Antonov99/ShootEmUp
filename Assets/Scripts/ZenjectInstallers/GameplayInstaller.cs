using Zenject;

namespace ShootEmUp
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputSystem>().AsSingle().NonLazy();
        }
    }
}