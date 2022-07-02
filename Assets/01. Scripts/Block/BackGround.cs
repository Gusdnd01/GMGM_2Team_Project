using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour, IClickAble
{
    public void MouseDown()
    {
        BlockMoveManager.instance.ResetTargetBlock();
    }
}
