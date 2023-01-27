using Enemy.AI;
using Enemy.Attacks;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyStats stats; 
        public EnemyStats Stats => stats;
        
        
        [SerializeField] private EnemyAttack attack;
        public EnemyAttack Attack => attack;
        
        public EnemyMovement Movement { get; private set; }
        
        private void Awake()
        {
            Movement = GetComponent<EnemyMovement>();
        }
    }
}