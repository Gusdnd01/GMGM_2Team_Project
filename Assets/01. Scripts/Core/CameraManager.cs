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
    [SerializeField] CinemachineVirtualCamera StageSelectCam;

    [SerializeField] private Transform camRig;

    int frontPriority = 15;
    int backPriority = 10;
    int previousStagePriority = 5;

    float zoomValue = 4;

    #region Shake
    CinemachineBasicMultiChannelPerlin shakeCam = null;
    float shakeTime = 0;
    #endregion

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
        StageSelectCam.Priority = previousStagePriority;

        isPuzzle = false;
    }

    public void MonitorCamActive()
    {
        MainCam.Priority = backPriority;
        MonitorCam.Priority = frontPriority;
        PuzzleCam.Priority = previousStagePriority;
        StageSelectCam.Priority = previousStagePriority;

        isPuzzle = false;
    }

    public void PuzzleCamActive()
    {
        PuzzleCam.Priority = frontPriority;
        MainCam.Priority = previousStagePriority;
        MonitorCam.Priority = previousStagePriority;
        StageSelectCam.Priority = previousStagePriority;

        PuzzleCam.m_Lens.OrthographicSize = 9;
    }
    public void StageSelectCamActive()
    {
        PuzzleCam.Priority = previousStagePriority;
        MainCam.Priority = previousStagePriority;
        MonitorCam.Priority = previousStagePriority;
        StageSelectCam.Priority = frontPriority;
    }
    private void Update()
    {
        CamMove();
        //Shake();
    }

    private void CamMove()
    {
        if (!isPuzzle) return;
        float c = Input.GetAxis("Mouse ScrollWheel");
        zoomValue += c * 2.5f;

        PuzzleCam.m_Lens.OrthographicSize = Mathf.Lerp(PuzzleCam.m_Lens.OrthographicSize, zoomValue, Time.deltaTime * 5);

        if (Input.GetMouseButton(3))
        {
            float x = Input.GetAxisRaw("Mouse X");
            float y = Input.GetAxisRaw("Mouse Y");

            camRig.position += new Vector3(-x, -y, 0) * 100 * Time.deltaTime;
        }

        if(PuzzleCam.m_Lens.OrthographicSize > 6)
        {
            camRig.position = new Vector3(0, 0, 0);
        }
    }

    private void LateUpdate()
    {
        zoomValue = Mathf.Clamp(zoomValue, 4f, 9f);

        float x = Mathf.Clamp(camRig.position.x, -16, 16);
        float y = Mathf.Clamp(camRig.position.y, -9, 9);

        camRig.position = new Vector3(x,y,0);
    }

    private void Shake()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeCam.m_AmplitudeGain = 0;
        }
    }

    public void ShakeCam(float intensity, float time)
    {
        int maxPriority = 0;
        if(MainCam.Priority > maxPriority) { maxPriority = MainCam.Priority; shakeCam = MainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); }
        if(MonitorCam.Priority > maxPriority) { maxPriority = MonitorCam.Priority; shakeCam = MonitorCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); }
        if(PuzzleCam.Priority > maxPriority) { maxPriority = PuzzleCam.Priority; shakeCam = PuzzleCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); }

        if (shakeCam == null) return;
        shakeCam.m_AmplitudeGain = intensity;
        shakeTime += time;
    }
}
