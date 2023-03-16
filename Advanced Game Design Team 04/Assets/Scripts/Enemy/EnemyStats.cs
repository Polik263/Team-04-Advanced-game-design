using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/Enemy/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    [Header("Health")]
    public float MaxHealth;
    
    [Header("Movement")]
    public float MoveSpeed;
    public float Acceleration;
    public float TurnSpeed;
    
    [Header("Detection")]
    public float DetectionRadius;
    public float DetectionAngle;
    
    [Header("Attack")]
    public float AttackSpeed;
    public int AttackDamage;
    public float AttackRange;
}
