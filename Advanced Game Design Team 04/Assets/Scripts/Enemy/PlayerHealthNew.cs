using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealthNew : MonoBehaviour
    {
        
        [SerializeField] private int maxHealth = 100;
        private int _currentHealth;
        public int CurrentHealth => _currentHealth;

        void Start()
        {
            _currentHealth = maxHealth;
        }
    
        private void Die()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
        
        public void Heal(int value)
        {
            _currentHealth = Mathf.Min(_currentHealth + value, maxHealth);
        }

    }
}
