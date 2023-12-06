using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class InputSystem : ITickable
    {
        public event Action OnHeroFire;
        public event Action<Vector2> OnMove;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnHeroFire?.Invoke();
            }
            
            OnMove?.Invoke(GetMovementDirection());
        }

        private Vector2 GetMovementDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return Vector2.left*Time.fixedDeltaTime;
            
            if (Input.GetKey(KeyCode.RightArrow))
                return Vector2.right*Time.fixedDeltaTime;
            
            return Vector2.zero;
            
        }
    }
}