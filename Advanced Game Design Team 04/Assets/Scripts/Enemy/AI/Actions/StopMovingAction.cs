using UnityEngine;

namespace Enemy.AI.Actions
{
    [CreateAssetMenu (fileName = "StopMovingAction", menuName = "ScriptableObjects/Enemy/Actions/StopMovingAction")]
    public class StopMovingAction : EnemyAction
    {
        public override void Act(EnemyStateController controller)
        {
            StopMoving(controller);
        }

        private void StopMoving(EnemyStateController controller)
        {
            controller.Movement.ToggleMoving(false);
        }
    }
}