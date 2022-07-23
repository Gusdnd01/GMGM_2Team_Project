using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleMove : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;

    private void Start()
    {
        StartCoroutine(TitleMoving());
    }

    IEnumerator TitleMoving()
    {
        while(true)
        {


            yield return new WaitForSeconds(0.5f);
        }
    }
}
