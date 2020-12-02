using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessForestLoop : MonoBehaviour
{
    new bool enabled = false;

    public Transform sphere;

    private void Update()
    {
        if (enabled)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player entered the point of no return");
            enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && enabled)
        {
            
            MoveObjectToCenter(other.transform);
        }
    }

    private void MoveObjectToCenter(Transform playerTransform)
    {
        Vector3 newPosition = new Vector3(sphere.position.x, playerTransform.position.y, sphere.position.z);
        Debug.Log("Player tries to leave the forest, gets teleported to " + newPosition.ToString() + " from " + playerTransform.position.ToString() );
        playerTransform.position =  newPosition;
    }
}
