using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour, IClickAble
{
    public void MouseDown()
    {
        print("¿€µø¡ﬂ");
        StageFocusManager.instance.StageTransform(this.transform);
    }

    private void Update()
    {
        if(transform.position.x == StageFocusManager.instance.playerObject.position.x && Input.GetKeyDown(KeyCode.F))
        {
            SceneChangeManager.instance.LoadPrefab("Puzzle", 1);
        }
    }
}
