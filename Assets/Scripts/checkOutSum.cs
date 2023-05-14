using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkOutSum : MonoBehaviour
{
    public Text CheckOutSummaryText;
    public quadCollider quad_script;
    public bool gameover = false;



    public float totalPrice_copy;
    public bool checkoutStatus_copy;


    void Update()
    {
        totalPrice_copy = quad_script.totalPrice;
        checkoutStatus_copy = quad_script.checkoutStatus;
        Debug.Log("checkoutStatus_copy: " + checkoutStatus_copy);

        if (checkoutStatus_copy == true)
        {
            CheckOutSummaryText.text = "You shopped $ " + totalPrice_copy;
            gameover = true;
        }
        else
        {
            gameover = false;
            CheckOutSummaryText.text = "";
        }

        
    }
}