using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private RectTransform _canvas;

    [Header("설정 창")]
    [SerializeField]
    RectTransform _escPanel;
    [SerializeField]
    RectTransform _optionPanel;

    [SerializeField]
    Image _fadePanel;

    bool _isEsc = false;
    bool _isOption = false;

    Menu menu;
    Option option;

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
        menu = FindObjectOfType<Menu>();
        option = FindObjectOfType<Option>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isEsc = !_isEsc;
            Escape();
        }

        menu.MenuTransform();
        option.OptionTransform();
    }

    #region Pause패널 함수
    void Escape()
    {
        StartCoroutine(EscapePanel());
    }
    IEnumerator EscapePanel()
    {

        while (true)
        {
            if (_isEsc)
            {
                _escPanel.gameObject.SetActive(_isEsc ? true : false);

                yield return new WaitForSecondsRealtime(0.5f);

                Time.timeScale = 0;
            }

            else
            {
                Time.timeScale = 1;

                yield return new WaitForSecondsRealtime(0.5f);

                _escPanel.gameObject.SetActive(_isEsc ? true : false);

            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }
    #endregion

    #region
    public void SoundOption()
    {
        StartCoroutine(Option());
    }

    IEnumerator Option()
    {
        if (_isOption)
        {
            _optionPanel.gameObject.SetActive(_isOption ? true : false);

            _optionPanel.DOScaleY(1, 0.5f);

            yield return new WaitForSecondsRealtime(1f);
        }

        else
        {
            _optionPanel.DOScaleY(0, 0.5f);

            yield return new WaitForSecondsRealtime(1f);

            _optionPanel.gameObject.SetActive(_isOption ? true : false);
        }
    }
    #endregion
}
