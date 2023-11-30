using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveController : 
        MonoBehaviour,
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener
    {
        [SerializeField] private GameObject character;
        private InputSystem inputSystem;

        private MoveComponent moveComponent;

        [Inject]
        public void Construct(InputSystem _inputSystem)
        {
            inputSystem = _inputSystem;
        }

        private void Awake()
        {
            moveComponent = character.GetComponent<MoveComponent>();
        }

        public void OnStart()
        {
            inputSystem.OnMove += OnMove;
        }

        public void OnFinish()
        {
            inputSystem.OnMove -= OnMove;
        }

        private void OnMove(Vector2 pos)
        {
            moveComponent.MoveByRigidbodyVelocity(pos);
        }
    }
}