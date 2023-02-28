using System.Collections.Generic;
using UnityEngine;

namespace ClasesRegulares.Clase17.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/PokemonData/Type")]
    public class PokemonType : ScriptableObject
    {
    }

    public class DamageTypeTable : ScriptableObject
    {
        public float GetDamageMultiplier(PokemonType damageType, PokemonType defenseType1, PokemonType defenseType2)
        {
            return 0.25f;
        }
    }
}