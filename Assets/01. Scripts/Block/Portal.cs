using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IHitAble
{
    [SerializeField] private Portal pairPortal;
    public void Hit(GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        float velo = rb.velocity.magnitude;
        obj.SetActive(false);
        obj.transform.position = pairPortal.transform.position;
        obj.SetActive(true);
        rb.velocity = pairPortal.transform.up * velo;
    }
}