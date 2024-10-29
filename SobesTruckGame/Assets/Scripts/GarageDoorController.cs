using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            
            doorAnimator.SetTrigger("OpenClose");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            doorAnimator.SetTrigger("OpenClose");
        }
    }
    
    
}
