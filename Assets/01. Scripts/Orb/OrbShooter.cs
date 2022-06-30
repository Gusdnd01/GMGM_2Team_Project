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
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShoot)
        {
            Shoot();
        }
    }
    public void ActiveOrb()
    {
        orb.transform.position = spawnPos.position;
        orb.gameObject.SetActive(true);
        isShoot = false;
    }
    public void Shoot()
    {
        isShoot = true;
        orb.Shoot(() => ActiveOrb());
    }
}
