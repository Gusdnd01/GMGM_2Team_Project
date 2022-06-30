using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Image fade;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Multiple instance is running {this}");
        }
        instance = this;

    }
    void Start()
    {
        fade = UIManager.Instance.FadePanel;
        fade.DOFade(0, 1);

        SceneChangeManager.instance.LoadPrefab("Platform", 1); 
    }
}
