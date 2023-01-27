using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyStats stats;
        [SerializeField] private float _gravity = -9.81f;
        private CharacterController _controller;
        private Vector3 _enemyVelocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }
        
        public void Move(Vector3 direction, float speed)
        {
            if(direction.magnitude < .1f || direction.magnitude > 1f)
                direction = direction.normalized;
            _enemyVelocity = direction * speed;
            _enemyVelocity.y += _gravity;
            _controller.Move(_enemyVelocity * Time.deltaTime);
        }
    }
