using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string shoppingScene, menuScene;

    public void StartBtn()
    {
        Scene scene = SceneManager.GetActiveScene();

        //returns true if the “X” button was released this frame.
        if (OVRInput.GetUp(OVRInput.RawButton.Y) && (scene.name == menuScene))
        {
            SceneManager.LoadScene("MainScene");
        }
        
    }

    void FixedUpdate()
    {
        StartBtn();

    }
}
