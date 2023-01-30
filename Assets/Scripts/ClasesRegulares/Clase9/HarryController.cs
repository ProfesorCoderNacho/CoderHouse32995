using UnityEngine;

public class HarryController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Collider myCollider;

    private void Start()
    {
        currentHealth = maxHealth;
        myCollider = GetComponent<Collider>();
    }

    public void ReceiveDamage(float p_damage)
    {
        currentHealth -= p_damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveHealing(float p_healing)
    {
        currentHealth += p_healing;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
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
    }

    private void RotateCharacter(float rotateAmount)
    {
        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime * rotationSpeed, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision");
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log("Stay collision");
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("Exit collision");
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