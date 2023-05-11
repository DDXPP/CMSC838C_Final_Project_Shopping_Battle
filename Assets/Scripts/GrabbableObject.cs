using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public GameObject LController;
    public GameObject RController;

    bool isGrabbed;   
    bool isLeftController;
    float price;

    void Start()
    {
        isGrabbed = false;
        switch (this.tag)
        {
            case "Item_Chips":
                price = 4.0f;
                break;
            case "Item_MMs":
                price = 1.0f;
                break;
            case "Item_Bose":
                price = 150.0f;
                break;
            case "Item_AirPods":
                price = 250.0f;
                break;
            case "Item_Coke":
                price = 7.0f;
                break;
            case "Item_Dyson":
                price = 750.0f;
                break;
            case "Item_Jam":
                price = 5.0f;
                break;
            case "Item_Protein":
                price = 50.0f;
                break;
            case "Item_PS5":
                price = 500.0f;
                break;
            case "Item_RiceCooker":
                price = 40.0f;
                break;
            case "Item_Switch":
                price = 350.0f;
                break;
            case "Item_Tide":
                price = 20.0f;
                break;
            case "Item_Tissue":
                price = 2.0f;
                break;
        }
    }

    public float GetPrice()
    {
        return price;
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
