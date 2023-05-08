using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public GameObject controller;

    bool isGrabbed;   

    void Start()
    {
        isGrabbed = false;

    }

    void Update()
    {
        if (isGrabbed) 
        {
            this.transform.parent = controller.transform;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;

        } 
        else
        {
            this.transform.parent = null;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().useGravity = true;
        }   
    }

    public void Grab(float triggerPress)
    {
        if (triggerPress > 0.0f)
            isGrabbed = true;
        else 
            isGrabbed = false;
    }
}
