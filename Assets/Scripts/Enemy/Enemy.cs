using UnityEngine;

namespace ShootEmUp
{
  
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;

        public void Construct(GameManager gameManager, BulletSystem bulletSystem, GameObject target)
        {
            enemyAttackAgent.SetBulletSystem(bulletSystem);
            enemyAttackAgent.SetTarget(target);
        }
    }
}