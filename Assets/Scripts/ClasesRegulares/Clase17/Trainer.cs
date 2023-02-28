using System.Collections.Generic;
using UnityEngine;

namespace ClasesRegulares.Clase17
{
    public class Trainer : Humanoid
    {
        [SerializeField] private List<Pokemon> m_myPokemons;
        [SerializeField] private int m_moneyToObtain;

        public override string GetName()
        {
            return $"Trainer {entityData.entityName}";
        }

        public void SetTrainerAsBattling(bool p_isBattling)
        {
            
        }
    }
}