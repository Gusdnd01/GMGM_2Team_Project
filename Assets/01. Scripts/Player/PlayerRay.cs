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
    private Image fade;

    void Start()
    {
        fade = UIManager.Instance.FadePanel;
        _canvas = GameObject.Find("Canvas").GetComponent<Transform>();
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

                monitorInterface.SetActive(true);

                seq.AppendInterval(2.5f);

                fade.DOFade(1, 1);

                seq.AppendCallback(() =>
                {
                    SceneChangeManager.instance.LoadPrefab("Puzzle", 1);
                    CameraManager.instance.isPuzzle = true;
                });
            }
        }
    }
}
