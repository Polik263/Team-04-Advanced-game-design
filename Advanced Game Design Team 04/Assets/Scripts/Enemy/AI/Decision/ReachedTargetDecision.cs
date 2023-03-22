using UnityEngine;

namespace Enemy.AI.Decision
{
    [CreateAssetMenu(fileName = "new ReachedTargetDecision", menuName = "ScriptableObjects/Enemy/Decision/ReachedTargetDecision")]
    public class ReachedTargetDecision : EnemyDecision
    {
        [SerializeField] private float reachedTargetDistance = .2f;
        public override bool Decide(EnemyStateController controller)
        {
            return HasReachedTarget(controller);
        }

        private bool HasReachedTarget(EnemyStateController controller)
        {
            if(!controller.Movement.HasPath())
                return false;
            return controller.Movement.GetDistanceToPathTarget(controller) <= reachedTargetDistance;
        }
    }
}