using System;
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


        public override string GetName()
        {
            return "The pokemon " + entityData.entityName;
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
    }
}