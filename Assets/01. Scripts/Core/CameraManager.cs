using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private CinemachineVirtualCamera MainCam;
    [SerializeField] private CinemachineVirtualCamera MonitorCam;

    int frontPriority = 15;
    int backPriority = 10;

    void Start()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple instance is running");
        }
        instance = this;
    }

    public void MainCamActive()
    {
        MainCam.Priority = frontPriority;
        MonitorCam.Priority = backPriority;
    }

    public void MonitorCamActive()
    {
        MainCam.Priority = backPriority;
        MonitorCam.Priority = frontPriority;
    }
}
