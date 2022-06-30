using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private RectTransform _canvas;
    private Image _fadePanel;
    private Button startButton;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _fadePanel = _canvas.Find("FadePanel").GetComponent<Image>(); 
        startButton = _canvas.Find("StartButton").GetComponent<Button>();

        startButton.onClick.AddListener(() =>
        {
            Sequence seq = DOTween.Sequence();

            _fadePanel.DOFade(1, 1f);

            seq.AppendInterval(1.5f);

            seq.AppendCallback(() =>
            {
                SceneManager.LoadScene("MainScene");
            });
        });
    }
}
