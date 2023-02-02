using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light m_myLight;

    private void Start()
    {
        m_myLight.color = Color.cyan;
    }

    private void Update()
    {
        m_myLight.intensity = 3 + Mathf.PingPong(Time.time, 2);
    }
}