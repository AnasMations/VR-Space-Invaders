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
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("EnemyBullet"))
        {
            gameManager.PlayerHealth -= other.GetComponent<Bullet>().BulletDamage;
        }
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
