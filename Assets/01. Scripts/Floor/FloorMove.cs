using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    public float speed;
    [SerializeField] private int StartPoint;
    [SerializeField] private Transform[] points;
    public int i;

    void Start()
    {
        transform.position = points[StartPoint].position;
    }

    /// <summary>
    /// index�� ���� point�� �޶����� �ڵ�(�̵� ����)
    /// </summary>
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
