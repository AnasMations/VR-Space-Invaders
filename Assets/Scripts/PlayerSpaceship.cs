using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{

    public float PlayerSpeed = 10f;
    public float ShootRate = 1f;
    public GameObject ShootBullet;
    public Transform BulletSpawnPoint;
    public bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        this.transform.Translate(Vector3.forward * PlayerSpeed * Time.fixedDeltaTime, Camera.main.transform);
    }

    void shoot()
    {
        InvokeRepeating("instantiateBullet", 0f, ShootRate);
    }

    void instantiateBullet()
    {
        if(isShooting)
        {
            Instantiate(ShootBullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        }
    }
}
