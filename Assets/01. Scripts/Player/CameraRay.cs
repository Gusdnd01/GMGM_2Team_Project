using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay((Vector3)mousePos, Vector3.forward * 100, Color.green, 1f);
            hit = Physics2D.Raycast(mousePos, Vector3.forward, 100, layerMask);
            //if (//Physics.Raycast(ray, out hit, 100, layerMask))
            //{
                
            //}
            if(hit)
            {
                hit.transform.GetComponent<IClickAble>().MouseDown();
            }
        }
    }
}
