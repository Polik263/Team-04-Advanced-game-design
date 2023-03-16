using Enemy.AI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyStats stats;
        [SerializeField] private float _gravity = -9.81f;
        private NavMeshAgent _agent;
        private Vector3 _enemyVelocity;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            Init();
        }

        private void Init()
        {
            _agent.speed = stats.MoveSpeed;
            _agent.acceleration = stats.Acceleration;
            _agent.angularSpeed = stats.TurnSpeed;
        }
        
        public void SetDestination(Vector3 destination)
        {
            _agent.SetDestination(destination);
        }
        
        public void SetSpeed(float speed)
        {
            _agent.speed = speed;
        }
        
        public bool HasPath()
        {
            return _agent.hasPath;
        }
        
        public void CalculateNewPath(EnemyStateController controller, Vector3 targetPosition)
        {
            bool onNavMesh;
            var maxDistance = 0.1f;
            NavMeshHit hit;
            do            
            {
                onNavMesh = NavMesh.SamplePosition(targetPosition, out hit, maxDistance, NavMesh.AllAreas);
                maxDistance += 0.1f;
                Vector3.MoveTowards(targetPosition, controller.transform.position, 0.1f);
            } while (!onNavMesh);

            var path = new NavMeshPath();
            _agent.CalculatePath(hit.position, path);
            _agent.SetPath(path);
        }
        
        public bool HasLineOfSight(EnemyStateController controller)
        {
            var targetPos = controller.Target.position;
            if (!_agent.Raycast(targetPos, out var hit))
                return true;
            return hit.position == targetPos;
        }
        
        public void Move()
        {
            _agent.Move(_enemyVelocity * Time.deltaTime);
        }
        
        public void ToggleMoving(bool canMove)
        {
            if (canMove)
            {
                _agent.speed = stats.MoveSpeed;
            }        
            else
            {
                _agent.speed = 0;
                _agent.velocity = Vector3.zero;
            }        
        }
        
        public float GetDistanceToPathTarget(EnemyStateController controller)
        {
            return Vector3.Distance(controller.transform.position, _agent.pathEndPosition);
        }

    }
