using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public GameObject LController;
    public GameObject RController;

    bool isGrabbed;   
    bool isLeftController;

    void Start()
    {
        isGrabbed = false;

    }

    void Update()
    {
        if (isGrabbed) 
        {
            this.transform.parent = isLeftController ? LController.transform : RController.transform;
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

    public void Grab(float triggerPress, string leftOrRight)
    {
        if (triggerPress > 0.0f)
            isGrabbed = true;
        else 
            isGrabbed = false;
        
        if (leftOrRight == "left")
            isLeftController = true;
        else 
            isLeftController = false;
    }
}
