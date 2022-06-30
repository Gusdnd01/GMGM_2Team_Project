using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] CinemachineVirtualCamera MainCam;
    [SerializeField] CinemachineVirtualCamera MonitorCam;
    [SerializeField] CinemachineVirtualCamera PuzzleCam;

    int frontPriority = 15;
    int backPriority = 10;
    int previousStagePriority = 5;

    float zoomValue = 4;

    public bool isPuzzle = true;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Multiple instance is running{this}");
        }
        instance = this;
    }

    public void MainCamActive()
    {
        MainCam.Priority = frontPriority;
        MonitorCam.Priority = backPriority;
        PuzzleCam.Priority = previousStagePriority;

        isPuzzle = false;
    }

    public void MonitorCamActive()
    {
        MainCam.Priority = backPriority;
        MonitorCam.Priority = frontPriority;
        PuzzleCam.Priority = previousStagePriority;
        
        isPuzzle = false;
    }

    public void PuzzleCamActive()
    {
        PuzzleCam.Priority = frontPriority;
        MainCam.Priority = previousStagePriority;
        MonitorCam.Priority = previousStagePriority;

        PuzzleCam.m_Lens.OrthographicSize = 9;
    }
    private void Update()
    {
        CamMove();
    }

    private void CamMove()
    {
        if (!isPuzzle) return;
        float c = Input.GetAxis("Mouse ScrollWheel");
        zoomValue += c * 2.5f;

        PuzzleCam.m_Lens.OrthographicSize = Mathf.Lerp(PuzzleCam.m_Lens.OrthographicSize, zoomValue, Time.deltaTime * 5);
    }

    private void LateUpdate()
    {
        zoomValue = Mathf.Clamp(zoomValue, 4f, 9f);
    }
}
