using UnityEngine;

namespace ClasesRegulares.Clase13
{
    public class DoorExploder : MonoBehaviour, IExploder
    {
        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private float m_explosionForce;
        
        public void Explode(Vector3 p_direction, Vector3 p_position)
        {
            m_rigidbody.AddForce(p_direction * m_explosionForce, ForceMode.Impulse);
        }
    }
}