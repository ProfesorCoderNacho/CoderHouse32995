using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingArea : MonoBehaviour
{
    [SerializeField] private float damageToApply;
    [SerializeField] private float damageTime;
    private float m_currentTime;

    private void OnTriggerStay(Collider other)
    {
        var l_harryController = other.GetComponent<HarryController>();
        if (m_currentTime <= Time.time && l_harryController != null)
        {
            m_currentTime = Time.time + damageTime;
            l_harryController.ReceiveDamage(damageToApply);
        }
    }
}