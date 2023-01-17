using System;
using System.Security.Authentication.ExtendedProtection;
using UnityEditor.UIElements;
using UnityEngine;

namespace ClasesRegulares.Clase2
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float damageToTake;
        [SerializeField] private float speed;
        [SerializeField] private bool isParalyzed;
        [SerializeField] private bool isInGodMode;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private float shootingTimer;
        private float _shootingTimerInner;
        private void Start()
        {
            // ReceiveDamage(damageToTake);
            _shootingTimerInner = shootingTimer;
        }

        private void Move(Vector3 moveDirection)
        {
            transform.position += moveDirection * (speed * Time.deltaTime);
        }

        private void SuperGrow()
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        private void Update()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            Debug.Log("Horizontal: " + horizontal + "Vertical: " + vertical);
            var direction = new Vector3(horizontal, 0, vertical);
            Move(direction);

            var shouldShoot = Input.GetKeyDown(KeyCode.Space);
            if (shouldShoot && _shootingTimerInner <= Time.time)
            {
                Shoot();
            }

            //SuperGrow();
        }

        private void Shoot()
        {
            _shootingTimerInner = shootingTimer + Time.time;
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        }

        private void ReceiveDamage(float damage)
        {
            health -= damage;
            var amIDead = health <= 0;

            if (amIDead)
            {
                health = 0;
                Debug.Log("Die");
            }
        }
    }
}