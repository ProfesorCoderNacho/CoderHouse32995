using ClasesRegulares.Clase17.ScriptableObjects;
using UnityEngine;

namespace ClasesRegulares.Clase17
{
    [CreateAssetMenu(menuName = "Data/Pokemon/PokemonData")]
    public class PokemonData : ScriptableObject
    {
        public LevelupCurves levelupCurve;
        public float weight;
        public float height;
        public EggGroup[] eggGroups;
        public PokemonType type1;
        public PokemonType type2;
        public BaseStats baseStats;
    }
}