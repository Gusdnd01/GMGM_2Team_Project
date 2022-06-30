using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMove : MonoBehaviour, IClickAble
{
    public virtual void Move(Vector2 moveDir, float moveDelay)
    {
        transform.DOMove(transform.position + (Vector3)moveDir, moveDelay * 0.75f);
    }
    public virtual void Rotate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, -90);
    }
    public void MouseDown()
    {
        BlockMoveManager.instance.SetTargetBlock(this);
    }
}
