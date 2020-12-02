using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLogic : MonoBehaviour
{
    public float moonDistance = 900f;
    public float scale = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, moonDistance);
        transform.localScale = new Vector3(scale, scale, scale);
    }

}
