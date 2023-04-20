using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject positionMarkerPrefab;
    public GameObject arrowPrefab;

    private GameObject positionMarker;
    private GameObject arrow;


    int rayLength = 10;
    float delay = 0.01f;
    public Material redLineMat, greenLineMat;

    bool aboutToTeleport = false;
    bool selectingDirection = false;
    Vector3 teleportPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                aboutToTeleport = true;
                teleportPos = hit.point;

                GameObject myLine = new GameObject();
                myLine.transform.position = transform.position; 
                myLine.AddComponent<LineRenderer>();

                LineRenderer lr = myLine.GetComponent<LineRenderer>();
                lr.material = redLineMat;
                if (hit.collider.gameObject.tag == "ground")
                    lr.material = greenLineMat; 

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
            selectingDirection = true;
            positionMarker = Instantiate(positionMarkerPrefab, new Vector3(teleportPos.x, 1.5f, teleportPos.z),  Quaternion.identity);
            arrow = Instantiate(arrowPrefab, new Vector3(teleportPos.x, 3.0f, teleportPos.z),  Quaternion.identity);
        }

        if (selectingDirection)
        {
            if (joystickAxisR.x > 0.0f)
            {
                arrow.transform.Rotate(new Vector3(0, 15, 0) * 5.0f * Time.deltaTime);
            }
            if (joystickAxisR.x < 0.0f)
            {
                arrow.transform.Rotate(new Vector3(0, -15, 0) * 5.0f * Time.deltaTime);
            }

            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            {
                selectingDirection = false;
                Destroy(positionMarker); 
                Destroy(arrow);
                player.transform.position = new Vector3(teleportPos.x, player.transform.position.y, teleportPos.z); 
                player.transform.rotation = arrow.transform.rotation;
                
            }
        }
        
    }

}
