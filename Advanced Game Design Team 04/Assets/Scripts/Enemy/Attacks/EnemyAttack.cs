using Player;
using UnityEngine;

namespace Enemy.Attacks
{
    public abstract class EnemyAttack : ScriptableObject
    {
        public abstract void Attack(int damage, PlayerHealthNew playerHealth);
    }
}