using System;
using ClasesRegulares.Clase13;
using UnityEngine;

public class HarryController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Collider myCollider;
    [SerializeField] private Transform m_eyeView;
    [SerializeField] private float m_raycastDistance = 10f;
    [SerializeField] private LayerMask m_layerToCollideWith;
    [SerializeField] private float m_explosionForce = 300f;
    [SerializeField] private float m_explosionRadius = 6f;
    private static float minimumHealth = 15f;

    private void Start()
    {
        currentHealth = maxHealth;
        myCollider = GetComponent<Collider>();
        GameManager.instance.SetHarryController(this);
    }

    public void ReceiveDamage(float p_damage)
    {
        currentHealth -= p_damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.Confined : CursorLockMode.None;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            CreateRaycast();
        }
    }

    private void CreateRaycast()
    {
        var l_hasCollided =
            Physics.Raycast(m_eyeView.position, m_eyeView.forward, out RaycastHit p_raycastHitInfo, m_raycastDistance,
                m_layerToCollideWith);

        if (l_hasCollided)
        {
            var l_exploder = p_raycastHitInfo.collider.GetComponent<IExploder>();
            if (l_exploder != null)
            {
                l_exploder.Explode(m_eyeView.forward, p_raycastHitInfo.point);
            }
        }
        else
        {
            Debug.Log("Hasn't collided with anything");
        }
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
        // Debug.Log("Entered collision");
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        // Debug.Log("Stay collision");
    }

    private void OnCollisionExit(Collision other)
    {
        // Debug.Log("Exit collision");
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(m_eyeView.position, m_eyeView.forward * m_raycastDistance);
    }
}