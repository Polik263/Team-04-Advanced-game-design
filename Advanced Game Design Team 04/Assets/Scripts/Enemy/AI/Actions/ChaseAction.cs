using UnityEngine;

namespace Enemy.AI.Actions
{
    [CreateAssetMenu (fileName = "ChaseAction", menuName = "ScriptableObjects/Enemy/Actions/ChaseAction")]
    public class ChaseAction : EnemyAction
    {
        
        
        public override void Act(EnemyStateController controller)
        {
            Chase(controller);
        }

        
        private void Chase(EnemyStateController controller)
        {
            controller.StateVectorVariable = controller.Target.position;
            controller.ResetOnTransition = false;
            if (controller.Movement.HasPath()) return;
            
            controller.Movement.SetDestination(controller.Target.position);
        }
    }
}