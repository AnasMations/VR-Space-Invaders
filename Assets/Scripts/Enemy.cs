using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, ObjectControl
{
    public float health;
    private float maxHealth;
    public Slider slider;
    public MeshRenderer meshRenderer;
    private float flashTime = 0.05f;
    public float collideDamage;
    public int scorePoints;
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public float awayDistance = 20f;
    public float bulletShootRate = 0.5f;
    public GameObject bullet;
    public Transform bulletSpawnPosition;
    public bool isShooting = false;
    private PlayerSpaceship player;
    private GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            this.health -= other.GetComponent<Bullet>().BulletDamage;
            StartCoroutine("flash");
            Destroy(other.gameObject);
        }else if(other.CompareTag("Player"))
        {
            this.health = 0;
            gameManager.PlayerHealth -= collideDamage;
        }else if(other.CompareTag("ShootArea"))
        {
            player.isShooting = true;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("ShootArea"))
        {
            player.isShooting = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("ShootArea"))
        {
            player.isShooting = false;
        }
    }

    // Start is called before the first frame update
    void Start(){
        maxHealth = health;
        player = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shoot();
    }

    // Update is called once per frame
    void Update(){
        //Move enemy to player position in the scene
        moveTo(player.transform, moveSpeed);
        checkHealth();
    }

    void moveTo(Transform destination, float moveSpeed)
    {
        float distanceLeft = ((destination.position - this.transform.position).sqrMagnitude)/1000;

        if(distanceLeft > awayDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(destination.position - this.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            isShooting = false;
        }else
        {
            Quaternion targetRotation = Quaternion.LookRotation(destination.position - this.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //shoot
            isShooting = true;
        }

        //Debug.Log(distanceLeft);

    }

    void checkHealth()
    {
        slider.value = health/maxHealth;

        if(health <= 0)
        {
            //Enemy death
            player.isShooting = false;
            gameManager.Score += this.scorePoints;
            isShooting = false;
            FindObjectOfType<AudioManager>().Play("EnemyBoom");
            this.gameObject.SetActive(false);
        }
    }

    void shoot()
    {
        InvokeRepeating("instantiateBullet", 0f, bulletShootRate);
    }

    void instantiateBullet()
    {
        if(isShooting)
        {
            Instantiate(bullet, bulletSpawnPosition.position, this.transform.rotation);
        }
    }

    IEnumerator flash()
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        meshRenderer.material.color = Color.white;
    }

    public void OnPointerEnter()
    {
        //this.gameObject.SetActive(false);
        player.isShooting = true;
        throw new System.NotImplementedException();
    }

    public void OnPointerExit()
    {
        player.isShooting = false;
        throw new System.NotImplementedException();
    }

    public void OnPointerClick()
    {
        //throw new System.NotImplementedException();
    }
}
