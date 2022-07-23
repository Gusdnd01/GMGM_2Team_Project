using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    int index;

    [Header("메뉴 텍스트")]
    [SerializeField]
    TextMeshProUGUI _resume;
    [SerializeField]
    TextMeshProUGUI _option;
    [SerializeField]
    TextMeshProUGUI _back;

    /// <summary>
    /// UI Text 움직이는 코드(escPanel에서)
    /// </summary>
    public void MenuTransform()
    {
        index = Mathf.Clamp(index, 0, 2);

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            index++;

            TextColorChange();
        }


        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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
            case 2:
                _resume.color = Color.gray;
                _option.color = Color.white;
                _back.color = Color.white;
                break;
            case 1:
                _resume.color = Color.white;
                _option.color = Color.gray;
                _back.color = Color.white;
                break;
            case 0:
                _resume.color = Color.white;
                _option.color = Color.white;
                _back.color = Color.gray;
                break;
            default:
                break;
        }
    }
}
