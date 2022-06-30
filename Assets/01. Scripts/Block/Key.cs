using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Key : MonoBehaviour, IHitAble
{
    [SerializeField] private UnityEvent callEvent;

    public void Hit(GameObject obj)
    {
        obj.GetComponent<Orb>().DeActive();
        callEvent?.Invoke();
    }

    public void Test()
    {
        print("AA");
    }
}
