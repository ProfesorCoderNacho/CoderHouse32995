using System;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    [SerializeField] private float healingAmount;
    [SerializeField] private float timeToHeal = 1f;
    private float _currentTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            if (_currentTime <= Time.time && other.TryGetComponent<HarryController>(out var l_harryController))
            {
                _currentTime = Time.time + timeToHeal;
                l_harryController.ReceiveHealing(healingAmount);
            }
        }
    }
}