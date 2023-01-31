using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCube : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ActivateCubeTransition(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ActivateCubeTransition(true);
        }
    }

    private void ActivateCubeTransition(bool p_isActivated)
    {
        // animator.SetBool("TrapActivated", p_isActivated);
        animator.SetTrigger("TrapTrigger");
    }
}