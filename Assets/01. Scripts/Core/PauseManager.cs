using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("설정 창")]
    [SerializeField]
    RectTransform _escPanel;
    [SerializeField]
    RectTransform _optionPanel;

    [SerializeField]
    Menu menu;
    [SerializeField]
    Option option;

    bool _isEsc = false;
    bool _isOption = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isEsc = !_isEsc;
            Escape();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

        }

        if (_isEsc)
        {
            menu.MenuTransform();
        }
        else return;

        if (_isOption)
        {
            option.OptionTransform();
        }
        else return;
    }

    #region Pause패널
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

    #region Option
    public void SoundOption()
    {
        StartCoroutine(Option());
    }

    IEnumerator Option()
    {
        if (_isOption)
        {
            _optionPanel.gameObject.SetActive(_isOption ? true : false);

            yield return new WaitForSecondsRealtime(1f);
        }

        else
        {
            yield return new WaitForSecondsRealtime(1f);

            _optionPanel.gameObject.SetActive(_isOption ? true : false);
        }
    }
    #endregion
}
