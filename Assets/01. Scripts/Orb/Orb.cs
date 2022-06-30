using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Orb : MonoBehaviour
{
    Action action;

    public void Set(Action callback)
    {
        action = callback;
    }
    public void DeActive()
    {
        action();
    }
}
