using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Key : MonoBehaviour, IHitAble
{
    [SerializeField] private UnityEvent callEvent;
    Image fade;


    private void Start()
    {
        fade = UIManager.Instance.FadePanel;
    }
    public void Hit(GameObject obj)
    {
        obj.GetComponent<Orb>().DeActive();
        callEvent?.Invoke();
    }

    public void Test()
    {
        SceneChangeManager.instance.LoadPrefab("StageSelect", 1);
    }
}
