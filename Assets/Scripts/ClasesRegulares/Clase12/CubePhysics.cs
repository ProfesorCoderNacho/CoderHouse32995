using System;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody m_cubeRigidbody;
    [SerializeField] private float m_forceAmount;
    [SerializeField] private Transform m_forcePosition;
    [SerializeField] private float m_speedLimit;
    [SerializeField] private Vector3 m_torqueDirection;
    [SerializeField] private float m_torqueForce;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && IsWithinSpeedLimit())
        {
            m_cubeRigidbody.AddForce(transform.forward * m_forceAmount, ForceMode.Impulse);
            // m_cubeRigidbody.AddForceAtPosition(Vector3.up * m_forceAmount, m_forcePosition.position,
            //     ForceMode.Impulse);
            // m_cubeRigidbody.AddTorque(m_torqueForce * m_torqueDirection);
        }
    }

    private bool IsWithinSpeedLimit()
    {
        var l_currentYVelocity = Mathf.Abs(m_cubeRigidbody.velocity.y);
        return l_currentYVelocity < m_speedLimit;
    }
}