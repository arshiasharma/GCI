using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Detected");
        Debug.Log(Time.time);
    }
}

