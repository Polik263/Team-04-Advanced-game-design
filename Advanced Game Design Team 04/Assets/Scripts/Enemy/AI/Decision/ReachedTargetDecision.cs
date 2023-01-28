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
            return Vector3.Distance(controller.targetPosition, controller.transform.position) < reachedTargetDistance;
        }
    }
}