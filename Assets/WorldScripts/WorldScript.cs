using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{

    public bool Fog;

    void Start()
    {
        RenderSettings.fog = Fog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
