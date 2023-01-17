using System;
using UnityEngine;

namespace ClasesRegulares
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifetime = 5;

        private void Start()
        {
            lifetime += Time.time;
        }

        private void Update()
        {
            MoveForwards();
            Countdown();
        }

        private void Countdown()
        {
            Debug.Log(Time.time + " is current time");
            if (lifetime <= Time.time)
            {
                KillBullet();
            }
        }

        private void KillBullet()
        {
            Debug.Log("Bullet killed");
            Destroy(gameObject);
        }

        private void MoveForwards()
        {
            transform.position += transform.forward * speed;
        }
    }
}