using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveController : IInitializable, IDisposable
    {
        private GameObject character;
        private InputSystem inputSystem;

        private MoveComponent moveComponent;

        [Inject]
        private void Construct(InputSystem inputSystem, PlayerService playerService)
        {
            this.inputSystem = inputSystem;
            character = playerService.Character;
        }

        public void Initialize()
        {
            moveComponent = character.GetComponent<MoveComponent>();
            inputSystem.OnMove += OnMove;
        }

        public void Dispose()
        {
            inputSystem.OnMove -= OnMove;
        }

        private void OnMove(Vector2 pos)
        {
            moveComponent.MoveByRigidbodyVelocity(pos);
        }
    }
}