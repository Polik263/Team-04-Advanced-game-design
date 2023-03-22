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
            var moveDirection = controller.targetPosition - controller.transform.position;
            controller.Movement.Move(moveDirection, controller.Stats.MoveSpeed);
        }
    }
}