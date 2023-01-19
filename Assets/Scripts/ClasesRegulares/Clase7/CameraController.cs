using System;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera1;
    [SerializeField] private CinemachineVirtualCamera camera2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TurnOnCamera(camera1, camera2);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TurnOnCamera(camera2, camera1);
        }
    }

    private void TurnOnCamera(CinemachineVirtualCamera camToTurnOn, CinemachineVirtualCamera otherCamera)
    {
        Debug.Log("Turn on");
        //Opcion 1: Apagar y prender el GameObject
        camToTurnOn.gameObject.SetActive(true);
        otherCamera.gameObject.SetActive(false);
        //Opción 2: Apagar y prender el componente
    }
}