using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadCollider : MonoBehaviour
{
    public LayerMask m_LayerMask;
    Collider[] itemInsideZone;
    Collider[] itemInsideZone_kart;
    public float totalPrice = 0.0f;

    public RandomTargetAmount target_script;
    public bool timerStatus_copy;
    //public float randomNum;

    public bool checkoutStatus = false;

    List<string> itemNames = new List<string>();

    Vector3 collider_scale;
    Vector3 collider_scale_kart;


    private void GetItemInCheckOUT()
    {
        collider_scale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 4, this.transform.localScale.z * 10);
        itemInsideZone = Physics.OverlapBox(this.transform.position, collider_scale, Quaternion.identity, m_LayerMask);

        foreach (Collider collider in itemInsideZone)
        {
            if (collider.gameObject.transform.root.gameObject.GetComponent<GrabbableObject>() != null)
            {
                GameObject currObject = collider.gameObject.transform.root.gameObject;
                string itemName = currObject.name;

                if (!itemNames.Contains(itemName))
                {
                    itemNames.Add(itemName);
                    totalPrice += currObject.GetComponent<GrabbableObject>().GetPrice();
                }
            }

        }


        collider_scale_kart = new Vector3(this.transform.localScale.x / 4, this.transform.localScale.y / 4, this.transform.localScale.z * 10);
        itemInsideZone_kart = Physics.OverlapBox(this.transform.position, collider_scale_kart, Quaternion.identity, m_LayerMask);

        foreach (Collider collider in itemInsideZone)
        {
            if (collider.gameObject.transform.root.gameObject.name == "kart")
            {
                checkoutStatus = true;
            }
            else
            {
                checkoutStatus = false;
            }

        }
    }


    private void Update()
    {
        Debug.Log("timerStatus_copy: " + timerStatus_copy);
        timerStatus_copy = target_script.timerStatus;
        if (timerStatus_copy == true)
        {
            GetItemInCheckOUT();
        }
        else
        {
            totalPrice = 0.0f;
        }
    }

    //private void Update()
    //{
    //    VisualiseBox.DisplayBox(this.transform.position, collider_scale, Quaternion.identity);
    //    GetItemInCheckOUT();
    //}

}
