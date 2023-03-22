using UnityEngine;

namespace Enemy.AI.Decision
{
    [CreateAssetMenu(fileName = "new InRangeDecision", menuName = "ScriptableObjects/Enemy/Decision/InRange")]
    public class TargetInRangeDecision : EnemyDecision
    {
        public override bool Decide(EnemyStateController controller)
        {
            return IsTargetInRange(controller);
        }

        private bool IsTargetInRange(EnemyStateController controller)
        {
            if(controller.Target is null)
                return false;
            
            var distanceToTarget = Vector3.Distance(controller.transform.position, controller.Target.position);
            if (distanceToTarget <= controller.Stats.DetectionRadius)
            {
                    controller.targetPosition = controller.Target.position;
                    return true;
            }
            return false;
        }
    }
}