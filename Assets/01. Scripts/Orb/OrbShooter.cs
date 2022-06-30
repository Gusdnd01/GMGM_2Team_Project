using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbShooter : MonoBehaviour
{
    [SerializeField] private Orb orb;
    [SerializeField] private Transform spawnPos;
    public void SpawnOrb()
    {
        Instantiate(orb, spawnPos.position, Quaternion.identity);
    }

    public void DespawnOrb()
    {

    }
}
