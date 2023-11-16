using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private InputSystem inputSystem;
        private MoveComponent moveComponent;

        private void Awake()
        {
            moveComponent = character.GetComponent<MoveComponent>();
        }

        public void OnEnable()
        {
            inputSystem.OnMove += OnMove;
        }

        public void OnDisable()
        {
            inputSystem.OnMove -= OnMove;
        }

        public void OnMove(Vector2 pos)
        {
            moveComponent.MoveByRigidbodyVelocity(pos);
        }
    }
}