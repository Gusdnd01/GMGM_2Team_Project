using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Option : MonoBehaviour
{
    int index = 0;

    [Header("Option Text")]
    [SerializeField]
    TextMeshProUGUI _master;
    [SerializeField]
    TextMeshProUGUI _bgm;
    [SerializeField]
    TextMeshProUGUI _sfx;
    [SerializeField]
    TextMeshProUGUI _back;

    /// <summary>
    /// 옵션 창 텍스트 움직임
    /// </summary>
    public void OptionTransform()
    {
        index = Mathf.Clamp(index, 0, 3);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            index++;

            TextColorChange();
        }


        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            index--;

            TextColorChange();
        }
    }
    /// <summary>
    /// 텍스트 색깔 변경
    /// </summary>
    private void TextColorChange()
    {
        print(index);

        switch (index)
        {
            case 0:
                _master.color = Color.gray;
                _bgm.color = Color.white;
                _sfx.color = Color.white;
                _back.color = Color.white;
                break;
            case 1:
                _master.color = Color.white;
                _bgm.color = Color.gray;
                _sfx.color = Color.white;
                _back.color = Color.white;
                break;
            case 2:
                _master.color = Color.white;
                _bgm.color = Color.white;
                _sfx.color = Color.gray;
                _back.color = Color.white;
                break;
            case 3:
                _master.color = Color.white;
                _bgm.color = Color.white;
                _sfx.color = Color.white;
                _back.color = Color.gray;
                break;
            default:
                break;
        }
    }
}
