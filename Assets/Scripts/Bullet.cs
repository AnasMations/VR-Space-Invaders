using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 1f;

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
        transform.position += transform.forward * BulletSpeed * Time.fixedDeltaTime;
    }
}
