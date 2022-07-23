using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private RectTransform _canvas;

    [SerializeField]
    Image _fadePanel;


    public Image FadePanel
    {
        get
        {
            print("페이드 패널 가져오기");
            return _fadePanel;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Multiple instance is running{this}");
        }
        Instance = this;

        _canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }
}
