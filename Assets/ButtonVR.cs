using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    private float rotateSpeed = 0f;

    public void OnPointerEnter()
    {
        rotateSpeed = 200f;
        throw new System.NotImplementedException();
    }

    public void OnPointerExit()
    {
        SceneManager.LoadScene("SpaceScene");
        throw new System.NotImplementedException();
    }

    public void OnPointerClick()
    {
        //throw new System.NotImplementedException();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ShootArea"))
        {
            rotateSpeed = 200f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("ShootArea"))
        {
            SceneManager.LoadScene("SpaceScene");
        }
    }

    void Update()
    {
        transform.RotateAround(this.transform.position, Vector3.right, rotateSpeed * Time.deltaTime);
    }
}
