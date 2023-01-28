using UnityEngine;

namespace Enemy.AI.Actions
{
    [CreateAssetMenu (fileName = "ChaseAction", menuName = "ScriptableObjects/Enemy/Actions/ChaseAction")]
    public class ChaseAction : EnemyAction
    {
        
        [SerializeField] private Transform target;
        
        public override void Act(EnemyStateController controller)
        {
            Chase(controller);
        }

        
        private void Chase(EnemyStateController controller)
        {
            if (controller.Target is not null)
            {
                var direction = controller.Target.position - controller.transform.position;
                controller.Movement.Move(direction, controller.Stats.MoveSpeed);
            }
            else
            {
                var direction = controller.targetPosition - controller.transform.position;
                controller.Movement.Move(direction, controller.Stats.MoveSpeed);
            }
            
            
        }
    }
}