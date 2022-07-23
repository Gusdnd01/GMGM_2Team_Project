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
    private GameObject stageSelect;
    private GameObject nextStage;

    [SerializeField] private Transform puzzleParent;
    [SerializeField] private Transform platformParent;
    [SerializeField] private Transform stageSelectParent;

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

        //Set(1);
        LoadResource("Platform", 1);
        LoadResource("Puzzle", 1);
        LoadResource("StageSelect", 1);
    }

    private void Start()
    {
        fade = UIManager.Instance.FadePanel;
    }

    public void Set(int idx)
    {
        #region 스테이지 생성
        puzzle = Instantiate(Resources.Load<GameObject>($"Puzzle {idx}"), Vector3.zero, Quaternion.identity);
        stage = Instantiate(Resources.Load<GameObject>($"Platform {idx}"), Vector3.zero, Quaternion.identity);
        stageSelect = Instantiate(Resources.Load<GameObject>($"StageSelect {idx}"), Vector3.zero, Quaternion.identity);
        #endregion

        #region 스테이지 부모 지정
        puzzle.transform.SetParent(puzzleParent);
        stage.transform.SetParent(platformParent);
        stageSelect.transform.SetParent(stageSelectParent);
        #endregion

        puzzleParent.gameObject.SetActive(false);
        platformParent.gameObject.SetActive(false);
        stageSelectParent.gameObject.SetActive(false);
        /*for(int i = 0; i < stages.Count; i++)
        {
            Stage stage = stages[i];

            Instantiate(stage, transform.position, Quaternion.identity);

            stage.gameObject.SetActive(false);
        }*/
    }
    void LoadResource(string name, int idx)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>($"{name} {idx}"), Vector3.zero, Quaternion.identity);

        if (name == "Puzzle")
            obj.transform.SetParent(puzzleParent);

        if (name == "Platform")
            obj.transform.SetParent(platformParent);

        if (name == "StageSelect")
            obj.transform.SetParent(stageSelectParent);
    }

    public void LoadPrefab(string name, int index)
    {
        Sequence seq = DOTween.Sequence();

        if (name == "Platform")
        {
            seq.AppendInterval(1.5f);

            platformParent.gameObject.SetActive(true);
            puzzleParent.gameObject.SetActive(false);
            stageSelectParent.gameObject.SetActive(false);

            fade.DOFade(0, 1);

            CameraManager.instance.MainCamActive();
        }
        if(name == "Puzzle")
        {
            seq.AppendInterval(1.5f);

            platformParent.gameObject.SetActive(false);
            puzzleParent.gameObject.SetActive(true);
            stageSelectParent.gameObject.SetActive(false);

            fade.DOFade(0, 1);

            CameraManager.instance.PuzzleCamActive();
        }
        if(name == "StageSelect")
        {
            CameraManager.instance.StageSelectCamActive();

            seq.AppendInterval(1.5f);

            platformParent.gameObject.SetActive(false);
            puzzleParent.gameObject.SetActive(false);
            stageSelectParent.gameObject.SetActive(true);

            seq.Append(fade.DOFade(0, 1));

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