using UnityEngine;

namespace ClasesRegulares.Clase17
{
    public enum TrainerClass
    {
        KarateChamp,
        Lass,
        JuniorTrainer
    }
    public class RivalTrainer : Trainer
    {
        [SerializeField] private int m_locationID;
        [SerializeField] private TrainerClass m_trainerClass;
    }
}