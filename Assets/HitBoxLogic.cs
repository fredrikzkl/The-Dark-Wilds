using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
}
