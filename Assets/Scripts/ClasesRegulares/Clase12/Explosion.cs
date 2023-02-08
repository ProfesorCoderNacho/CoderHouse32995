using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private Transform m_explosionPosition;
    [SerializeField] private float m_explosionForce, m_explosionRadius;
    [SerializeField] private LayerMask m_explosionMask;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var l_objects = Physics.OverlapSphere(transform.position, m_explosionRadius);

            foreach (var l_collider in l_objects)
            {
                var l_rigidbody = l_collider.GetComponent<Rigidbody>();
                if (l_rigidbody != null)
                {
                    l_rigidbody.AddExplosionForce(m_explosionForce, transform.position, m_explosionRadius);
                }
            }

            
        }
    }
}
