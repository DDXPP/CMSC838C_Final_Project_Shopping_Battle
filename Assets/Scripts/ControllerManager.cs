using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    GameObject grabbedObject;
    public Rigidbody player;

    void Start()
    {
        grabbedObject = null;
    }
    

    void Update()
    {
        // use right hand trigger to grab object
        if (GetRightTriggerPress() > 0.0f)
        {   
            GrabObject(GetRightTriggerPress());
        }
        else 
        {
            if (grabbedObject != null)
            {
                grabbedObject.GetComponent<GrabbableObject>().Grab(0.0f);
            }
        }
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
        if (grabbedObject == null)
        {
            GameObject nearestObject = null;
            float distance;
            float nearestDistance = float.MaxValue;

            Collider[] hitColliders = Physics.OverlapSphere(GetPosition(), 0.2f);
            for (int i = 0; i < hitColliders.Length; i++)
            {
                distance = (GetPosition() - hitColliders[i].gameObject.transform.position).sqrMagnitude;
                if (distance < nearestDistance) 
                {
                    if (hitColliders[i].gameObject.GetComponent<GrabbableObject>() != null) 
                    {
                        nearestDistance = distance; 
                        nearestObject = hitColliders[i].gameObject;
                    }
                } 
            }

            if (nearestObject != null)
                grabbedObject = nearestObject;  
        }

        grabbedObject.GetComponent<GrabbableObject>().Grab(pressedValue);
    }
}
