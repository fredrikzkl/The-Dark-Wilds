using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuengonDoorTrigger : MonoBehaviour
{
    public Animator doorAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorAnimation.SetBool("DoorOpened", true);
        }
        
    }
    
    
}
