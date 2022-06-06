using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 1f;
    public int BulletDamage = 1;
    public bool isRelativeToCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        if(isRelativeToCamera)
        {
            transform.position += Camera.main.transform.forward * BulletSpeed * Time.fixedDeltaTime;
        }else
        {
            transform.position += transform.forward * BulletSpeed * Time.fixedDeltaTime;
        }
    }
}
