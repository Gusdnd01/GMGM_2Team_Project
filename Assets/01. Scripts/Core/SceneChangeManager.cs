using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager instance;
    private Stage _currentStageObject = null;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError($"Multiple instance is running ({this})");
        }

        instance = this;
    }

    public void LoadPrefab(string name, int index)
    {
        if (_currentStageObject != null)
        {
            print("스테이지 삭제");
            CameraManager.instance.isPuzzle = true;
            Destroy(_currentStageObject.gameObject);
        }
        if(CameraManager.instance.isPuzzle == true)
        {
            CameraManager.instance.PuzzleCamActive();
        }
        Stage stagePrefab = Resources.Load<Stage>($"{name} {index}");
        print("스테이지 로드");
        _currentStageObject = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);

        print("스테이지 생성");
    }
}
