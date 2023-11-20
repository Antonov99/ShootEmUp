using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour
    {
        public event Action OnHeroFire;
        public event Action<Vector2> OnMove;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnHeroFire?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnMove.Invoke(new Vector2(-1,0)* Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnMove.Invoke(new Vector2(1, 0) * Time.fixedDeltaTime);
            }
            else
            {
                OnMove.Invoke(new Vector2(0, 0) * Time.fixedDeltaTime);
            }
        }
    }
}