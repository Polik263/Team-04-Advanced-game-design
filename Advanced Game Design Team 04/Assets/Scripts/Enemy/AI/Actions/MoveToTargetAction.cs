using UnityEngine;

namespace Enemy.AI.Actions
{
    [CreateAssetMenu (fileName = "New Move Action", menuName = "ScriptableObjects/Enemy/Actions/MoveTowardsTargetAction")]
    public class MoveToTargetAction : EnemyAction
    {
        public override void Act(EnemyStateController controller)
        {
            MoveToTarget(controller);
        }

        private void MoveToTarget(EnemyStateController controller)
        {
            if(controller.StateVectorVariable is null)
                return;
            if(controller.Movement.HasPath())
                return;
            controller.Movement.SetDestination((Vector3) controller.StateVectorVariable);
        }
    }
}