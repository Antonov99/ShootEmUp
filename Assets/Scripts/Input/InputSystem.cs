using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour,
        GameListeners.IGameUpdateListener
    {
        public event Action OnHeroFire;
        public event Action<Vector2> OnMove;

        public void OnUpdate(float timeDelta)
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