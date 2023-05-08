using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    private GameObject positionMarker;
    private GameObject arrow;


    int rayLength = 10;
    float delay = 0.01f;
    public Material redLineMat, greenLineMat;

    bool aboutToTeleport = false;
    bool selectingDirection = false;
    Vector3 teleportPos = new Vector3();


    void Update()
    {   
        var joystickAxisR = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        RaycastHit hit;
        // use right hand trigger to shoot ray
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (positionMarker != null)
                Destroy(positionMarker); 
            if (arrow != null)
                Destroy(arrow);
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 50))
            {
                
                teleportPos = hit.point;

                GameObject myLine = new GameObject();
                myLine.transform.position = transform.position; 
                myLine.AddComponent<LineRenderer>();

                LineRenderer lr = myLine.GetComponent<LineRenderer>();
                lr.material = redLineMat;
                if (hit.collider.gameObject.tag == "ground")
                {
                    aboutToTeleport = true;
                    lr.material = greenLineMat; 
                }
                    

                lr.startWidth = 0.01f;
                lr.endWidth = 0.01f;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, hit.point);
                GameObject.Destroy(myLine, delay); 
            } 
        }

        if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch) && aboutToTeleport)
        {
            aboutToTeleport = false;
            player.transform.position = new Vector3(teleportPos.x, player.transform.position.y, teleportPos.z); 
            player.transform.rotation = arrow.transform.rotation;
        }
    }

}
