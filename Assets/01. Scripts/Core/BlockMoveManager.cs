using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveManager : MonoBehaviour
{
    public static BlockMoveManager instance;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject focusObject;
    #region 포커스 관련
    [Header("포커스")]
    [SerializeField] private SpriteRenderer rotRendere;
    [SerializeField] private 
    #endregion
    BlockMove targetBlock;
    float h, v;
    public void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple instance is running(BlockMoveManager)");
        }
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(MoveCor());
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && targetBlock != null)
        {
            targetBlock.Rotate();
            focusObject.transform.rotation = Quaternion.identity;
        }
    }
    public void SetTargetBlock(BlockMove block)
    {
        focusObject.transform.SetParent(block.transform);
        focusObject.transform.localPosition = Vector3.zero;
        targetBlock = block;
    }
    IEnumerator MoveCor()
    {
        WaitForSeconds ws = new WaitForSeconds(0.15f);
        float moveDelay = 0.15f;
        while (true)
        {
            yield return new WaitUntil(() => (h != 0 || v != 0) && targetBlock != null);
            Vector2 moveDir = Vector2.zero;

            if (h != 0)
            {
                moveDir.x = h > 0 ? 1 : -1;
            }
            else
            {
                moveDir.y = v > 0 ? 1 : -1;
            }

            RaycastHit2D hit;
            hit = Physics2D.Raycast(targetBlock.transform.position + (Vector3)moveDir * 0.55f, moveDir, 0.45f, layerMask);
            Debug.DrawRay(targetBlock.transform.position + (Vector3)moveDir * 0.55f, moveDir * 0.45f, Color.blue, 1);
            if (hit.transform != null)
            {
                yield return ws;
                continue;
            }
            targetBlock.Move(moveDir, moveDelay);
            yield return ws;
        }
    }
}
