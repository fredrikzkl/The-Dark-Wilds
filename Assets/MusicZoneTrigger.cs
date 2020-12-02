using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicZoneTrigger : MonoBehaviour
{
    public string MusicName;
    public float FadeTime = 0f;



    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.Play(MusicName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.Stop(MusicName);
        }
    }
}
