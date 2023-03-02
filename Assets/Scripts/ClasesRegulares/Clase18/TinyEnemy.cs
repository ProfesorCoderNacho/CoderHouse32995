using System;
using UnityEngine;

namespace ClasesRegulares.Clase18
{
    public class TinyEnemy : MonoBehaviour
    {
        [SerializeField] private float m_maxHealth;
        [SerializeField] private float m_totalAddingPoints;
        private HealthController m_healthController;

        public static event Action<float> OnEnemyDied;


        private void Awake()
        {
            m_healthController = new HealthController(m_maxHealth);
            m_healthController.OnDie += EnemyDied;
        }

        [ContextMenu("Test damage")]
        private void TestReceiveDamage()
        {
            m_healthController.ReceiveDamage(1);
        }

        private void EnemyDied()
        {
            OnEnemyDied?.Invoke(m_totalAddingPoints);
            Destroy(gameObject);
        }
    }
}