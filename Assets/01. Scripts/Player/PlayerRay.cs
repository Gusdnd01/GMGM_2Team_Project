using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerRay : MonoBehaviour
{
    float maxDistance = 1;
    [SerializeField] LayerMask raycastLayer;
    [SerializeField] private GameObject monitorInterface;

    private Transform _canvas;
    private Image _fadePanel;

    void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        _fadePanel = _canvas.Find("FadePanel").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 dir = (transform.localScale.x == 1) ? transform.right : -transform.right;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, maxDistance, raycastLayer);

            if (hit)
            {
                Sequence seq = DOTween.Sequence();

                CameraManager.instance.MonitorCamActive();

                seq.AppendInterval(1.5f);

                seq.AppendCallback(() =>
                {
                    monitorInterface.SetActive(true);

                });

                seq.Join(_fadePanel.DOFade(1, 1f));
            }
        }
    }
}
