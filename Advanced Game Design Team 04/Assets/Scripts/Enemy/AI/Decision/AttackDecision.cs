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
                if(!controller.FieldOfView.IsTargetInView(controller.Target)) return false;
                var distanceToTarget = Vector3.Distance(controller.transform.position, controller.Target.position);
                return !(distanceToTarget > controller.Stats.AttackRange);
            }

    }
}