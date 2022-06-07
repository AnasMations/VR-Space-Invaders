using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    public float minSpawnTime;
    public float maxSpawnTime;

    void shoot()
    {
        InvokeRepeating("instantiateBullet", 0f, Random.Range(minSpawnTime, maxSpawnTime));
    }
}
