using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTargetAmount : MonoBehaviour
{
    public float RadNum = 0.0f;
    public Text targetAmountText;
    public Timer timer_script;
    public bool timerStatus;

    private void Start()
    {
        timerStatus = timer_script.startTimer;
    }

    private void DisplayTarget()
    {
        targetAmountText.text = "Target $ " + string.Format("{0:00}", RadNum);
    }

    void Update()
    {
        timerStatus = timer_script.startTimer;

        if (OVRInput.GetUp(OVRInput.RawButton.Y))
        {
            RadNum = Random.Range(10, 1000);
        }

        if (timerStatus == true)
        {
            DisplayTarget();
        }
        else
        {
            targetAmountText.text = "Target $ 0";
        }
    }
}
