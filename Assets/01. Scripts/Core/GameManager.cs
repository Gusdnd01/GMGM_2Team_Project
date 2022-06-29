using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Start()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple instance is running");
        }
        instance = this;
    }
}
