using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/Enemy/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    public float MaxHealth;
    
    public float MoveSpeed;
    
    public float DetectionRadius;
    
    public float AttackSpeed;
    public int AttackDamage;
    public float AttackRange;
}
