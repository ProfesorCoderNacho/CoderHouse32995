using UnityEngine;

namespace ClasesRegulares.Clase17
{
    public class Creature : Entity
    {
        public void SendIntoBattle()
        {
            Debug.Log($" {entityData.entityName} was sent to battle");
        }

        public override string GetName()
        {
            return "The creature " + entityData.entityName;
        }
    }
}