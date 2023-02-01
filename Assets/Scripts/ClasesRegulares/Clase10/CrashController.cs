using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator crashAnimator;
    [SerializeField] private AudioSource crashAudio;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip jumpSound;

    private void Update()
    {
        Move(GetMoveVector());
        RotateCharacter(GetRotationAmount());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryAttack();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            crashAudio.PlayOneShot(deathSound);
        }
    }


    private void TryAttack()
    {
        crashAudio.PlayOneShot(jumpSound);
        crashAnimator.SetTrigger("Attacking");
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