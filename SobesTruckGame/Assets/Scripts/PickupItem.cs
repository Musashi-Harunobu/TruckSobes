using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public bool isPickedUp = false; 

    public void PickUp(Transform pickupPoint)
    {
        
        transform.SetParent(pickupPoint);
        transform.localPosition = Vector3.zero; 
        isPickedUp = true;
    }
}
