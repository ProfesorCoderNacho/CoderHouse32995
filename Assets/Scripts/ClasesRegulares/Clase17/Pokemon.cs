using System;
using System.Collections;
using System.Data.Common;
using ClasesRegulares.Clase17.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace ClasesRegulares.Clase17
{
    public class Pokemon : Creature
    {
        [SerializeField] private PokemonData _pokemonData;
        private string nickname;
        private float _currentHP;
        private float _currentAttack;
        private float _currentDefense;
        private int _currentLevel;
        private DamageTypeTable m_table;

        [SerializeField] private float m_attackDelay;

        private float m_currentAttackTime;
        private Coroutine m_attackCoroutine;
        private WaitForSeconds m_waitTime;


        public override string GetName()
        {
            return "The pokemon " + entityData.entityName;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P) && m_currentAttackTime < Time.time /*&& !m_isAttacking*/)
            {
                m_attackCoroutine = StartCoroutine(DoAttack());
            }

            if (Input.GetKeyDown(KeyCode.H) && m_currentAttackTime >= Time.time)
            {
                //Simulate getting hit
                StopCoroutine(m_attackCoroutine);
            }
        }

        private bool GetIsAttacking()
        {
            return m_attackCoroutine != default;
        }

        public void CalculateStats()
        {
            var l_baseStats = _pokemonData.baseStats;
        }

        public string GetWeakness()
        {
            return default;
        }

        public void GetAttack(PokemonType damageType, float damageAmount)
        {
            damageAmount *= m_table.GetDamageMultiplier(damageType, _pokemonData.type1, _pokemonData.type2);
        }

        private IEnumerator DoAttack()
        {
            m_currentAttackTime = Time.time + m_attackDelay;
            var position = transform.position;
            AudioSource.PlayClipAtPoint(_pokemonData.pokemonCry, position);
            m_waitTime ??= new WaitForSeconds(m_attackDelay);
            yield return m_waitTime;
            Instantiate(_pokemonData.pokemonAttack, position, Quaternion.identity);
        }
    }
}