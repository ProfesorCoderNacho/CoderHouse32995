using System;
using System.Collections;
using System.Collections.Generic;
using Clase8;
using UnityEngine;

public class LisaController : MonoBehaviour
{
    [SerializeField] private LisaStates currentState;
    [SerializeField] private Transform chris;
    [SerializeField] private float speed;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private Vector3 initialRotation;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
    }

    private void RotateCharacter()
    {
        
    }

    private void LookAtPlayerWithTransform()
    {
        //Manera 1
        // transform.LookAt(chris.position);

        //Manera 2
        var vectorToChris = chris.position - transform.position;
        var newRotation = Quaternion.LookRotation(vectorToChris);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    public void SetCurrentState()
    {
        // if (currentState == idle)
        // {
        //     ExecuteIdle();
        // }
        // else if (currentState == pursuit)
        // {
        //     ExecutePursuit();
        // }
        //
        // else if (currentState == runAway)
        // {
        //     ExecuteRunAway();
        // }
        // else
        // {
        //     Debug.LogError("current state is invalid");
        // }


        switch (currentState)
        {
            case LisaStates.Idle:
                ExecuteIdle();
                break;
            case LisaStates.Pursuit:
                ExecutePursuit();
                break;
            case LisaStates.RunAway:
                ExecuteRunAway();
                break;
            default:
                Debug.LogError("current state is invalid");
                break;
        }
    }

    private void Update()
    {
        SetCurrentState();
    }

    private void ExecuteIdle()
    {
        Debug.Log("Idlee state");
        var vectorToChris = chris.position - transform.position;
        var distance = vectorToChris.magnitude;

        if (distance < pursuitDistance)
        {
            currentState = LisaStates.Pursuit;
        }
    }

    private void ExecutePursuit()
    {
        Debug.Log("Pursuit state");
        var vectorToChris = chris.position - transform.position;
        var distance = vectorToChris.magnitude;
        LookAtPlayerWithTransform();
        if (distance > pursuitDistance)
        {
            transform.position += Vector3.MoveTowards(transform.position,
                chris.position, Time.deltaTime * speed);
        }
    }

    private void ExecuteRunAway()
    {
        Debug.Log("RUn away state");
    }
}