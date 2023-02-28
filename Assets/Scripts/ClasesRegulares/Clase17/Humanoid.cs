using UnityEngine;

namespace ClasesRegulares.Clase17
{
    public interface INPC
    {
        void InteractWithNPC();
    }
    public class Humanoid : Entity
    {
        [SerializeField] private Animator m_humanoidAnimator;
    }
}