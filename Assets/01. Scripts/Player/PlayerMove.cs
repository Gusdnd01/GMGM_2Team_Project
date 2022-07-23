using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 moveDir;
    public float localScale = 1;
    Animator anim;

    #region AnimatorHash
    readonly int isMove = Animator.StringToHash("isMove");
    #endregion

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.timeScale > 0)
        {
            Move();
        }
    }
    /// <summary>
    /// 플레이어 움직임
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        moveDir = new Vector2(h, 0);

        transform.position += (Vector3)moveDir * speed * Time.deltaTime;

        if (moveDir.x == 1f && h != 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool(isMove, true);
        }
        else if (moveDir.x == -1f && h != 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool(isMove, true);
        }

        if (h == 0)
        {
            anim.SetBool("isMove", false);
        }
    }
}
