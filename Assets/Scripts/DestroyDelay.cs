using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{

    public float destroyDelay = 10f;

    void Start()
    {
        Destroy(this.gameObject, destroyDelay);
    }

}
