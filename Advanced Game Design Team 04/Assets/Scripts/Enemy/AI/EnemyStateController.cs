using Enemy.AI.States;
using Enemy.Attacks;
using UnityEngine;

namespace Enemy.AI
{
    public class EnemyStateController : MonoBehaviour
    {
        public EnemyState CurrentState;
        [SerializeField] private EnemyState remainInCurrentState;
        
        private Enemy _enemy;
        [HideInInspector] public EnemyStats Stats;
        [HideInInspector] public EnemyMovement Movement;
        [HideInInspector] public EnemyAttack attack;
        [HideInInspector] public Vector3 targetPosition;
        [HideInInspector] public bool StateBoolVariable;
        [HideInInspector] public float StateFloatVariable;

        public Transform Target;
        [SerializeField] private bool _isActive;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            Stats = _enemy.Stats;
            Movement = _enemy.Movement;
            attack = _enemy.Attack;
        }

        private void Update()
        {
            if(!_isActive) return;
            
            CurrentState.UpdateState(this);
        }
        
        public void Activate(bool active, Transform target)
        {
            _isActive = active;
            Target = target;
        }
        
        public void TransitionToState(EnemyState nextState)
        {
            if(nextState != remainInCurrentState)
            {
                CurrentState = nextState;
                //Debug.Log("Transitioning to " + nextState + "");
                OnExitState();
            }        
        }
        
        public bool HasTimeElapsed(float duration)
        {
            StateFloatVariable += Time.deltaTime;
            if(StateFloatVariable >= duration)
            {
                StateFloatVariable = 0;
                return true;
            }
            return false;
        }
        
        
        private void OnExitState()
        {
            StateBoolVariable = false;
            StateFloatVariable = 0;
        }
    }
}