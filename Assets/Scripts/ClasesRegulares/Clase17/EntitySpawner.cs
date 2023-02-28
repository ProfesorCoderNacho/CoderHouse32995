using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClasesRegulares.Clase17
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private List<Entity> m_spawnables;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InstantiateEntity();
            }
        }

        private void InstantiateEntity()
        {
            Entity l_entityToInstantiate = m_spawnables[Random.Range(0, m_spawnables.Count)];
            Entity l_spawnedEntity = Instantiate(l_entityToInstantiate);
            
            if (l_spawnedEntity is Trainer l_trainer)
            {
                l_trainer.SetTrainerAsBattling(true);
            }


            Debug.Log(l_spawnedEntity.GetName());
        }
    }
}