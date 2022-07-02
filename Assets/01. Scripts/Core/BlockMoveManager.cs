using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMoveManager : MonoBehaviour
{
    public static BlockMoveManager instance;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveDelay;
    private bool isCanControll = true;
    public bool IsCanControll { get { return isCanControll; } set { isCanControll = value; } }

    #region 포커스 관련
    [Header("포커스")]
    [SerializeField] private GameObject focusObject;
    [SerializeField] private SpriteRenderer upArrow;
    [SerializeField] private SpriteRenderer downArrow;
    [SerializeField] private SpriteRenderer rightArrow;
    [SerializeField] private SpriteRenderer leftArrow;
    [SerializeField] private SpriteRenderer rotArrow;
    #endregion

    #region 사운드
    [Header("사운드")]
    [SerializeField] private AudioClip moveClip;
    [SerializeField] private AudioClip moveCancelClip;
    [SerializeField] private AudioClip rotClip;
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
        ResetTargetBlock();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && targetBlock != null)
        {
            PoolManager.instance.Pop(PoolType.Audio).GetComponent<AudioPool>().Play(rotClip, Random.Range(0.9f, 1.1f));
            targetBlock.Rotate();
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(() => rotArrow.color = Color.red);
            seq.Append(rotArrow.DOColor(Color.white, 0.25f));
            focusObject.transform.rotation = Quaternion.identity;
        }
    }
    public void SetTargetBlock(BlockMove block)
    {
        if (!isCanControll) return;
        focusObject.SetActive(true);
        focusObject.transform.SetParent(block.transform);
        focusObject.transform.localPosition = Vector3.zero;
        targetBlock = block;
    }
    public void ResetTargetBlock()
    {
        focusObject.SetActive(false);
        focusObject.transform.SetParent(null);
        targetBlock = null;
    }
    private void ArrowEffect(Vector2 dir)
    {
        SpriteRenderer targetArrow = null;
        if (dir.x > 0) targetArrow = rightArrow;
        if (dir.x < 0) targetArrow = leftArrow;
        if (dir.y > 0) targetArrow = upArrow;
        if (dir.y < 0) targetArrow = downArrow;
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() => {
            targetArrow.color = Color.red;
            targetArrow.transform.localScale = Vector3.one;
        });
        seq.Append(targetArrow.DOColor(Color.white, 0.25f));
        seq.Join(targetArrow.transform.DOScale(Vector3.one * 0.5f, 0.25f));
    }
    IEnumerator MoveCor()
    {
        WaitForSeconds ws = new WaitForSeconds(moveDelay);
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
                PoolManager.instance.Pop(PoolType.Audio).GetComponent<AudioPool>().Play(moveCancelClip, Random.Range(0.9f, 1.1f));
                yield return ws;
                continue;
            }
            targetBlock.Move(moveDir, moveDelay);
            ArrowEffect(moveDir);

            PoolManager.instance.Pop(PoolType.Audio).GetComponent<AudioPool>().Play(moveClip, Random.Range(0.9f, 1.1f));

            yield return ws;
        }
    }
}
