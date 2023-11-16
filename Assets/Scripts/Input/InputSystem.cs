using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour
    {
        public event Action OnSpaceEntered;

        public float HorizontalDirection { get; private set; }

        [SerializeField]
        private GameObject character;

        private MoveComponent moveComponent;

        private void Awake()
        {
            moveComponent = character.GetComponent<MoveComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSpaceEntered?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalDirection = 1;
            }
            else
            {
                HorizontalDirection = 0;
            }
        }
        
        private void FixedUpdate()
        {
            moveComponent.MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}