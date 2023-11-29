using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : 
        MonoBehaviour,
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener
    {
        [SerializeField] private GameObject character;
        [SerializeField] private InputSystem inputSystem;

        private MoveComponent moveComponent;

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