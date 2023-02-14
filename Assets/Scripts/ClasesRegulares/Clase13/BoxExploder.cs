using System.Collections;
using System.Collections.Generic;
using ClasesRegulares.Clase13;
using UnityEngine;

public class BoxExploder : MonoBehaviour,IExploder
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_explosionForce;

    public void Explode(Vector3 p_direction, Vector3 p_position)
    {
        m_rigidbody.AddExplosionForce(m_explosionForce, p_position, 10);
    }
}