using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

namespace ClasesRegulares.Clase2
{
    public class Character : MonoBehaviour
    {
        public int age;
        public float health;
        public float damage;
        public float defense;
        public double physicsFall;
        public bool useRaytracing;
        public Vector2 xz;
        public Vector3 myPosition;
        [SerializeField] private string characterName;
        private string m_myName;

        private void Awake()
        {
            SetName("UnNombre");
            SetName("UnNombre", 123);
        }
        void Start()
        {
            var sum = SumFloats(1, 2, 3, 4);
            Debug.Log(sum);
        }

        void Update()
        {
        }

        private Vector3 GetPosition()
        {
            return transform.position;
        }
        
        public string GetName()
        {
            return m_myName;
        }

        public float SumFloats(float num1, float num2, float num3, float num4)
        {
            var sum = num1 + num2 + num3 + num4;
            return sum;
        }

        public void ReceiveHeal()
        {
            
        }

        private void SetName(string newName)
        {
            m_myName = newName;
        }

        private void SetName(string newName, int userNumber)
        {
            m_myName = newName + userNumber;
        }
    }
}