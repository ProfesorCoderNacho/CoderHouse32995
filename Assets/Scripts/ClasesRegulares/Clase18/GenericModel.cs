using UnityEngine;

namespace ClasesRegulares.Clase18
{
    public class GenericModel : MonoBehaviour
    {
        [SerializeField] private float m_speed;


        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private float m_jumpForce;

        public void GetControllerRef(IController p_controller)
        {
            p_controller.OnJump += OnJumpHandler;
            p_controller.OnRotate += OnRotateHandler;
            p_controller.OnMoveInput += OnMoveHandler;
            p_controller.OnAttack += OnAttackHandler;
        }

        private void OnAttackHandler()
        {
        }

        private void OnMoveHandler(float p_movementAmount)
        {
            var transform1 = transform;
            transform1.position += transform1.forward * (p_movementAmount * m_speed * Time.deltaTime);
        }

        private void OnJumpHandler()
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        private void OnRotateHandler(float p_rotationAmount)
        {
            transform.Rotate(Vector3.up * p_rotationAmount, Space.Self);
        }
    }
}