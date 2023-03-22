using UnityEngine;

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
            RaycastHit hit;
            Vector3 direction;
            float distance;
            direction = Random.insideUnitSphere;
            direction.y = 0;
            distance = Random.Range(0, controller.Stats.MoveSpeed * 100);
            Physics.Raycast(controller.transform.position, direction, out hit, distance);

            Debug.DrawRay(controller.transform.position, direction * distance, Color.red, 1f);
            
            if (hit.collider is null)
            {
                controller.targetPosition = controller.transform.position + direction * distance;
            }
            else
            {
                controller.targetPosition = hit.point - direction.normalized * 2;
            }
            
        }

    }
}