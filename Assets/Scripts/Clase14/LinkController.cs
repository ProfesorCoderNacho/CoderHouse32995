using UnityEngine;

public class LinkController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator m_animator;
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.Confined : CursorLockMode.None;
    }

    private void Update()
    {
        Move(GetMoveVector());
        RotateCharacter(GetRotationAmount());
    }

    private void Move(Vector3 moveDir)
    {
        var transform1 = transform;
        transform1.position +=
            (moveDir.x * transform1.right + moveDir.z * transform1.forward) * (speed * Time.deltaTime);
        m_animator.SetFloat(MoveSpeed, moveDir.magnitude * speed);
    }

    private void RotateCharacter(float rotateAmount)
    {
        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime * rotationSpeed, Space.Self);
    }

    private float GetRotationAmount()
    {
        return Input.GetAxis("Mouse X");
    }

    private Vector3 GetMoveVector()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");

        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }
}