using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessForestTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player entered the endless forest");
            RenderSettings.fogDensity = 0.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has left the endless forest");
            RenderSettings.fogDensity = 0.005f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
