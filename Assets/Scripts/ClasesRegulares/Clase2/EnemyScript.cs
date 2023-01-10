using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace ClasesRegulares.Clase2
{
    public class EnemyScript : MonoBehaviour
    {
        [SerializeField] private string enemyName;
        [SerializeField] private Vector3 movement;
        [SerializeField] private Quaternion _quaternion;
        public float damage;
        public float heal;
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;
        public string m_myName;
        [SerializeField] private Character character;
        [SerializeField] private bool shouldntBreak;
        [SerializeField] private float health;
        [SerializeField] private float fallingSpeed;

        // Start is called before the first frame update
        void Start()
        {
            var l_characterName = character.GetName();
            Debug.Log(l_characterName);
            Debug.Log(l_characterName + "s");
            var totalDamage = damage - heal;
            health -= totalDamage;
        }


        // Update is called once per frame
        void Update()
        {
        }
    }
}
