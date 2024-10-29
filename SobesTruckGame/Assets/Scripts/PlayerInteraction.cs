using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform pickupPoint; 
    public int itemsCollected = 0; 
    public int maxItems = 5; 

    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            TryPickUpItem();
        }
    }

    void TryPickUpItem()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f)) 
        {
            PickupItem item = hit.transform.GetComponent<PickupItem>();

            if (item != null && !item.isPickedUp && itemsCollected < maxItems)
            {
                item.PickUp(pickupPoint);
                itemsCollected++; 
                Debug.Log("Предмет поднят и добавлен в пикап. Количество предметов: " + itemsCollected);
            }
            else if (itemsCollected >= maxItems)
            {
                Debug.Log("Вы достигли лимита по количеству перенесенных предметов.");
            }
        }
    }
}
