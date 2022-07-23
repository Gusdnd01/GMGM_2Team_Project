using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReset : MonoBehaviour
{
    private List<Vector3> initPosition = new List<Vector3>();
    private List<Quaternion> initRotation = new List<Quaternion>();
    private List<Transform> childTransform = new List<Transform>();

    private void Awake() 
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            childTransform.Add(transform.GetChild(i).GetComponent<Transform>());
            initPosition.Add(transform.GetChild(i).GetComponent<Transform>().position);
            initRotation.Add(transform.GetChild(i).GetComponent<Transform>().rotation);
        }
    }

    private void OnEnable() 
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            childTransform[i].position = initPosition[i];
            childTransform[i].rotation = initRotation[i];
        }
    }
}
