using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ShootEmUp
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CharacterMoveController characterMoveController;
        [SerializeField] private CharacterAttackController characterAttackController;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
            Container.Bind<CharacterMoveController>().FromInstance(characterMoveController).AsSingle();
            Container.Bind<CharacterAttackController>().FromInstance(characterAttackController).AsSingle();
        }
    }
}