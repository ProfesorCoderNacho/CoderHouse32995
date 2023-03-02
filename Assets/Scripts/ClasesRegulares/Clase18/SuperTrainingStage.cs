using UnityEngine;

namespace ClasesRegulares.Clase18
{
    public class SuperTrainingStage : MonoBehaviour
    {
        
        public void OnCharacterMovedHandler(bool p_characterMoved)
        {
            Debug.Log($"Character is moving? {p_characterMoved}");    
        }
    }
}