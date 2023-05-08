using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCartMovement : MonoBehaviour
{
    public Rigidbody player;
    public GameObject rig;
    public GameObject shoppingCart;
    float playerMovingSpeed;

    void Start() 
    {
        playerMovingSpeed = 3.0f;
    }

    void Update()
    {
        // Get joystick input
        var joystickAxisL = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        // Set height to be fixed
        float fixedY = player.position.y;
        // Use pressed force to determine moving speed
        float pressedForce = Mathf.Abs(joystickAxisL.x) > Mathf.Abs(joystickAxisL.y) ? Mathf.Abs(joystickAxisL.x) : Mathf.Abs(joystickAxisL.y);

        // Player locomotion
        transform.position += Quaternion.Euler(0, rig.transform.rotation.eulerAngles.y, 0) * (new Vector3(joystickAxisL.x * playerMovingSpeed * Time.deltaTime, 0, joystickAxisL.y * playerMovingSpeed * Time.deltaTime));
    
        float distanceBetweenPlayerAndShoppingCart = Vector3.Distance(this.transform.position, shoppingCart.transform.position);
        if (distanceBetweenPlayerAndShoppingCart < 1.5f & (isLeftIndexTriggerPressed() | isRightIndexTriggerPressed()))
        {
            shoppingCart.transform.parent = this.transform;
        }
        else 
        {
            shoppingCart.transform.parent = null;
        }
            
    }

    bool isLeftIndexTriggerPressed()
    {
        return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.0f;
    }

    bool isRightIndexTriggerPressed()
    {
        return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f;
    }

    
}
