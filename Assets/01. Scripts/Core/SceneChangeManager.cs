using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            print("�������� ����");
            Destroy(_currentStageObject.gameObject);
        }

        Stage stagePrefab = Resources.Load<Stage>($"{name} {index}");
        print("�������� �ε�");
        _currentStageObject = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);

        print("�������� ����");
    }
}
