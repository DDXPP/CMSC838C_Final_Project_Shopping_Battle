using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Rigidbody player;
    public GameObject rig;
    float playerMovingSpeed;

    void Start() 
    {
        playerMovingSpeed = 3.0f;
    }

    void Update()
    {
        var joystickAxisL = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        float fixedY = player.position.y;
        float pressedForce = Mathf.Abs(joystickAxisL.x) > Mathf.Abs(joystickAxisL.y) ? Mathf.Abs(joystickAxisL.x) : Mathf.Abs(joystickAxisL.y);

        transform.position += Quaternion.Euler(0, rig.transform.rotation.eulerAngles.y, 0) * (new Vector3(joystickAxisL.x * playerMovingSpeed * Time.deltaTime, 0, joystickAxisL.y * playerMovingSpeed * Time.deltaTime));
    }

 }
