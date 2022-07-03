using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageFocusManager : MonoBehaviour
{
    public static StageFocusManager instance;

    public Transform playerObject;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Multiple instance is running({this})");
        }

        instance = this;
    }

    public void StageTransform(Transform transform)
    {
        Sequence seq = DOTween.Sequence();

        playerObject.DOMoveX(transform.position.x, 1f);

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            playerObject.parent = transform;
        });
    }

    public void StartStage(Transform transform)
    {
        
    }
}
