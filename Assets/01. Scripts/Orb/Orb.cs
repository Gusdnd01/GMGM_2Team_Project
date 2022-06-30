using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Orb : MonoBehaviour
{
    Action action;
    Rigidbody2D rb;
    public void Shoot(Action callback)
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 10;
        action = callback;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        DeActive();
    }
    public void DeActive()
    {
        rb.velocity = Vector2.zero;
        action();
    }
}
