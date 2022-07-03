using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbShooter : MonoBehaviour
{
    [SerializeField] private Orb orb;
    [SerializeField] private Transform spawnPos;
    bool isShoot;



    public void Start()
    {
        ActiveOrb();
    }
    public void ActiveOrb()
    {
        orb.transform.position = spawnPos.position;
        orb.gameObject.SetActive(true);
        isShoot = false;
        BlockMoveManager.instance.IsCanControll = true;
    }
    public void Shoot()
    {
        if (isShoot) return;
        isShoot = true;
        orb.Shoot(() => ActiveOrb());
        BlockMoveManager.instance.IsCanControll = false;
        BlockMoveManager.instance.ResetTargetBlock();
    }
}
