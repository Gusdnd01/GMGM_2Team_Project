using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageFocusManager : MonoBehaviour
{
    public static StageFocusManager instance;

    public Transform playerObject;
    [SerializeField] private Button stageButton;

    Image fade;
    private int targetIndex;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Multiple instance is running({this})");
        }

        instance = this;

        fade = UIManager.Instance.FadePanel;

        stageButton.onClick.AddListener(() =>
        {
            ChangeStage();
        });
    }

    public void ChangeStage()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(fade.DOFade(1,1));

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            SceneChangeManager.instance.LoadPrefab("Platform", targetIndex);
        });
    }
    public void SetStage(Transform transform, int index)
    {
        targetIndex = index;

        Sequence seq = DOTween.Sequence();

        playerObject.DOMoveX(transform.position.x, 1f);

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            playerObject.parent = transform;
        });
    }
}
