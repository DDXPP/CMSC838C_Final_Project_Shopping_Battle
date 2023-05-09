using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCartMovement : MonoBehaviour
{
    public Rigidbody player;
    public GameObject rig;
    public GameObject shoppingCart;
    public GameObject centerEyeAnchor;
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
        // if (distanceBetweenPlayerAndShoppingCart < 3.0f)
        {
            // var shoppingCartY = shoppingCart.transform.position.y;
            // shoppingCart.transform.parent = centerEyeAnchor.transform;
            // shoppingCart.transform.position = new Vector3(centerEyeAnchor.transform.position.x, shoppingCartY, centerEyeAnchor.transform.position.z);
            // shoppingCart.transform.localPosition = new Vector3(0, 0, 1);

            // shoppingCart.transform.parent = this.transform;
            // shoppingCart.transform.position = centerEyeAnchor.transform.position + centerEyeAnchor.transform.forward * 1;
            shoppingCart.transform.position = new Vector3(centerEyeAnchor.transform.position.x, shoppingCart.transform.position.y, centerEyeAnchor.transform.position.z)
                                            + 1* (new Vector3(centerEyeAnchor.transform.forward.x, 0, centerEyeAnchor.transform.forward.z)); 

            shoppingCart.transform.rotation = Quaternion.Euler(0, centerEyeAnchor.transform.rotation.eulerAngles.y, 0);
            shoppingCart.transform.Rotate(new Vector3(0, 90, 0));
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
