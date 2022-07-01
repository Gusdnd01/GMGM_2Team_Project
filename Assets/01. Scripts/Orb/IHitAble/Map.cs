using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IHitAble
{
    public void Hit(GameObject obj)
    {
        obj.GetComponent<Orb>().DeActive();
    }
}
