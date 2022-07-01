using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    [SerializeField] private SpriteRenderer up;
    [SerializeField] private SpriteRenderer down;
    [SerializeField] private SpriteRenderer right;
    [SerializeField] private SpriteRenderer left;
    [SerializeField] private SpriteRenderer rot;

    public void Move(Vector2 dir)
    {
        if(dir.y > 0) { }
    }
    public void Rot()
    {

    }
}
