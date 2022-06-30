using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager instance;
    private GameObject stage;//_currentStageObject = null;
    private GameObject puzzle;
    private bool isStage;
    Image fade;
    //List<Stage> stages = new List<Stage>();

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError($"Multiple instance is running ({this})");
        }

        instance = this;

        //Stage stagePrefab = Resources.Load<Stage>("Platform 1");
        //Stage stage = Resources.Load<Stage>("Puzzle 1");
        //stages.Add(stagePrefab);
        //stages.Add(stage);

        Set(1);

        
    }

    private void Start()
    {
        fade = UIManager.Instance.FadePanel;
    }

    public void Set(int idx)
    {

        puzzle = Instantiate(Resources.Load<GameObject>($"Puzzle {idx}"), Vector3.zero, Quaternion.identity);
        stage = Instantiate(Resources.Load<GameObject>($"Platform {idx}"), Vector3.zero, Quaternion.identity);
        puzzle.SetActive(false);
        stage.SetActive(false);
        /*for(int i = 0; i < stages.Count; i++)
        {
            Stage stage = stages[i];

            Instantiate(stage, transform.position, Quaternion.identity);

            stage.gameObject.SetActive(false);
        }*/
    }

    public void Update()
    {
        Test();
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Sequence seq = DOTween.Sequence();

            seq.AppendInterval(1.5f);
            fade.DOFade(1, 1);

            seq.AppendCallback(() =>
            {
                LoadPrefab("Platform", 1);
                CameraManager.instance.isPuzzle = false;
            });
        }
    }

    public void LoadPrefab(string name, int index)
    {
        Sequence seq = DOTween.Sequence();

        if (name == "Platform")
        {
            seq.AppendInterval(1.5f);

            print("Platform Scene");
            stage.SetActive(true);
            puzzle.SetActive(false);
            fade.DOFade(0, 1);
            CameraManager.instance.MainCamActive();
        }
        if(name == "Puzzle")
        {
            seq.AppendInterval(1.5f);

            print("Puzzle Scene");
            stage.SetActive(false);
            puzzle.SetActive(true);
            fade.DOFade(0, 1);
            CameraManager.instance.PuzzleCamActive();
        }
        /*if (_currentStageObject != null)
        {
            print("스테이지 삭제");
            CameraManager.instance.isPuzzle = true;
            _currentStageObject.gameObject.SetActive(false);
        }

        if(CameraManager.instance.isPuzzle == true)
        {
            CameraManager.instance.PuzzleCamActive();
        }

        print("스테이지 로드");
        Stage stagePrefab = Resources.Load<Stage>($"{name} {index}");
        _currentStageObject.gameObject.SetActive(true);
        print("스테이지 생성");*/
    }
}