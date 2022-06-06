using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, ObjectControl
{
    public float health;
    private float maxHealth;
    public Slider slider;
    public float moveSpeed = 1f;
    public float awayDistance = 20f;
    private GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            this.health -= other.GetComponent<Bullet>().BulletDamage;
        }
    }

    // Start is called before the first frame update
    void Start(){
        maxHealth = health;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
        slider.value = health/maxHealth;
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
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }else
        {
            Quaternion targetRotation = Quaternion.LookRotation(destination.position - this.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f * Time.deltaTime);
            //shoot
        }

        //Debug.Log(distanceLeft);

    }

    void checkHealth()
    {
        if(health <= 0)
        {
            player.GetComponent<PlayerSpaceship>().isShooting = false;
            this.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter()
    {
        //this.gameObject.SetActive(false);
        player.GetComponent<PlayerSpaceship>().isShooting = true;
        throw new System.NotImplementedException();
    }

    public void OnPointerExit()
    {
        player.GetComponent<PlayerSpaceship>().isShooting = false;
        throw new System.NotImplementedException();
    }

    public void OnPointerClick()
    {
        //throw new System.NotImplementedException();
    }
}
