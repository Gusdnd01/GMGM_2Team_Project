using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour, IClickAble
{
    [SerializeField] int stageIndex;
    public void MouseDown()
    {
        StageFocusManager.instance.SetStage(this.transform, stageIndex);
    }

    private void Update()
    {
        if(transform.position.x == StageFocusManager.instance.playerObject.position.x && Input.GetKeyDown(KeyCode.F))
        {
            
            SceneChangeManager.instance.LoadPrefab("Puzzle", 1);
        }
    }
}
