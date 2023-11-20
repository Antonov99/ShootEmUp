using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnCollisionEntered;

        [NonSerialized] public bool isPlayer;
        [NonSerialized] public int damage;

        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.OnCollisionEntered?.Invoke(this);
            if (!collision.gameObject.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (this.isPlayer == team.IsPlayer)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(this.damage);
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            this.gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.spriteRenderer.color = color;
        }
    }
}