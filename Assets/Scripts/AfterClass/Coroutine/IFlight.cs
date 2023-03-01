using System;
using UnityEngine;

namespace AfterClass.Coroutine
{
    public interface IFlight
    {
        Transform transform { get; }
        void Move(float forwardsImpulse);
        void UpwardsMotion(float upwardsMotion);
        void Turn(float turnIntensity);
        void Init(Transform p_transform);
    }

    public class DroneFlight : IFlight
    {
        public Transform transform { get; private set; }

        public void Init(Transform p_transform)
        {
            transform = p_transform;
        }

        public void Move(float forwardsImpulse)
        {
        }

        public void UpwardsMotion(float upwardsMotion)
        {
        }

        public void Turn(float turnIntensity)
        {
        }
    }

    public class AirplaneFlight : IFlight
    {
        public Transform transform { get; private set; }

        public void Init(Transform p_transform)
        {
            transform = p_transform;
        }

        public void Move(float forwardsImpulse)
        {
        }

        public void UpwardsMotion(float upwardsMotion)
        {
        }

        public void Turn(float turnIntensity)
        {
        }
    }

    public class SpaceFlight : IFlight
    {
        public Transform transform { get; private set; }

        public void Init(Transform p_transform)
        {
            transform = p_transform;
        }

        public void Move(float forwardsImpulse)
        {
        }

        public void UpwardsMotion(float upwardsMotion)
        {
        }

        public void Turn(float turnIntensity)
        {
        }
    }

    public class Drone : MonoBehaviour
    {
        [SerializeField] private float m_velocityThresholdAirplane, m_velocityThresholdDrone;
        private IFlight m_droneFlight, m_combatAirplane, m_spaceFlight;

        private IFlight m_currentFlightPattern;

        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_droneFlight = new DroneFlight();
            m_droneFlight.Init(transform);
            m_combatAirplane = new AirplaneFlight();
            m_combatAirplane.Init(transform);
            m_spaceFlight = new SpaceFlight();
            m_spaceFlight.Init(transform);
        }

        private void Update()
        {
            var l_velocity = m_rigidbody.velocity;

            if (CheckFlightMode(l_velocity.magnitude, out var p_newMode))
            {
                m_currentFlightPattern = p_newMode;
            }

            //Inputs
        }

        private void SwitchFlightMode()
        {
        }

        private bool CheckFlightMode(float p_currentVelocity, out IFlight p_newMode)
        {
            p_newMode = default;
            if (p_currentVelocity >= m_velocityThresholdDrone)
            {
                if (p_currentVelocity >= m_velocityThresholdAirplane)
                {
                    //Pasemos a modo espacio
                    p_newMode = m_spaceFlight;
                    return m_currentFlightPattern != m_spaceFlight;
                }

                p_newMode = m_combatAirplane;
                return m_currentFlightPattern != m_combatAirplane;
            }

            p_newMode = m_droneFlight;
            return m_currentFlightPattern != m_droneFlight;
        }
    }
}