using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with " + other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.ToString());
    }
}
