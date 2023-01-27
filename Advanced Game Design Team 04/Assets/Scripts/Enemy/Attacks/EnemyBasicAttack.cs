using Player;
using UnityEngine;

namespace Enemy.Attacks
{
    [CreateAssetMenu(fileName = "new Attack", menuName = "ScriptableObjects/Enemy/Attacks/BasicAttack", order = 1)]
    public class EnemyBasicAttack : EnemyAttack
    {
        public override void Attack(int damage, PlayerHealthNew playerHealth)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}