using Player;
using UnityEngine;

namespace Enemy.AI.Actions
{
    
    [CreateAssetMenu (fileName = "AttackAction", menuName = "ScriptableObjects/Enemy/Actions/AttackAction")]
    public class AttackAction : EnemyAction
    {
        public override void Act(EnemyStateController controller)
        {
            Attack(controller);
        }

        private void Attack(EnemyStateController controller)
        {

            if (!controller.StateBoolVariable)
            {
                controller.StateBoolVariable = true;
                controller.StateFloatVariable = controller.Stats.AttackSpeed;
            }
            
            var distance = Vector3.Distance(controller.transform.position, controller.Target.position);
            if (distance <= controller.Stats.AttackRange && controller.Target.TryGetComponent( out PlayerHealthNew playerHealth))
            {
                if (controller.HasTimeElapsed(controller.Stats.AttackSpeed))
                {
                    controller.attack.Attack(controller.Stats.AttackDamage, playerHealth);
                }
            }

        }
    }
}