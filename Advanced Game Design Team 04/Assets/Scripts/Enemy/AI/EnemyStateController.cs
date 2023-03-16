using Enemy.AI.States;
using Enemy.Attacks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.AI
{
    [RequireComponent(typeof(Enemy), typeof(FieldOfView))]
    public class EnemyStateController : MonoBehaviour
    {
        [SerializeField] private bool _isActive;
        [SerializeField] private Transform _target;
        public  Transform Target => _target;
        
        public EnemyState CurrentState;
        [SerializeField] private EnemyState remainInCurrentState;
        
        private Enemy _enemy;
        [HideInInspector] public FieldOfView FieldOfView {get; private set;}
        [HideInInspector] public EnemyStats Stats;
        [HideInInspector] public EnemyMovement Movement;
        [HideInInspector] public EnemyAttack attack;
        [HideInInspector] public bool StateBoolVariable;
        [HideInInspector] public float StateFloatVariable;
        [HideInInspector] public Vector3? StateVectorVariable;
        [HideInInspector] public bool ResetOnTransition = true;
        
        [Header("Update Frequency")]
        private float _updateTimer;
        [SerializeField, Tooltip("Times in seconds between AI Update")] private float _updateFrequency = 0.1f;

        [Header("Debug")]
        public bool DebugModeOn;
        [SerializeField] private bool _displayPath;
        [SerializeField] private bool _displayPathDestination;


        private void Awake()
        {
            #region nullChecks
            if (CurrentState == null ||
                CurrentState == remainInCurrentState)
            {
                Debug.LogError($"Starting state is not set for {gameObject.name}");
                _isActive = false;
            }
            if(remainInCurrentState == null)
            {
                Debug.LogError($"Remain in current state is not set for {gameObject.name}");
                _isActive = false;
            }            
            if(Target == null)
            {
                Debug.LogError($"Target is not set for {gameObject.name} in StateController");
                _isActive = false;
            }
            #endregion
            FieldOfView = GetComponent<FieldOfView>();
            FieldOfView.Init(Stats.DetectionRadius, Stats.DetectionAngle);
        }

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
            
            _updateTimer += Time.deltaTime;
            if (!(_updateTimer >= _updateFrequency)) return;

            CurrentState.UpdateState(this);
        }
        
        public void Activate(bool active)
        {
            _isActive = active;
        }
        
        public void TransitionToState(EnemyState nextState)
        {
            if (nextState == remainInCurrentState) return;
            if(DebugModeOn)
                Debug.Log($"{gameObject.name} transitioned from {CurrentState.name} to {nextState.name}" );
                
            CurrentState = nextState;
            OnExitState();
        }
        
        public bool HasTimeElapsed(float duration)
        {
            StateFloatVariable += Time.deltaTime;
            if (StateFloatVariable <= duration) return false;
            StateFloatVariable = 0;
            return true;
        }
        
        
        private void OnExitState()
        {
            if(ResetOnTransition)
            {
                StateBoolVariable = false;
                StateFloatVariable = 0;
                StateVectorVariable = null;
                Movement.ToggleMoving(true);
            }        
            ResetOnTransition = true;
        }


        private void OnDrawGizmosSelected()
        {
            if (!DebugModeOn) return;
            if(_displayPathDestination)
                DisplayPathDestination();
            if(_displayPath)
                DisplayPath();
        }

        private void DisplayPath()
        {
            Gizmos.color = Color.green;
            var path = Movement.GetPath();
            for (var i = 0; i < path.corners.Length - 1; i++)
            {
                Gizmos.DrawLine(path.corners[i], path.corners[i + 1]);
            }
        }

        private void DisplayPathDestination()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Movement.GetPathDestination(), 0.5f);
        }    }
}