using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pannel;
    bool isDisplayed;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isDisplayed = !isDisplayed;
            pannel.SetActive(isDisplayed);
            Time.timeScale = isDisplayed ? 0 : 1;
        }
    }
}
