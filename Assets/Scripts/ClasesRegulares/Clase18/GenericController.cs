using System;
using UnityEngine;

namespace ClasesRegulares.Clase18
{
    public interface IController
    {
        public event Action<float> OnMoveInput;
        public event Action OnJump;
        public event Action<float> OnRotate;
        public event Action OnAttack;
    }

    public class IAController : MonoBehaviour, IController
    {
        public event Action<float> OnMoveInput;
        public event Action OnJump;
        public event Action<float> OnRotate;
        public event Action OnAttack;

        private void Awake()
        {
            var l_genericModel = GetComponent<GenericModel>();
            if (l_genericModel != default)
            {
                l_genericModel.GetControllerRef(this);
            }
        }
    }

    public class GenericController : MonoBehaviour, IController
    {
        public event Action<float> OnMoveInput;
        public event Action OnJump;
        public event Action<float> OnRotate;
        public event Action OnAttack;


        [SerializeField] private GenericModel m_model;

        private void Awake()
        {
            m_model.GetControllerRef(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }

            var l_horizontal = Input.GetAxis("Horizontal");
            var l_vertical = Input.GetAxis("Vertical");

            OnMoveInput?.Invoke(l_vertical);
            OnRotate?.Invoke(l_horizontal);

            if (Input.GetKeyDown(KeyCode.I))
            {
                OnAttack?.Invoke();
            }
        }
    }
}