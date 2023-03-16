using UnityEngine;
using UnityEngine.AI;

namespace Enemy.AI.Actions
{
    [CreateAssetMenu (fileName = "New Random Move Action", menuName = "ScriptableObjects/Enemy/Actions/Random Move Action")]
    public class GetRandomMoveLocationAction : EnemyAction
    {
        public override void Act(EnemyStateController controller)
        {
            SetRandomMoveLocation(controller);
        }
        
        private void SetRandomMoveLocation(EnemyStateController controller)
        {
            var point = Random.insideUnitSphere * controller.Stats.MoveSpeed + controller.transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(point, out hit, controller.Stats.MoveSpeed, 1);
            controller.Movement.SetDestination(hit.position);
        }

    }
}