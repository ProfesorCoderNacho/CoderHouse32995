using UnityEngine;

namespace ClasesRegulares.Clase17
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected EntityData entityData;

        public virtual string GetName()
        {
            return entityData.entityName;
        }
    }
}