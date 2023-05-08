using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is created for grabbing and dropping objects. 
// Attach this script to Left/RightHandAnchor
public class RControllerGrab : MonoBehaviour
{
    
    GameObject grabbedObject;
    public Rigidbody player;
    // float tempPressValue = 0.5f;

    void Start()
    {
        grabbedObject = null;
    }
    

    void Update()
    {
        GrabObject(GetRightTriggerPress());
    }

    Vector3 GetPointingDir() 
    {
        return transform.forward;
    }

    Vector3 GetPosition()
    {
        return transform.position;
    }


    float GetRightTriggerPress()
    {
        return OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
    }

    void GrabObject(float pressedValue)
    {
        if (pressedValue == 0.0f && grabbedObject != null) 
        {
            grabbedObject.GetComponent<GrabbableObject>().Grab(pressedValue);
            grabbedObject = null;
        }
        else if (pressedValue > 0.0f)
        {
            if (grabbedObject == null)
            {
                GameObject nearestObject = null;
                float distance;
                float nearestDistance = float.MaxValue;

                Collider[] hitColliders = Physics.OverlapSphere(GetPosition(), 0.2f);
                foreach (Collider collider in hitColliders)
                {
                    distance = (GetPosition() - collider.gameObject.transform.root.gameObject.transform.position).sqrMagnitude;
                    if (distance < nearestDistance) 
                    {
                        if (collider.gameObject.transform.root.gameObject.GetComponent<GrabbableObject>() != null) 
                        {
                            nearestDistance = distance; 
                            if (nearestObject == null)
                            {
                                nearestObject = collider.gameObject.transform.root.gameObject;  
                            }
                            else if (nearestObject != collider.gameObject.transform.root.gameObject) {
                                nearestObject = collider.gameObject.transform.root.gameObject;  
                            }
                            // Debug.Log("nearestObject------------" + nearestObject.name + "  " + nearestDistance);
                        }
                    } 
                }
                // if (nearestObject != null)
                    grabbedObject = nearestObject;  
            }

            grabbedObject.GetComponent<GrabbableObject>().Grab(pressedValue);
        }
    }
}
