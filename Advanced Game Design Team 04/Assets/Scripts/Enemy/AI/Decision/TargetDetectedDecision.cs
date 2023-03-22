using UnityEngine;

namespace Enemy.AI.Decision
{
    [CreateAssetMenu(fileName = "new InRangeDecision", menuName = "ScriptableObjects/Enemy/Decision/InRange")]
    public class TargetDetectedDecision : EnemyDecision
    {
        public override bool Decide(EnemyStateController controller)
        {
            return CanSeeTarget(controller);
        }

        private bool CanSeeTarget(EnemyStateController controller)
        {
            return controller.FieldOfView.IsTargetInView(controller.Target);
        }
    }
}