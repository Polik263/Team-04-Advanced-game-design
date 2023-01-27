using UnityEngine;

namespace Enemy.AI.Decision
{
    [CreateAssetMenu(fileName = "new InAttackRangeDecision", menuName = "ScriptableObjects/Enemy/Decision/InAttackRange")]
    public class AttackDecision : EnemyDecision
    {
            public override bool Decide(EnemyStateController controller)
            {
                return CanAttack(controller);
            }

            private bool CanAttack(EnemyStateController controller)
            {
                if(controller.Target is null)
                    return false;
            
                var distanceToTarget = Vector3.Distance(controller.transform.position, controller.Target.position);
                if (distanceToTarget > controller.Stats.AttackRange) return false;

                return true;
            }

    }
}