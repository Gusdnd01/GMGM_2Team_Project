using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cannon : BlockMove, IHitAble
{
    [SerializeField] private Transform exitPos;
    public void Hit(GameObject obj)
    {
        Sequence seq = DOTween.Sequence();

        Vector3 dir = (exitPos.position - transform.position).normalized;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        float velo = rb.velocity.magnitude;
        obj.SetActive(false);
        obj.transform.position = transform.position;

        seq.AppendInterval(0.5f);

        seq.AppendCallback(() =>
        {
            obj.SetActive(true);
            rb.velocity = dir * velo;
        });

        
    }
}
