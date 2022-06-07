using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().PlayerHealth = 0f;
        }
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
